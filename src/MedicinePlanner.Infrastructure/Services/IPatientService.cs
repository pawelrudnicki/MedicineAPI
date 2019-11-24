using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IPatientService : IService
    {
        Task<Patient> GetAsync(Guid userId);
        Task<IEnumerable<Patient>> BrowseAsync();
        Task CreateAsync(Guid userId);
        Task DeleteAsync(Guid userId);
    }
}