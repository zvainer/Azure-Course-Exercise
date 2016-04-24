using System.Data.Entity;
using CodeTweet.TweetsDal;
using CodeTweet.TweetsDal.Migrations;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CodeTweet.Web.Modules
{
    public class TweetDalModule : NinjectModule
    {
        static TweetDalModule()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TweetsContext, Configuration>());
        }

        public override void Load()
        {
            Bind<TweetsContext>().ToSelf().InRequestScope();
            Bind<ITweetsRepository>().To<TweetsRepository>();
        }
    }
}