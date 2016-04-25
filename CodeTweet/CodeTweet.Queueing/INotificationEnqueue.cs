using System.Threading.Tasks;
using CodeTweet.DomainModel;

namespace CodeTweet.Queueing
{
    public interface INotificationEnqueue
    {
        Task EnqueueNotificationAsync(Tweet tweet);
    }
}