using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IMedicineService : IService
    {
        Task<Medicine> GetAsync(Guid id);
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}