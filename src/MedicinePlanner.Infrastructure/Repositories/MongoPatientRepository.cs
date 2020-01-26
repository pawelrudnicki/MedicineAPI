using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;
using MongoDB.Driver;

namespace MedicinePlanner.Infrastructure.Repositories
{
    public class MongoPatientRepository : IPatientRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public MongoPatientRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Patient> GetAsync(Guid userId)
            => await Patients.Find(x => x.UserId == userId).SingleOrDefaultAsync();

        public async Task<IEnumerable<Patient>> GetAllAsync()
            => await Patients.AsQueryable().ToListAsync();

        public async Task AddAsync(Patient patient)
            => await Patients.InsertOneAsync(patient);

        public async Task UpdateAsync(Patient patient)
            => await Patients.ReplaceOneAsync(x => x.UserId == patient.UserId, patient);

        public async Task DeleteAsync(Patient patient)
            => await Patients.DeleteOneAsync(x => x.UserId == patient.UserId);

        private IMongoCollection<Patient> Patients => _database.GetCollection<Patient>("Patients");
    }
}