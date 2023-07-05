using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TestFluent.Models.Identity;
using System.Web;
using System.Web.Mvc;
using TestFluent.Models;

namespace TestFluent.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SignInManager.PasswordSignIn(model.UserName, model.Password, false, false);
                if (result == SignInStatus.Success)
                {

                    return RedirectToAction("Index", "UserStory");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.UserName };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    SignInManager.SignIn(user, false, false);
                    using (var session = NHibernateHelper.OpenSession())
                    {
                        using(var transcation = session.BeginTransaction())
                        {
                            session.Save(user);
                            transcation.Commit();
                        }
                    }
                    return RedirectToAction("Index", "UserStory");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }
        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }
    }
}