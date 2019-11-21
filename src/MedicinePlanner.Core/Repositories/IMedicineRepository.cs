using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;

namespace MedicinePlanner.Core.Repositories
{
    public interface IMedicineRepository : IRepository
    {
        Task<Medicine> GetAsync(Guid id);
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task AddAsync(Medicine medicine);
        Task UpdateAsync(Medicine medicine);
        Task DeleteAsync(Guid id);
    }
}