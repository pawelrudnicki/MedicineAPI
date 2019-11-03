using System;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;

namespace MedicinePlanner.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepostory;

        public UserService(IUserRepository userRepository)
        {
            _userRepostory = userRepository;
        }

        public async Task RegisterAsync(Guid userId, string email, string password, string salt, string name, string role)
        {
            var user = await _userRepostory.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }
            user = new User(userId, email, password, salt, name, role);
            await _userRepostory.AddAsync(user);
        }
    }
}