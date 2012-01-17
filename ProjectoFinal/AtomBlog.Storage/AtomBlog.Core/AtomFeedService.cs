using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
        public string ServiceURI = "http://localhost./Feed";

        //TODO:change this
        public static IEnumerable<Blog> Blogs = new List<Blog>()
                                             {
                                                 new Blog()
                                                     {
                                                         Id = "1",
                                                         Title = "FirstBlog",
                                                         Description = "first Description",
                                                         PublishDate = DateTime.Now.AddDays(-1),
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
                                                         PublishDate = DateTime.Now.AddDays(-2),
                                                         Posts = new List<Post>
                                                                     {
                                                                         new Post()
                                                                             {
                                                                                 Id = "2",
                                                                                 Title = "Second Blog First Post",
                                                                                 Content = "nothing",
                                                                                 BlogId = "2"
                                                                             }
                                                                     }
                                                     },
                                                 new Blog()
                                                     {
                                                         Id = "3",
                                                         Title = "ThirdBlog",
                                                         Description = "Third Description",
                                                         PublishDate = DateTime.Now.AddDays(-3),
                                                         Posts  = new List<Post>
                                                                     {
                                                                         new Post()
                                                                             {
                                                                                 Id = "3",
                                                                                 Title = "Third Blog First Post",
                                                                                 Content = "nothing",
                                                                                 BlogId = "3"
                                                                             }
                                                                     }
                                                     },
                                             };


        [WebGet(UriTemplate = "/atom-service-doc")]
        public HttpResponseMessage<ServiceDocument> ServiceDocumentation()
        {

            //TODO: change this to specific
            var serviceDocument = new ServiceDocument()
                                      {
                                          BaseUri = new Uri(this.ServiceURI + "/blogs")
                                      };

            var collection = new List<ResourceCollectionInfo>();

            foreach (var blog in Blogs)
            {
                var resourceCollectionInfo = new ResourceCollectionInfo(blog.Title,
                                                                    new Uri(this.ServiceURI + "/blogs/" + blog.Id + "/posts"));

                resourceCollectionInfo.Accepts.Add("application/atom+xml;type=entry");
                collection.Add(resourceCollectionInfo);
            }

            var workspace = new Workspace("Feed", collection);
            serviceDocument.Workspaces.Add(workspace);

            return new HttpResponseMessage<ServiceDocument>(serviceDocument, HttpStatusCode.OK);
        }

        [WebGet(UriTemplate = "/blogs")]
        public HttpResponseMessage<IEnumerable<Blog>> GetBlogs()
        {
            return new HttpResponseMessage<IEnumerable<Blog>>(Blogs,HttpStatusCode.OK);
        }

        [WebGet(UriTemplate = "/blogs/{id}")]
        public HttpResponseMessage<Blog> GetBlog(string id)
        {
            return new HttpResponseMessage<Blog>(Blogs.Where(b => b.Id == id).FirstOrDefault(), HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs", Method = "POST")]
        public HttpResponseMessage CreateBlog(HttpRequestMessage<Blog> request)
        {
            // it just calls the formatter on content read
            var blog = request.Content.ReadAsAsync().Result;
            var maxId = Blogs.Select(b => int.Parse(b.Id)).Max() + 1;
            blog.Id = maxId.ToString();
            //TODO: change this
            
            var blogs = Blogs.ToList();
            blogs.Add(blog);
            Blogs = blogs;

            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(this.ServiceURI + "/blogs/" + blog.Id);

            return response;
        }

        [WebInvoke(UriTemplate = "/blogs/{id}", Method = "PUT")]
        public HttpResponseMessage UpdateBlog(string id, HttpRequestMessage request)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs/{id}", Method = "DELETE")]
        public HttpResponseMessage DeleteBlog(string id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [WebGet(UriTemplate = "/blogs/{id}/posts")]
        public HttpResponseMessage<IEnumerable<Post>> GetPosts(string id)
        {
            var blog = Blogs.Where(b => b.Id == id).FirstOrDefault();
            foreach (var post in blog.Posts)
            {
                post.Blog = blog;
            }
            return new HttpResponseMessage<IEnumerable<Post>>(blog.Posts,HttpStatusCode.OK);
        }

        [WebGet(UriTemplate = "/blogs/{blogId}/posts/{id}")]
        public HttpResponseMessage<Post> GetPost(string blogId, string id)
        {
            var blog = Blogs.Where(b => b.Id == blogId).FirstOrDefault();
            var post = blog.Posts.Where(p => p.Id == id).FirstOrDefault();
            post.Blog = blog;

            return new HttpResponseMessage<Post>(post, HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs/{id}/posts", Method = "POST")]
        public HttpResponseMessage CreatePost(string id, HttpRequestMessage<Post> request)
        {
            // it just calls the formatter on content read
            var post = request.Content.ReadAsAsync().Result;
            post.BlogId = id;
            var maxId = Blogs.Where(b => b.Id == id).FirstOrDefault().Posts.Select(p => int.Parse(p.Id)).Max()+1;
            post.Id = maxId.ToString();
            //TODO: change this
            var posts = Blogs.Where(b => b.Id == id).FirstOrDefault().Posts.ToList();
            posts.Add(post);
            Blogs.Where(b => b.Id == id).FirstOrDefault().Posts = posts;

            var response = new HttpResponseMessage(HttpStatusCode.Created);
            
            response.Headers.Location = new Uri(this.ServiceURI + "/blogs/" + id + "/posts/" + post.Id);

            return response;
        }

        

        [WebInvoke(UriTemplate = "/blogs/{blogId}/posts/{id}", Method = "PUT")]
        public HttpResponseMessage UpdatePost(string blogId, string id, HttpRequestMessage request)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs/{blogId}/posts/{id}", Method = "DELETE")]
        public HttpResponseMessage DeletePost(string blogId, string id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
