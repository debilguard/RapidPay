using System.Threading.Tasks;

namespace RapidPay.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> IsAuthenticated(string username, string password);
    }
}
