using System.Data.Entity.Migrations;

namespace CodeTweet.TweetsDal.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TweetsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(TweetsContext context)
        {
        }
    }
}
