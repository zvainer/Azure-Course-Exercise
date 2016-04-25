using CodeTweet.Notifications;
using Topshelf;

namespace CodeTweet.Worker
{
    class Program
    {
        static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<NotificationService>(s =>
                {
                    s.ConstructUsing(name => new NotificationService());
                    s.WhenStarted(ns => ns.Start());
                    s.WhenStopped(ns => ns.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("CodeTweet Notification Service");
                x.SetDisplayName("CodeTweet");
                x.SetServiceName("CodeTweet");
            });
        }
    }
}
