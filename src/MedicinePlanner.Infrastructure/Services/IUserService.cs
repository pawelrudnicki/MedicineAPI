using System;
using System.Threading.Tasks;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IUserService
    {
         Task RegisterAsync(Guid userId, string email, string password, string salt, string name, string role);
    }
}