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
    public class LoggedUserRepository: ILoggedUserRepository
    {

        private readonly IDirectorgDBContex _context;
        private readonly IMongoCollection<LoggedUser> _collection;

        public LoggedUserRepository(IDirectorgDBContex context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _collection = _context.loggedUsersCollection;
        }

        public async Task<IEnumerable<LoggedUser>> GetLoggedUsers()
        {
            return await _collection
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<LoggedUser> CheckIfLoginValid(string email, string password)
        {
            var builder = Builders<LoggedUser>.Filter;
            var filter = builder.Eq(p => p.Email, email) & builder.Eq(p => p.Password, password);

            return await _collection
                          .Find(filter)
                          .FirstOrDefaultAsync();
        }

        public async Task<LoggedUser> GetUserByEmail(string email)
        {
            return await _collection
                          .Find(u => u.Email == email)
                          .FirstOrDefaultAsync();
        }
        public async Task AddLoggedUser(LoggedUser loggedUser)
        {
            await _collection.InsertOneAsync(loggedUser);
        }

        public async Task<bool> DeleteLoggedUser(string idLoggedUser)
        {
            FilterDefinition<LoggedUser> filter = Builders<LoggedUser>.Filter.Eq(e => e.Id, idLoggedUser);
            DeleteResult deleteResult = await _collection
                                              .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
