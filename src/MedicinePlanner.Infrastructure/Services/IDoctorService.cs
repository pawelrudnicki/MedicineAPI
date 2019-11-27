using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IDoctorService : IService
    {
        Task<DoctorDto> GetAsync(Guid userId); //doctor details dto - lista userów!
        Task<IEnumerable<DoctorDto>> BrowseAsync();
        Task CreateAsync(Guid userId, string specialization);
        Task DeleteAsync(Guid userId);
    }
}