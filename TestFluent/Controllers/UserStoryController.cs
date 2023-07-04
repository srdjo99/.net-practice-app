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

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var userStories = session.Query<UserStoryModel>().ToList();
                return View(userStories);
            }
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserStoryModel userStory)
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

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var userStory = session.Get<UserStoryModel>(id);
                return View(userStory);
            }
        }

   
        [HttpPost]
        public ActionResult Edit(int id, UserStoryModel userStory)
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

        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var userStory = session.Get<UserStoryModel>(id);
                return View(userStory);
            }
        }

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var userStory = session.Get<UserStoryModel>(id);
                return View(userStory);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, UserStoryModel userStory)
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


        // Tasks
        public ActionResult Tasks(int id)
        {
            ViewBag.ID = id;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var tasks = session.QueryOver<TaskModel>().Where(t=> t.UserStory.Id == id).List();
                return View(tasks);
            }
        }
    }
}