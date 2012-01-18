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
    public class AtomFeedBlogListFormatter : MediaTypeFormatter
    {
        //TODO:change this
        public string ServiceURI = "http://localhost./Feed";


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
            var bloglist = value as IEnumerable<Blog>;
            if (bloglist != null)
            {
                var syndicationFeed =
                    new SyndicationFeed("Blogs", "all blogs", new Uri(this.ServiceURI + "/blogs"))
                        {
                            Items = bloglist
                                .Select(blogItem => BlogAtomConverter
                                                        .BlogToSyndicationItem(blogItem, this.ServiceURI))
                        };

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
            return typeof(IEnumerable<Blog>).IsAssignableFrom(type);
        }
    }
}
