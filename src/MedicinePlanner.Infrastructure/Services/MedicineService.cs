using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;

namespace MedicinePlanner.Infrastructure.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public async Task<Medicine> GetAsync(Guid id)
            => await _medicineRepository.GetAsync(id);

        public async Task<IEnumerable<Medicine>> GetAllAsync()
            => await _medicineRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id)
            => await _medicineRepository.DeleteAsync(id);
    }
}