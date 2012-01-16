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
    public class AtomFeedBlogListFormatter : MediaTypeFormatter
    {
        public AtomFeedBlogListFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/atom+xml"));
        }

        protected override object OnReadFromStream(Type type, Stream stream, HttpContentHeaders contentHeaders)
        {
            throw new NotImplementedException();
        }

        protected override void OnWriteToStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext context)
        {
            var version = value as string;
            
            //if (version != null)
            //{
            //    var syndicationFeed =
            //        new SyndicationFeed("Application Version " + version,"", new Uri("http://localhost"));
                
            //    using (var xmlWriter = XmlWriter.Create(stream))
            //    {
            //        syndicationFeed.SaveAsAtom10(xmlWriter); 
            //    }
            //}
        }

        protected override bool CanReadType(Type type)
        {
            return false;
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(string).IsAssignableFrom(type);
        }
    }
}
