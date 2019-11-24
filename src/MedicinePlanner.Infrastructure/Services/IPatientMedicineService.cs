using System;
using System.Threading.Tasks;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IPatientMedicineService : IService
    {
        Task AddAsync(Guid userId, string name, decimal price, double dosage, string accessibility);
        Task DeleteAsync(Guid userId, string name);
    }
}