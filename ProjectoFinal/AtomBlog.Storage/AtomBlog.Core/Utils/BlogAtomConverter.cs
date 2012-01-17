using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;

namespace AtomBlog.Core.Utils
{
    static class BlogAtomConverter
    {
        public static SyndicationItem BlogToSyndicationItem(Blog blog, string baseServiceURL)
        {
            var blogSyndicationItem = new SyndicationItem(blog.Title
                                                          , blog.Description
                                                          , new Uri(baseServiceURL + "/blogs/" + blog.Id));
            blogSyndicationItem.LastUpdatedTime = blog.LastUpdatedTime;
            blogSyndicationItem.PublishDate = blog.PublishDate;
            blogSyndicationItem.Links.Add(
                SyndicationLink.CreateSelfLink(new Uri(baseServiceURL + "/blogs/" + blog.Id)));

            blogSyndicationItem.Links.Add(
                new SyndicationLink(
                    new Uri(baseServiceURL + "/blogs/" + blog.Id), "edit", "Edit Blog",
                    "application/atom+xml", 0)
                );
            blogSyndicationItem.Links.Add(
                new SyndicationLink(
                    new Uri(baseServiceURL + "/blogs/" + blog.Id + "/posts"), "posts", "Blog posts",
                    "application/atom+xml", 0)
                );
            blogSyndicationItem.Links.Add(
                SyndicationLink.CreateAlternateLink(
                    new Uri("http://localhost./blogs/" + blog.Id), "text/html"));

            return blogSyndicationItem;
        }
    }
}
