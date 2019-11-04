using System;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepostory;

        public UserService(IUserRepository userRepository)
        {
            _userRepostory = userRepository;
        }

        public async Task GetAsync(string email)
        {
            var user = await _userRepostory.GetAsync(email);
            //return user DTO object
        }

        public async Task RegisterAsync(string email, string password, string name, string role)
        {
            var user = await _userRepostory.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, name, role);
            await _userRepostory.AddAsync(user);
        }
    }
}