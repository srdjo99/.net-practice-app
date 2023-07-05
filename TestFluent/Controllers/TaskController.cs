using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFluent.Models;

namespace TestFluent.Controllers
{
    public class TaskController : Controller
    {

        public ActionResult Index(int userStoryId, int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                var task = new TaskModel();
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    task.UserStory = session.Query<UserStoryModel>().Where(u => u.Id == userStoryId).FirstOrDefault();
                    task = session.Get<TaskModel>(id);
                }
                return View(task);
            }

            return RedirectToAction("Login", "Account");
           
        }



        public ActionResult Create(int userStoryId)
        {
            if(User.Identity.IsAuthenticated)
            {
                var task = new TaskModel();
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    task.UserStory = session.Query<UserStoryModel>().Where(u => u.Id == userStoryId).FirstOrDefault();
                }
                return View(task);
            }

            return RedirectToAction("Login", "Account");
           
        }


        [HttpPost]
        public ActionResult Create(int userStoryId, TaskModel task)
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    task.UserStory = session.Query<UserStoryModel>().Where(u => u.Id == userStoryId).FirstOrDefault();
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(task);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Tasks", "UserStory", new { ID = userStoryId });
            }

            return RedirectToAction("Login", "Accoount");
            

        }

        public ActionResult Edit(int userStoryId, int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                var task = new TaskModel();
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    task.UserStory = session.Query<UserStoryModel>().Where(u => u.Id == userStoryId).FirstOrDefault();
                    task = session.Get<TaskModel>(id);
                }

                return View(task);
            }

            return RedirectToAction("Login", "Account");
            
        }

        [HttpPost]
        public ActionResult Edit(int userStoryId, int id, TaskModel task)
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var taskToUpdate = session.Get<TaskModel>(id);

                    taskToUpdate.Title = task.Title;
                    taskToUpdate.Description = task.Description;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(taskToUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Tasks", "UserStory", new { ID = userStoryId });
            }

            return RedirectToAction("Login", "Account");
           
        }

        public ActionResult Delete(int userStoryId, int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                var task = new TaskModel();
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    task.UserStory = session.Query<UserStoryModel>().Where(u => u.Id == userStoryId).FirstOrDefault();
                    task = session.Get<TaskModel>(id);
                }
                return View(task);
            }

            return RedirectToAction("Login", "Account");
           
        }



        [HttpPost]
        public ActionResult Delete(int userStoryId, TaskModel task)
        {
            if(User.Identity.IsAuthenticated)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(task);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Tasks", "UserStory", new { ID = userStoryId });
            }

            return RedirectToAction("Login", "Account");
           
        }
    }
}