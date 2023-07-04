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
        // GET: Task
        public ActionResult Index(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var task = session.Get<TaskModel>(id);
                return View(task);
            }
        }

        public ActionResult Create(int userStoryId)
        {
            var task = new TaskModel();
            using(ISession session = NHibernateHelper.OpenSession())
            {
                task.UserStory = session.Query<UserStoryModel>().Where(u => u.Id == userStoryId).FirstOrDefault();
            }
            return View(task);
        }


        [HttpPost]
        public ActionResult Create(int userStoryId, TaskModel task)
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

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var task = session.Get<TaskModel>(id);
                return View(task);
            }
        }


        [HttpPost]
        public ActionResult Edit(int id, TaskModel task)
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
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var task = session.Get<TaskModel>(id);
                return View(task);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, TaskModel task)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(task);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");

        }
    }
}