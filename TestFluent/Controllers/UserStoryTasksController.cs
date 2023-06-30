using NHibernate;
using System.Linq;
using System.Web.Mvc;
using TestFluent.Models;
using TestFluent.Models.UserStoryTasks;

namespace TestFluent.Controllers
{
    public class UserStoryTasksController : Controller
    {
        // GET: UserStoryTasks
        public ActionResult Index()
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                var userStoryTasks = session.Query<UserStoryTasks>().ToList();
                return View(userStoryTasks);

            }
        }
    }
}