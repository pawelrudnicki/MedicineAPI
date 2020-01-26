using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;
using MongoDB.Driver;

namespace MedicinePlanner.Infrastructure.Repositories
{
    public class MongoDoctorRepository : IDoctorRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public MongoDoctorRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Doctor> GetAsync(Guid userId)
            => await Doctors.Find(x => x.UserId == userId).SingleOrDefaultAsync();

        public async Task<IEnumerable<Doctor>> GetAllAsync()
            => await Doctors.AsQueryable().ToListAsync();

        public async Task AddAsync(Doctor doctor)
            => await Doctors.InsertOneAsync(doctor);

        public async Task UpdateAsync(Doctor doctor)
            => await Doctors.ReplaceOneAsync(x => x.UserId == doctor.UserId, doctor)

        public async Task DeleteAsync(Doctor doctor)
            => await Doctors.DeleteOneAsync(x => x.UserId == doctor.UserId);

        private IMongoCollection<Doctor> Doctors => _database.GetCollection<Doctor>("Doctors");
    }
}