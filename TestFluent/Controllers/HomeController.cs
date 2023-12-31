﻿using TestFluent.Models;
using TestFluent.Models.Identity;
using System.Web.Mvc;

namespace TestFluent.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(CurrentUser);
        }

        private User currentUser = null;
        public User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    string userName = User.Identity.Name;
                    if (userName != null)
                    {
                        currentUser = new DatabaseContext().Users.FindByNameAsync(userName).Result;
                    }
                }
                return currentUser;
            }
        }
    }
}