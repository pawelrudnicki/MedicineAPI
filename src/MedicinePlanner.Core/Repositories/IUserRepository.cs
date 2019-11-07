using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;

namespace MedicinePlanner.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
         Task<User> GetAsync(Guid id);
         Task<User> GetAsync(string email);
         Task<IEnumerable<User>> GetAllAsync();
         Task AddAsync(User user);
         Task UpdateAsync(User user);
         Task DeleteAsync(Guid id);
    }
}