using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatContract;
using ChatServiceClientMVC.Models;

namespace ChatServiceClientMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Chat()
        {
            var callback = Session["callback"] as ChatClientImpl;
            if (callback != null && callback.Messages != null)
            {
                return View(callback.Messages);
            }
            else
            {
                return View(new List<string>());
            }
        }
    }
}
