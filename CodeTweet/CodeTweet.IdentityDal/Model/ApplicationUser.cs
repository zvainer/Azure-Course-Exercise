using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeTweet.IdentityDal.Model
{
    public class ApplicationUser : IdentityUser
    {
        public bool Notifications { get; set; }
    }
}