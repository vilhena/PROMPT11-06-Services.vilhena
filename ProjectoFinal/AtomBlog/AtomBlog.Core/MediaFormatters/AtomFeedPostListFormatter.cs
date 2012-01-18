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
    public class AtomPostListFeedFormatter : MediaTypeFormatter
    {
        //TODO:change this
        public string ServiceURI = "http://localhost./Feed";


        public AtomPostListFeedFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/atom+xml"));
        }

        protected override object OnReadFromStream(Type type, Stream stream, HttpContentHeaders contentHeaders)
        {
            throw new NotImplementedException();
        }

        protected override void OnWriteToStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext context)
        {
            var postList = value as IEnumerable<Post>;
            if (postList == null) return;

            var syndicationFeed =
                new SyndicationFeed("Posts from Blog " + postList.FirstOrDefault().Blog.Title
                                    , postList.FirstOrDefault().Blog.Description
                                    ,
                                    new Uri(this.ServiceURI + "/blogs/" + postList.FirstOrDefault().BlogId +
                                            "/posts"))
                    {
                        Items = postList
                            .Select(postItem => PostAtomConverter
                                                    .PostToSyndicationItem(postItem, this.ServiceURI))
                    };

            using (var xmlWriter = XmlWriter.Create(stream))
            {
                syndicationFeed.SaveAsAtom10(xmlWriter);
            }
        }

        protected override bool CanReadType(Type type)
        {
            return false;
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(IEnumerable<Post>).IsAssignableFrom(type);
        }
    }
}
