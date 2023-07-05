using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestFluent
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "TaskCreate",
               url: "UserStory/{userStoryId}/Tasks/Task/Create",
               defaults: new { controller = "Task", action = "Create" }
            );

            routes.MapRoute(
               name: "Task",
               url: "UserStory/{userStoryId}/Task/{id}/{action}",
               defaults: new { controller = "Task", action="Index", userStoryId = UrlParameter.Optional, id = UrlParameter.Optional, }
            ); ;

            //routes.MapRoute(
            //     name: "Task",
            //     url: "UserStory/{userStoryId}/Task/{taskId}/{action}",
            //     defaults: new { controller = "Task", action = "Create", taskId = UrlParameter.Optional },
            //     new { taskId = @"\d+" }
            //     );

            //routes.MapRoute(
            //    name: "UserStory",
            //    url: "{controller}/{id}/{action}",
            //    defaults: new { controller = "UserStory", action="Index", id = UrlParameter.Optional}
            //    );
            
            
        }
    }
}
