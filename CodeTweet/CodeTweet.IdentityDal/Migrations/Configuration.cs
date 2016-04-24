using System.Data.Entity.Migrations;

namespace CodeTweet.IdentityDal.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationIdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(ApplicationIdentityContext context)
        {
        }
    }
}
