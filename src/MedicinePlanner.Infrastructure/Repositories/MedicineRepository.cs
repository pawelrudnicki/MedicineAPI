using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;

namespace MedicinePlanner.Infrastructure.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private static readonly ISet<Medicine> _medicines = new HashSet<Medicine>();

        public async Task<Medicine> GetAsync(Guid id)
            => await Task.FromResult(_medicines.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Medicine>> GetAllAsync()
            => await Task.FromResult(_medicines.AsEnumerable());

        public async Task AddAsync(Medicine medicine)
        {
            _medicines.Add(medicine);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Medicine medicine)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var medicine = await GetAsync(id);
            _medicines.Remove(medicine);
            await Task.CompletedTask;
        }
    }
}