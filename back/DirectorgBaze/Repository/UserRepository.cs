using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.DBContext;
using DirectorgBaze.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace DirectorgBaze.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDirectorgDBContex _context;
        public UserRepository(IDirectorgDBContex context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<User> AddUser(User user)
        {
            await _context
                .usersCollection
                .InsertOneAsync(user);
            return user;
        }

        public async Task<bool> DeleteUser(string idUser)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(e => e.Id, idUser);
            DeleteResult deleteResult = await _context.usersCollection
                                                .DeleteOneAsync(filter);
     
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context
                .usersCollection
                .Find(p => true)
                .ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq(u => u.Email, email);

            return await _context
                          .usersCollection
                          .Find(filter)
                          .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq(u => u.Id, id);

            return await _context
                          .usersCollection
                          .Find(filter)
                          .FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq(u => u.Id, user.Id);

            return await _context
                .usersCollection
                .FindOneAndReplaceAsync(filter, user);
        }
    }
}
