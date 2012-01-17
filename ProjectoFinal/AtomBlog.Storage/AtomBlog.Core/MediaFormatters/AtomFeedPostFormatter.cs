using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Xml;
using AtomBlog.Core.Utils;
using AtomBlog.Domain.AtomDomainModel;

namespace AtomBlog.Core.MediaFormatters
{
    public class AtomPostFeedFormatter : MediaTypeFormatter
    {
        //TODO:change this
        public string ServiceURI = "http://localhost./Feed";


        public AtomPostFeedFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/atom+xml"));
        }

        protected override object OnReadFromStream(Type type, Stream stream, HttpContentHeaders contentHeaders)
        {
            using (var xmlReader = XmlReader.Create(stream))
            {
                var syndicationItem = SyndicationItem.Load(xmlReader);
                if (syndicationItem == null)
                    return null;

                var post = new Post
                               {
                                   Id = syndicationItem.Id,
                                   Title = syndicationItem.Title.Text,
                                   Content = syndicationItem.Content is TextSyndicationContent
                                                 ? ((TextSyndicationContent) syndicationItem.Content).Text
                                                 : string.Empty,
                                   PublishDate = syndicationItem.PublishDate,
                                   LastUpdated = syndicationItem.LastUpdatedTime
                               };

                return post;
            }
        }

        protected override void OnWriteToStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext context)
        {
            var post = value as Post;
            if (post == null) return;

            var syndicationFeed =
                new SyndicationFeed(post.Title, "Post " + post.Title
                                    , new Uri(this.ServiceURI + "/blogs/" + post.BlogId + "/posts/" +
                                              post.Id))
                    {
                        Items = new List<SyndicationItem>()
                                    {
                                        PostAtomConverter.PostToSyndicationItem(post, this.ServiceURI)
                                    }
                    };

            using (var xmlWriter = XmlWriter.Create(stream))
            {
                syndicationFeed.SaveAsAtom10(xmlWriter);
            }
        }

  

        protected override bool CanReadType(Type type)
        {
            return typeof(Post).IsAssignableFrom(type);
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(Post).IsAssignableFrom(type);
        }
    }
}
