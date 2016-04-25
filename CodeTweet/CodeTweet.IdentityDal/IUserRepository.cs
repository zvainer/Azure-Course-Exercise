using System.Threading.Tasks;

namespace CodeTweet.IdentityDal
{
    public interface IUserRepository
    {
        Task<string[]> GetUsersWithNotificationsAsync();
    }
}