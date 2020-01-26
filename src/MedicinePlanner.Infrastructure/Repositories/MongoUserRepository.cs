using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;
using MongoDB.Driver;

namespace MedicinePlanner.Infrastructure.Repositories
{
    public class MongoUserRepository : IUserRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;
        public MongoUserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<User> GetAsync(Guid id)
            => await Users.Find(x => x.Id == id).SingleOrDefaultAsync();

        public async Task<User> GetAsync(string email) 
            => await Users.Find(x => x.Email == email).SingleOrDefaultAsync();
    
        public async Task<IEnumerable<User>> GetAllAsync()
            => await Users.AsQueryable().ToListAsync();
        public async Task AddAsync(User user)
            => await Users.InsertOneAsync(user);

        public async Task UpdateAsync(User user)
            => await Users.ReplaceOneAsync(x => x.Id == user.Id, user); 

        public async Task DeleteAsync(Guid id) {
            Console.WriteLine($"Deleting user with id: {id}");
            await Users.DeleteOneAsync(x => x.Id == id);
        }
        

        private IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}