using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using Microsoft.ApplicationServer.Http;
using Microsoft.ApplicationServer.Http.Activation;

namespace GitHubAtomProxy
{

  //  {
  //  "author": {
  //    "avatar_url": "https://secure.gravatar.com/avatar/61f3187a94eb0411ef92b123d7a13584?d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-140.png",
  //    "url": "https://api.github.com/users/thecodejunkie",
  //    "gravatar_id": "61f3187a94eb0411ef92b123d7a13584",
  //    "id": 50543,
  //    "login": "thecodejunkie"
  //  },
  //  "sha": "56a65923f27df206f0debd310e854a323b17d6c0",
  //  "url": "https://api.github.com/repos/NancyFx/Nancy/commits/56a65923f27df206f0debd310e854a323b17d6c0",
  //  "commit": {
  //    "author": {
  //      "email": "andreas@selfinflicted.org",
  //      "date": "2011-12-03T15:16:33-08:00",
  //      "name": "Andreas Hakansson"
  //    },
  //    "message": "Removed test razorvb.vbhtml file\n\nThe file was only used when spiking out the vbhtml support",
  //    "url": "https://api.github.com/repos/NancyFx/Nancy/git/commits/56a65923f27df206f0debd310e854a323b17d6c0",
  //    "tree": {
  //      "sha": "f20d188b268bd399f7190ffcd01e9ef88fbd07b4",
  //      "url": "https://api.github.com/repos/NancyFx/Nancy/git/trees/f20d188b268bd399f7190ffcd01e9ef88fbd07b4"
  //    },
  //    "committer": {
  //      "email": "andreas@selfinflicted.org",
  //      "date": "2011-12-03T15:16:33-08:00",
  //      "name": "Andreas Hakansson"
  //    }
  //  },
  //  "parents": [
  //    {
  //      "sha": "a0d2b02ee10076853cd8b6ef31d235e0b24e5503",
  //      "url": "https://api.github.com/repos/NancyFx/Nancy/commits/a0d2b02ee10076853cd8b6ef31d235e0b24e5503"
  //    }
  //  ],
  //  "committer": {
  //    "avatar_url": "https://secure.gravatar.com/avatar/61f3187a94eb0411ef92b123d7a13584?d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-140.png",
  //    "url": "https://api.github.com/users/thecodejunkie",
  //    "gravatar_id": "61f3187a94eb0411ef92b123d7a13584",
  //    "id": 50543,
  //    "login": "thecodejunkie"
  //  }
  //},

    public class Commit
    {
        public CommitItem commit { get; set; }
    }



    public class CommitUser
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class CommitItem
    {
        public string sha { get; set; }
        public string url { get; set; } //TODO: change this
        public CommitUser author { get; set; }
        public CommitUser committer { get; set; }
        public string message { get; set; }
    }

    [ServiceContract]
    public class GitHubService
    {
        [WebGet( UriTemplate = "/{user}/{repos}/commits")]
        public HttpResponseMessage<IEnumerable<Commit>> GetCommits(string user, string repos)
        {
            //SindicationFeed

            var client = new HttpClient();

            var res = client.GetAsync("https://api.github.com/repos/" + user + "/" + repos + "/commits").Result;

            var content = res.Content.ReadAsAsync<IEnumerable<Commit>>().Result;
            return new HttpResponseMessage<IEnumerable<Commit>>(content);
        }
    }

    public class CommitFormatter : MediaTypeFormatter
    {

        public CommitFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/atom+xml"));
        }

        protected override object OnReadFromStream(Type type, Stream stream, HttpContentHeaders contentHeaders)
        {
            throw new NotImplementedException();
        }

        protected override void OnWriteToStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext context)
        {
            var commitlist = value as IEnumerable<Commit>;
            
            if (commitlist != null)
            {
                var syndicationFeed =
                    new SyndicationFeed("Commits", "all commits", new Uri("http://localhost"));


                var items = new List<SyndicationItem>();
                foreach (var commit in commitlist)
                {
                    var item = new SyndicationItem(commit.commit.committer.name, commit.commit.message, new Uri(commit.commit.url));
                    item.Contributors.Add(new SyndicationPerson(commit.commit.committer.email, commit.commit.committer.name, ""));
                    item.Authors.Add(new SyndicationPerson(commit.commit.author.email, commit.commit.author.name, ""));
                    
                    items.Add(item);
                }
                syndicationFeed.Items = items;

                using (var xmlWriter = XmlWriter.Create(stream))
                {
                    syndicationFeed.SaveAsAtom10(xmlWriter);   
                }
            }


        }

        protected override bool CanReadType(Type type)
        {
            return false;
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof (IEnumerable<Commit>).IsAssignableFrom(type);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            var config = new HttpConfiguration();

            config.Formatters.Clear();
            config.Formatters.Add(new CommitFormatter());

            var host = new HttpServiceHost(
                typeof (GitHubService), config, "http://localhost:8888/");


            host.Open();


            Console.WriteLine("started");
            Console.ReadKey();
        }
    }
}
