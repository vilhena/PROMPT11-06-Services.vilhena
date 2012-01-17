using System;
using System.IO;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Xml;

namespace AtomBlog.Core.MediaFormatters
{
    public class AtomFeedServiceDocumentFormatter : MediaTypeFormatter
    {
        public AtomFeedServiceDocumentFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/atomsvc+xml"));
        }

        protected override object OnReadFromStream(Type type, Stream stream, HttpContentHeaders contentHeaders)
        {
            throw new NotImplementedException();
        }

        protected override void OnWriteToStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext context)
        {
            var document = value as ServiceDocument;
            contentHeaders.ContentType = new MediaTypeHeaderValue("application/atomsvc+xml");

            if (document != null)
            {
                using (var xmlWriter = XmlWriter.Create(stream))
                {
                    document.GetFormatter().WriteTo(xmlWriter);
                }
            }
        }

        protected override bool CanReadType(Type type)
        {
            return false;
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(ServiceDocument).IsAssignableFrom(type);
        }
    }
}
