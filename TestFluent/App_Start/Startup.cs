﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using TestFluent;
using TestFluent.Models;
using TestFluent.Models.Identity;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace TestFluent    
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new UserManager(new DatabaseContext().Users));
            app.CreatePerOwinContext<SignInManager>((options, context) => new SignInManager(context.GetUserManager<UserManager>(), context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}
