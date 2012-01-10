using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace AtomBlog.Core
{
    public class AtomFeedFormatter : MediaTypeFormatter
    {
        public AtomFeedFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/atom+xml"));
        }

        protected override object OnReadFromStream(Type type, Stream stream, HttpContentHeaders contentHeaders)
        {
            throw new NotImplementedException();
        }

        protected override void OnWriteToStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext context)
        {
            //var commitlist = value as IEnumerable<string>;
            
            //if (commitlist != null)
            //{
                var syndicationFeed =
                    new SyndicationFeed("Commits", "all commits", new Uri("http://localhost"));


                var items = new List<SyndicationItem>();
                //foreach (var commit in commitlist)
                //{
                var item = new SyndicationItem("bla", "message", new Uri("http://localhost"));
                    item.Contributors.Add(new SyndicationPerson("email", "name", ""));
                    item.Authors.Add(new SyndicationPerson("email", "name", ""));
                    
                    items.Add(item);
                //}
                syndicationFeed.Items = items;

                using (var xmlWriter = XmlWriter.Create(stream))
                {
                    syndicationFeed.SaveAsAtom10(xmlWriter); 
                }
            //}


        }

        protected override bool CanReadType(Type type)
        {
            return false;
        }

        protected override bool CanWriteType(Type type)
        {
            //return typeof (IEnumerable<string>).IsAssignableFrom(type);
            return true;
        }
    }
}
