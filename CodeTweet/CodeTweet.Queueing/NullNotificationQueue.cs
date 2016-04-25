using System;
using System.Threading.Tasks;
using CodeTweet.DomainModel;

namespace CodeTweet.Queueing
{
    public class NullNotificationQueue : INotificationEnqueue, INotificationDequeue
    {
        Task INotificationEnqueue.EnqueueNotificationAsync(Tweet tweet)
        {
            return Task.FromResult((object) null);
        }

        Tweet[] INotificationDequeue.Dequeue()
        {
            return new Tweet[0];
        }

        void IDisposable.Dispose()
        {
        }
    }
}