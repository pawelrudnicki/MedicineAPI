using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task LoginAsync(string email, string password)
        {
            Console.WriteLine($"user email param: `{email}`");
            Console.WriteLine($"user password param: `{password}`");
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            return;
            // var hash = _encrypter.GetHash(password, user.Salt);
            // if (user.Password == hash)
            // {
            //     return;
            // }
            // throw new Exception("Invalid credentials.");
        }

        public async Task RegisterAsync(Guid userId, string email, string password, string name, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, password, hash, name, role);
            await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(Guid userId) {
            Console.WriteLine($"User service deleting user with id: {userId}...");
            await _userRepository.DeleteAsync(userId);
        }
    }
}