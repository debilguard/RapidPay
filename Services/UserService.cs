using RapidPay.Repositories.Interfaces;
using RapidPay.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository; 
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> IsAuthenticated(string username, string password)
        {
            return await _userRepository.IsAuthenticated(username, password);
        }
    }
}
