using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;

namespace AtomBlog.Core.Utils
{
    static class PostAtomConverter
    {
        public static SyndicationItem PostToSyndicationItem(Post post, string baseServiceURL)
        {
            var postSyndicationItem = new SyndicationItem(post.Title
                                                          , post.Content
                                                          ,
                                                          new Uri(baseServiceURL + "/blogs/" + post.BlogId + "/posts/" +
                                                                  post.Id));

            postSyndicationItem.LastUpdatedTime = post.LastUpdated;
            postSyndicationItem.PublishDate = post.PublishDate;

            postSyndicationItem.Links.Add(
                SyndicationLink.CreateSelfLink(
                    new Uri(baseServiceURL + "/blogs/" + post.BlogId + "/posts/" +
                            post.Id))
                );

            postSyndicationItem.Links.Add(
                new SyndicationLink(
                    new Uri(baseServiceURL + "/blogs/" + post.BlogId + "/posts/" +
                            post.Id)
                    , "edit", "Edit Post",
                    "application/atom+xml", 0)
                );
            postSyndicationItem.Links.Add(
                new SyndicationLink(
                    new Uri(baseServiceURL + "/blogs/" + post.BlogId), "blog", "Blog",
                    "application/atom+xml", 0)
                );

            postSyndicationItem.Links.Add(
                SyndicationLink.CreateAlternateLink(
                    new Uri("http://localhost./blogs/" + post.BlogId + "/posts/" + post.Id), "text/html"));

            return postSyndicationItem;
        }
    }
}
