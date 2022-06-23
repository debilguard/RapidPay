using RapidPay.Database;
using RapidPay.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RapidPayContext _context;
        public UserRepository(RapidPayContext context)
        {
            _context = context;
        }
        public async Task<bool> IsAuthenticated(string username, string password)
        {
            return await ValidateUser(username, password);
        }

        private Task<bool> ValidateUser(string username, string password)
        {
            bool isValid = _context.User
                       .Where(u => u.UserName == username && u.Password == password)
                       .Any();

            return Task.FromResult(isValid);
        }
    }
}
