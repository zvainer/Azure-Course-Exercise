using CodeTweet.IdentityDal.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeTweet.IdentityDal
{
    public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityContext()
            : base("CodeTweetIdentity")
        {
        }

        public static ApplicationIdentityContext Create()
        {
            return new ApplicationIdentityContext();
        }
    }
}