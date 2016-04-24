using System.Data.Entity;
using System.Web;
using CodeTweet.IdentityDal;
using CodeTweet.IdentityDal.Migrations;
using CodeTweet.Web.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject.Modules;

namespace CodeTweet.Web.Modules
{
    public class ApplicationIdentityModule : NinjectModule
    {
        static ApplicationIdentityModule()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationIdentityContext, Configuration>());
        }

        public override void Load()
        {
            Bind<ApplicationIdentityContext>().ToMethod(context => HttpContext.Current.GetOwinContext().Get<ApplicationIdentityContext>());
            Bind<ApplicationUserManager>().ToMethod(context => HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>());
            Bind<ApplicationSignInManager>().ToMethod(context => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
        }
    }
}