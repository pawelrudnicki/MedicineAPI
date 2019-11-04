using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IUserService
    {
        Task GetAsync(string email);
        Task RegisterAsync(string email, string password, string name, string role);
    }
}