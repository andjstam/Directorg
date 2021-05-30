using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.DBContext;
using DirectorgBaze.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
//using MongoDB.Driver.Builders;

namespace DirectorgBaze.Repository
{
    public class LoggedUserRepository: ILoggedUserRepository
    {

        private readonly IDirectorgDBContex _context;

        public LoggedUserRepository(IDirectorgDBContex context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<LoggedUser>> GetLoggedUsers()
        {
            return await _context
                            .loggedUsersCollection
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<LoggedUser> CheckIfLoginValid(string email, string password)
        {
            //FilterDefinition<LoggedUser> logInFilter = $"{{ Email:  {email},  Password: { password }}}";
            var builder = Builders<LoggedUser>.Filter;
            var filter = builder.Eq(p => p.Email, email) & builder.Eq(p => p.Password, password);

            return await _context
                          .loggedUsersCollection
                          .Find(filter)
                          .FirstOrDefaultAsync();

        }
    }
}
