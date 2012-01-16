using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;

namespace AtomBlog.Core
{
    [ServiceContract]
    public class AtomFeedService
    {
        //TODO:change this
        public string ServiceURI = "http://localhost/Feed";

        //TODO:change this
        public IEnumerable<Blog> Blogs = new List<Blog>()
                                             {
                                                 new Blog()
                                                     {
                                                         Id = "1",
                                                         Title = "FirstBlog",
                                                         Description = "first Description",
                                                         Updated = DateTime.Now.AddDays(-1),
                                                         Posts = new List<Post>
                                                                     {
                                                                         new Post()
                                                                             {
                                                                                 Id = "1",
                                                                                 Title = "First Blog First Post",
                                                                                 Content = "nothing",
                                                                                 BlogId = "1"
                                                                             }
                                                                     }
                                                     },
                                                 new Blog()
                                                     {
                                                         Id = "2",
                                                         Title = "SecondBlog",
                                                         Description = "Second Description",
                                                         Updated = DateTime.Now.AddDays(-2),
                                                         Posts = new List<Post>()
                                                     },
                                                 new Blog()
                                                     {
                                                         Id = "3",
                                                         Title = "ThirdBlog",
                                                         Description = "Third Description",
                                                         Updated = DateTime.Now.AddDays(-3),
                                                         Posts = new List<Post>()
                                                     },
                                             };


        [WebGet(UriTemplate = "/atom-service-doc")]
        public ServiceDocument ServiceDocumentation()
        {
            var serviceDocument = new ServiceDocument()
                                      {
                                          BaseUri = new Uri(this.ServiceURI)
                                      };

            var resourceCollectionInfo = new ResourceCollectionInfo("Blogs",
                                                                    new Uri(this.ServiceURI + "/blogs"));
            resourceCollectionInfo.Accepts.Add("application/atom+xml;type=feed");

            var workspace = new Workspace("Feed", new List<ResourceCollectionInfo>
                                                      {
                                                          resourceCollectionInfo
                                                      });

            serviceDocument.Workspaces.Add(workspace);


            return serviceDocument;
        }

        [WebGet(UriTemplate = "/blogs")]
        public IEnumerable<Blog> GetBlogs()
        {
            return Blogs;
        }

        [WebGet(UriTemplate = "/blogs/{id}")]
        public Blog GetBlog(string id)
        {
            return Blogs.Where(b => b.Id == id).FirstOrDefault();
        }

        [WebInvoke(UriTemplate = "/blogs", Method = "POST")]
        public Blog CreateBlog(HttpRequestMessage request)
        {
            return new Blog()
                       {
                           Id = "1",
                           Title = "FirstBlog",
                           Description = "first Description"
                       };
        }

        [WebInvoke(UriTemplate = "/blogs/{id}", Method = "PUT")]
        public bool UpdateBlog(string id, HttpRequestMessage request)
        {
            return true;
        }

        [WebInvoke(UriTemplate = "/blogs/{id}", Method = "DELETE")]
        public void DeleteBlog(string id, HttpRequestMessage request)
        {
            return;
        }

        [WebGet(UriTemplate = "/blogs/{id}/posts")]
        public IEnumerable<Post> GetPosts(string id, HttpRequestMessage request)
        {
            return Blogs.Where(b => b.Id == id).FirstOrDefault().Posts;
        }

        [WebInvoke(UriTemplate = "/blogs/{id}/posts", Method = "POST")]
        public Post CreatePost(string id, HttpRequestMessage request)
        {
            return new Post();
        }

        [WebGet(UriTemplate = "/blogs/{blogId}/posts/{id}")]
        public Post GetPost(string blogId, string id, HttpRequestMessage request)
        {
            return new Post();
        }

        [WebInvoke(UriTemplate = "/blogs/{blogId}/posts/{id}", Method = "PUT")]
        public bool UpdatePost(string blogId, string id, HttpRequestMessage request)
        {
            return true;
        }

    }
}
