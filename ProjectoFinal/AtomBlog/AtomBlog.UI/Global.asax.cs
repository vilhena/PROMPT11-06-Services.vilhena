using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AtomBlog.Core;
using Microsoft.ApplicationServer.Http;

namespace AtomBlog.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapServiceRoute<AtomFeedService>("Feed", new AtomFeedHttpConfiguration());

            routes.MapRoute(
                "Index", // Route name
                "blogs", // URL with parameters
                new { controller = "Blogs", action = "Index"} // Parameter defaults
            );

            routes.MapRoute(
                "Create", // Route name
                "blogs/create", // URL with parameters
                new { controller = "Blogs", action = "Create"} // Parameter defaults
            );

            routes.MapRoute(
                "Edit", // Route name
                "blogs/{id}/edit", // URL with parameters
                new { controller = "Blogs", action = "Edit"} // Parameter defaults
            );

            routes.MapRoute(
                "Delete", // Route name
                "blogs/{id}/delete", // URL with parameters
                new { controller = "Blogs", action = "Delete"} // Parameter defaults
            );

            routes.MapRoute(
                "Details", // Route name
                "blogs/{id}", // URL with parameters
                new { controller = "Blogs", action = "Details"} // Parameter defaults
            );

            routes.MapRoute(
                "Posts", // Route name
                "blogs/{blogId}/posts", // URL with parameters
                new { controller = "Posts", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "CreatePost", // Route name
                "blogs/{blogId}/posts/create", // URL with parameters
                new { controller = "Posts", action = "Create" } // Parameter defaults
            );

            routes.MapRoute(
                "PostEdit", // Route name
                "blogs/{blogId}/posts/{id}/edit", // URL with parameters
                new { controller = "Posts", action = "Edit" } // Parameter defaults
            );

            routes.MapRoute(
                "PostDelete", // Route name
                "blogs/{blogId}/posts/{id}/delete", // URL with parameters
                new { controller = "Posts", action = "Delete" } // Parameter defaults
            );

            
            routes.MapRoute(
                "PostDetails", // Route name
                "blogs/{blogId}/posts/{id}", // URL with parameters
                new { controller = "Posts", action = "Details" } // Parameter defaults
            );


            routes.MapRoute(
                "Default", // Route name
                "", // URL with parameters
                new { controller = "Home", action = "Index"} // Parameter defaults
            );

            routes.MapRoute(
                "All", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional  } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}