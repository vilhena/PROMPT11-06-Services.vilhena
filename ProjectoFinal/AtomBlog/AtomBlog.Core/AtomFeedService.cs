using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using AtomBlog.BlogServices;
using AtomBlog.DocumentRepository.RavenDB;
using AtomBlog.Domain.AtomDomainModel;

namespace AtomBlog.Core
{
    [ServiceContract]
    public class AtomFeedService
    {
        private readonly BlogService _blogService  = new BlogService(new BlogRavenDBDocumentRepository());
        private readonly PostService _postService = new PostService(new PostRavenDBDocumentRepository());

        //TODO:change this
        public string ServiceURI = "http://localhost./Feed";

        #region InMemory
        ////TODO:change this
        //public static IEnumerable<Blog> Blogs = new List<Blog>()
        //                                     {
        //                                         new Blog()
        //                                             {
        //                                                 Id = "1",
        //                                                 Title = "FirstBlog",
        //                                                 Description = "first Description",
        //                                                 PublishDate = DateTime.Now.AddDays(-1),
        //                                                 Posts = new List<Post>
        //                                                             {
        //                                                                 new Post()
        //                                                                     {
        //                                                                         Id = "1",
        //                                                                         Title = "First Blog First Post",
        //                                                                         Content = "nothing",
        //                                                                         BlogId = "1"
        //                                                                     }
        //                                                             }
        //                                             },
        //                                         new Blog()
        //                                             {
        //                                                 Id = "2",
        //                                                 Title = "SecondBlog",
        //                                                 Description = "Second Description",
        //                                                 PublishDate = DateTime.Now.AddDays(-2),
        //                                                 Posts = new List<Post>
        //                                                             {
        //                                                                 new Post()
        //                                                                     {
        //                                                                         Id = "2",
        //                                                                         Title = "Second Blog First Post",
        //                                                                         Content = "nothing",
        //                                                                         BlogId = "2"
        //                                                                     }
        //                                                             }
        //                                             },
        //                                         new Blog()
        //                                             {
        //                                                 Id = "3",
        //                                                 Title = "ThirdBlog",
        //                                                 Description = "Third Description",
        //                                                 PublishDate = DateTime.Now.AddDays(-3),
        //                                                 Posts  = new List<Post>
        //                                                             {
        //                                                                 new Post()
        //                                                                     {
        //                                                                         Id = "3",
        //                                                                         Title = "Third Blog First Post",
        //                                                                         Content = "nothing",
        //                                                                         BlogId = "3"
        //                                                                     }
        //                                                             }
        //                                             },
        //                                     }; 
        #endregion


        [WebGet(UriTemplate = "/atom-service-doc")]
        public HttpResponseMessage<ServiceDocument> ServiceDocumentation()
        {

            //TODO: change this to specific
            var serviceDocument = new ServiceDocument()
                                      {
                                          BaseUri = new Uri(this.ServiceURI + "/blogs")
                                      };

            var collection = new List<ResourceCollectionInfo>();

            foreach (var blog in _blogService.GetAll())
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
            return new HttpResponseMessage<IEnumerable<Blog>>(_blogService.GetAll(),HttpStatusCode.OK);
        }

        [WebGet(UriTemplate = "/blogs/{id}")]
        public HttpResponseMessage<Blog> GetBlog(string id)
        {
            return new HttpResponseMessage<Blog>(_blogService.GetAll().Where(b => b.Id == id).FirstOrDefault(), HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs", Method = "POST")]
        public HttpResponseMessage CreateBlog(HttpRequestMessage<Blog> request)
        {
            // it just calls the formatter on content read
            var blog = request.Content.ReadAsAsync().Result;
            blog.Id = null;
            _blogService.Create(blog);

            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(this.ServiceURI + "/blogs/" + blog.Id);

            return response;
        }

        [WebInvoke(UriTemplate = "/blogs/{id}", Method = "PUT")]
        public HttpResponseMessage UpdateBlog(string id, HttpRequestMessage<Blog> request)
        {
            var blog = request.Content.ReadAsAsync().Result;
            _blogService.Update(blog);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs/{id}", Method = "DELETE")]
        public HttpResponseMessage DeleteBlog(string id)
        {
            _blogService.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [WebGet(UriTemplate = "/blogs/{id}/posts")]
        public HttpResponseMessage<IEnumerable<Post>> GetPosts(string id)
        {

            var posts = _postService.GetAll().Where(p => p.BlogId == id).ToList();
            foreach (var post in posts)
            {
                post.Blog = _blogService.Get(post.BlogId);
            }
            return new HttpResponseMessage<IEnumerable<Post>>(posts,HttpStatusCode.OK);
        }

        [WebGet(UriTemplate = "/blogs/{blogId}/posts/{id}")]
        public HttpResponseMessage<Post> GetPost(string blogId, string id)
        {
            var post =
                _postService.GetAll()
                    .Where(p => p.BlogId == blogId && p.Id == id).FirstOrDefault();
            post.Blog = _blogService.Get(post.BlogId);

            return new HttpResponseMessage<Post>(post, HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs/{id}/posts", Method = "POST")]
        public HttpResponseMessage CreatePost(string id, HttpRequestMessage<Post> request)
        {
            
            // it just calls the formatter on content read
            var post = request.Content.ReadAsAsync().Result;
            post.Id = null;
            post.BlogId = id;
            var blog = _blogService.Get(id);
            post.Blog = blog;
            _postService.Create(post);

            var response = new HttpResponseMessage(HttpStatusCode.Created);
            
            response.Headers.Location = new Uri(this.ServiceURI + "/blogs/" + id + "/posts/" + post.Id);

            return response;
        }

        

        [WebInvoke(UriTemplate = "/blogs/{blogId}/posts/{id}", Method = "PUT")]
        public HttpResponseMessage UpdatePost(string blogId, string id, HttpRequestMessage<Post> request)
        {
            // it just calls the formatter on content read
            var post = request.Content.ReadAsAsync().Result;
            _postService.Update(post);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [WebInvoke(UriTemplate = "/blogs/{blogId}/posts/{id}", Method = "DELETE")]
        public HttpResponseMessage DeletePost(string blogId, string id)
        {
            _postService.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
