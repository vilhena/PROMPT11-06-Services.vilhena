using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtomBlog.BlogServices;
using AtomBlog.DocumentRepository.RavenDB;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.UI.Models;

namespace AtomBlog.UI.Controllers
{   
    public class PostsController : Controller
    {
        private readonly PostService _postService = new PostService(new PostRavenDBDocumentRepository());
        private readonly BlogService _blogService = new BlogService(new BlogRavenDBDocumentRepository());

        //
        // GET: /Posts/

        public ViewResult Index(string blogId)
        {
            return View(_postService.GetAll().Where(p=>p.BlogId == blogId).Include(post => post.Blog).ToList());
        }

        //
        // GET: /Posts/Details/5

        public ViewResult Details(string blogId, string id)
        {
            Post post = _postService.Get(id);
            post.Blog = _blogService.Get(post.BlogId);
            return View(post);
        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
            ViewBag.PossibleBlogs = _blogService.GetAll();
            return View();
        } 

        //
        // POST: /Posts/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _postService.Create(post);
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleBlogs = _blogService.GetAll();
            return View(post);
        }
        
        //
        // GET: /Posts/Edit/5
 
        public ActionResult Edit(string id)
        {
            Post post = _postService.Get(id);
            ViewBag.PossibleBlogs = _blogService.GetAll();
            return View(post);
        }

        //
        // POST: /Posts/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _postService.Update(post);
                return RedirectToAction("Index");
            }
            ViewBag.PossibleBlogs = _blogService.GetAll();
            return View(post);
        }

        //
        // GET: /Posts/Delete/5
 
        public ActionResult Delete(string id)
        {
            Post post = _postService.Get(id);
            return View(post);
        }

        //
        // POST: /Posts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            _postService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}