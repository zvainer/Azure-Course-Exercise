using System.Configuration;
using CodeTweet.Queueing;
using CodeTweet.Queueing.ZeroMQ;
using Ninject.Modules;

namespace CodeTweet.Web.Modules
{
    public class QueueingModule : NinjectModule
    {
        public override void Load()
        {
            bool enableNotifications = bool.Parse(ConfigurationManager.AppSettings["EnableNotifications"]);

            if (enableNotifications)
            {
                Bind<INotificationEnqueue>().To<ZeroNotificationEnqueue>().InSingletonScope();
            }
            else
            {
                Bind<INotificationEnqueue>().To<NullNotificationQueue>();
            }
        }
    }
}