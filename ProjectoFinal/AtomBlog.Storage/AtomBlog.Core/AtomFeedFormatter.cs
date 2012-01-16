using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using AtomBlog.Domain.AtomDomainModel;

namespace AtomBlog.Core
{
    public class AtomFeedFormatter : MediaTypeFormatter
    {
        //TODO:change this
        public string ServiceURI = "http://localhost/Feed";


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
            var bloglist = value as IEnumerable<Blog>;
            if (bloglist != null)
            {
                var syndicationFeed =
                    new SyndicationFeed("Blogs", "all blogs", new Uri(this.ServiceURI + "/blogs"));

                syndicationFeed.Items = bloglist
                    .Select(b =>
                            new SyndicationItem(b.Title
                                                , b.Description
                                                , new Uri(this.ServiceURI + "/blogs/" + b.Id))
                                {
                                    LastUpdatedTime = b.Updated
                                });

                using (var xmlWriter = XmlWriter.Create(stream))
                {
                    syndicationFeed.SaveAsAtom10(xmlWriter); 
                }

                return;
            }

            var blog = value as Blog;
            if(blog != null)
            {
                var syndicationFeed =
                    new SyndicationFeed(blog.Title, blog.Description, new Uri(this.ServiceURI + "/blogs/" + blog.Id));

                syndicationFeed.Items = blog.Posts
                    .Select(p =>
                            new SyndicationItem(p.Title, p.Content,
                                                new Uri(this.ServiceURI + "/blogs/" + blog.Id + "/posts/" + p.Id), p.Id,
                                                p.LastUpdated)
                                {
                                    PublishDate = p.PublishDate
                                }
                    );
                using (var xmlWriter = XmlWriter.Create(stream))
                {
                    syndicationFeed.SaveAsAtom10(xmlWriter);
                }
                return;
            }

            var post = value as Post;
            if (post != null)
            {
                var syndicationFeed =
                    new SyndicationFeed(post.Title
                                        , post.Content.Substring(0, 10)
                                        , new Uri(this.ServiceURI + "/blogs/" + post.BlogId + "/posts/" + post.Id));

                using (var xmlWriter = XmlWriter.Create(stream))
                {
                    syndicationFeed.SaveAsAtom10(xmlWriter);
                }
                return;
            }


        }

        protected override bool CanReadType(Type type)
        {
            return true;
        }

        protected override bool CanWriteType(Type type)
        {
            //return typeof (IEnumerable<string>).IsAssignableFrom(type);
            return true;
        }
    }
}
