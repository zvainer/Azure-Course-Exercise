using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeTweet.DomainModel;
using CodeTweet.TweetsDal.Model;

namespace CodeTweet.TweetsDal
{
    public class TweetsRepository : ITweetsRepository
    {
        private static readonly IMapper Mapper = CreateMapper();
        private readonly TweetsContext _context;

        public TweetsRepository(TweetsContext context)
        {
            _context = context;
        }

        public Task<Tweet[]> GetAllTweetsAsync()
        {
            return _context.Tweets.OrderByDescending(t => t.Timestamp).ProjectTo<Tweet>(Mapper.ConfigurationProvider).ToArrayAsync();
        }

        public Task<Tweet[]> GetTweets(string userName)
        {
            return _context.Tweets.Where(t => t.Author == userName).OrderByDescending(t => t.Timestamp).ProjectTo<Tweet>(Mapper.ConfigurationProvider).ToArrayAsync();
        }

        public Task CreateTweetAsync(Tweet tweet)
        {
            var tweetEntity = Mapper.Map<TweetEntity>(tweet);
            _context.Tweets.Add(tweetEntity);
            return _context.SaveChangesAsync();
        }

        private static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<TweetEntity, Tweet>().ReverseMap());
            return mapperConfiguration.CreateMapper();
        }
    }
}