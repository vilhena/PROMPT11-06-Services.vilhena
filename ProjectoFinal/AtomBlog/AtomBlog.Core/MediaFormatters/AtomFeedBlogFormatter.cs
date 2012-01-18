using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Xml;
using AtomBlog.Core.Utils;
using AtomBlog.Domain.AtomDomainModel;

namespace AtomBlog.Core.MediaFormatters
{
    public class AtomFeedBlogFormatter : MediaTypeFormatter
    {
        //TODO:change this
        public string ServiceURI = "http://localhost./Feed";


        public AtomFeedBlogFormatter()
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

                var blog = new Blog
                               {
                                   Id = syndicationItem.Id,
                                   Title = syndicationItem.Title.Text,
                                   Description = syndicationItem.Content is TextSyndicationContent
                                                 ? ((TextSyndicationContent) syndicationItem.Content).Text
                                                 : string.Empty,
                                   LastUpdatedTime = syndicationItem.LastUpdatedTime,
                                   PublishDate = syndicationItem.PublishDate
                               };

                return blog;
            }
        }

        protected override void OnWriteToStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext context)
        {
            var blog = value as Blog;
            if (blog == null) return;

            var syndicationFeed =
                new SyndicationFeed(blog.Title, blog.Description, new Uri(this.ServiceURI + "/blogs/" + blog.Id))
                    {
                        Items = new List<SyndicationItem>()
                                    {
                                        BlogAtomConverter.BlogToSyndicationItem(blog, this.ServiceURI)
                                    }
                    };

            using (var xmlWriter = XmlWriter.Create(stream))
            {
                syndicationFeed.SaveAsAtom10(xmlWriter);
            }
        }

        protected override bool CanReadType(Type type)
        {
            return typeof(Blog).IsAssignableFrom(type);
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(Blog).IsAssignableFrom(type);
        }
    }
}
