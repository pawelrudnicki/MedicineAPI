using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;

namespace MedicinePlanner.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private static readonly ISet<Patient> _patients = new HashSet<Patient>();
        
        public async Task<Patient> GetAsync(Guid userId)
            => await Task.FromResult(_patients.SingleOrDefault(x => x.UserId == userId));

        public async Task<IEnumerable<Patient>> GetAllAsync()
            => await Task.FromResult(_patients);

        public async Task AddAsync(Patient patient)
        {
            _patients.Add(patient);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Patient patient)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Patient patient)
        {
            _patients.Remove(patient);
            await Task.CompletedTask;
        }
    }
}