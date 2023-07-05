using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFluent.Models;

namespace TestFluent.Controllers
{
    public class UserStoryController : Controller
    {

       
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var userStories = session.Query<UserStoryModel>().ToList();
                    return View(userStories);
                }
            }

            return RedirectToAction("Login", "Account");
           
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserStoryModel userStory)
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(userStory);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Login", "Account");

        }

        public ActionResult Edit(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var userStory = session.Get<UserStoryModel>(id);
                    return View(userStory);
                }
            }
            
            return RedirectToAction("Login", "Account");
        }

   
        [HttpPost]
        public ActionResult Edit(int id, UserStoryModel userStory)
        {
                if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var userStoryToUpdate = session.Get<UserStoryModel>(id);

                    userStoryToUpdate.Title = userStory.Title;
                    userStoryToUpdate.Description = userStory.Description;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(userStoryToUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Login", "Account");
                
            
        }

        public ActionResult Details(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var userStory = session.Get<UserStoryModel>(id);
                    return View(userStory);
                }
            }

            return RedirectToAction("Login", "Account");
            
        }

        public ActionResult Delete(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var userStory = session.Get<UserStoryModel>(id);
                    return View(userStory);
                }
            }

            return RedirectToAction("Login", "Account");
            
        }

        [HttpPost]
        public ActionResult Delete(int id, UserStoryModel userStory)
        {
                if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(userStory);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Login", "Account");
                
           
        }


        // Tasks
        public ActionResult Tasks(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                ViewBag.ID = id;
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var tasks = session.QueryOver<TaskModel>().Where(t => t.UserStory.Id == id).List();
                    return View(tasks);
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}