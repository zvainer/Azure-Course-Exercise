using System.Data.Entity;
using CodeTweet.TweetsDal.Model;

namespace CodeTweet.TweetsDal
{
    public class TweetsContext : DbContext
    {
        public TweetsContext()
            : base("CodeTweet")
        {
        }

        public DbSet<TweetEntity> Tweets { get; set; }
    }
}