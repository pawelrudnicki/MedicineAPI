using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;

namespace MedicinePlanner.Core.Repositories
{
    public interface IPatientRepository : IRepository
    {
        Task<Patient> GetAsync(Guid userId);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
    }
}