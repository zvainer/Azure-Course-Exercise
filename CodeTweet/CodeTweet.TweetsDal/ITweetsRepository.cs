using System.Threading.Tasks;
using CodeTweet.DomainModel;

namespace CodeTweet.TweetsDal
{
    public interface ITweetsRepository
    {
        Task<Tweet[]> GetAllTweetsAsync();
        Task<Tweet[]> GetTweets(string userName);
        Task CreateTweetAsync(Tweet tweet);
    }
}