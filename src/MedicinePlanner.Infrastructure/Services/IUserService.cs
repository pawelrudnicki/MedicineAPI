using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task <UserDto> GetAsync(string email);
        Task RegisterAsync(string email, string password, string name, string role);
        Task LoginAsync(string email, string password);
    }
}