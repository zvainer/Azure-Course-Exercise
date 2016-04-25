using System;
using System.Threading;
using System.Threading.Tasks;
using CodeTweet.DomainModel;
using CodeTweet.IdentityDal;
using CodeTweet.Queueing;
using CodeTweet.Queueing.ZeroMQ;
using NLog;

namespace CodeTweet.Notifications
{
    public class NotificationService
    {
        private readonly INotificationDequeue _dequeue = new ZeroNotificationDequeue();
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        private Task _task;

        public void Start()
        {
            var cancellationToken = _cts.Token;
            _task = Task.Factory.StartNew(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Tweet[] tweets = _dequeue.Dequeue();
                    await OnTweets(tweets);
                }
            }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Current);
        }

        public void Stop()
        {
            _cts.Cancel();
            _task.Wait();
            _dequeue.Dispose();
        }

        private async Task OnTweets(Tweet[] tweets)
        {
            if (tweets.Length == 0)
                return;

            try
            {
                using (var context = new ApplicationIdentityContext())
                {
                    var repository = new UserRepository(context);
                    var users = await repository.GetUsersWithNotificationsAsync(); // Can be cached
                    foreach (var tweet in tweets)
                        foreach (var user in users)
                        {
                            SendNotification(tweet, user);
                        }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occured while processing recieved tweets");
            }
        }

        private void SendNotification(Tweet tweet, string user)
        {
            _logger.Info($"Sent notification to user '{user}'. Tweet text: '{tweet.Text}'");
        }
    }
}