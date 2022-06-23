using System.Threading.Tasks;

namespace RapidPay.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> IsAuthenticated(string username, string password);
    }
}
