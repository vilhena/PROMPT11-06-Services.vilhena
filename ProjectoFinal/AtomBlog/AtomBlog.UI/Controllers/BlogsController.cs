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
    public class BlogsController : Controller
    {
        private readonly BlogService _blogService = new BlogService(new BlogRavenDBDocumentRepository());

        //
        // GET: /Blogs/

        public ViewResult Index()
        {
            return View(_blogService.GetAll().ToList());
        }

        //
        // GET: /Blogs/Details/5

        public ViewResult Details(string id)
        {
            Blog blog = _blogService.Get(id);
            return View(blog);
        }

        //
        // GET: /Blogs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Blogs/Create

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                //blog.Id = (new Random()).Next(20).ToString();
                _blogService.Create(blog);

                return RedirectToAction("Index");  
            }

            return View(blog);
        }
        
        //
        // GET: /Blogs/Edit/5
 
        public ActionResult Edit(string id)
        {
            Blog blog = _blogService.Get(id);
            return View(blog);
        }

        //
        // POST: /Blogs/Edit/5

        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogService.Update(blog);
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        //
        // GET: /Blogs/Delete/5
 
        public ActionResult Delete(string id)
        {
            Blog blog = _blogService.Get(id);
            return View(blog);
        }

        //
        // POST: /Blogs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            _blogService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}