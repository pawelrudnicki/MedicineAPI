using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IPatientService : IService
    {
        Task<PatientDetailsDto> GetAsync(Guid userId);
        Task<IEnumerable<PatientDto>> BrowseAsync();
        Task CreateAsync(Guid userId, int age, string bloodType, double weight, double height);
        Task DeleteAsync(Guid userId);
    }
}