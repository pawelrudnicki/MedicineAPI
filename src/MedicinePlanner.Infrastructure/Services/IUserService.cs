using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task <UserDto> GetAsync(string email);
        Task <IEnumerable<UserDto>> GetAllAsync();
        Task RegisterAsync(Guid userId, string email, string password, string name, string role);
        Task LoginAsync(string email, string password);
        Task DeleteAsync(Guid userId);
    }
}