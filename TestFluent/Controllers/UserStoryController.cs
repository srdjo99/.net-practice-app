using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFluent.Models;
using NHibernate;
using TestFluent.Models.UserStory;

namespace TestFluent.Controllers
{
    public class UserStoryController : Controller
    {
        // GET: UserStory
        public ActionResult Index()
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                var userStories = session.Query<UserStory>().ToList();
                return View(userStories);

            }
        }
    }
}