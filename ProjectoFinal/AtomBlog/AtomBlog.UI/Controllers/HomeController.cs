using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtomBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Blogs Atom Site!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
