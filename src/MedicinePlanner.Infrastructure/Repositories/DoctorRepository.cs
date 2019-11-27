using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;

namespace MedicinePlanner.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private static readonly ISet<Doctor> _doctors = new HashSet<Doctor>();
        
        public async Task<Doctor> GetAsync(Guid userId)
            => await Task.FromResult(_doctors.SingleOrDefault(x => x.UserId == userId));

        public async Task<IEnumerable<Doctor>> GetAllAsync()
            => await Task.FromResult(_doctors);

        public async Task AddAsync(Doctor doctor)
        {
            _doctors.Add(doctor);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            _doctors.Remove(doctor);
            await Task.CompletedTask;
        }
    }
}