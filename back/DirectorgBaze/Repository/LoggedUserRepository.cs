using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.DBContext;
using DirectorgBaze.Models;
using MongoDB.Driver;
using MongoDB.Bson;

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

        /*public async Task<Product> GetProduct(string id)
        {
            return await _context
                           .Products
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name); return await _context
                             .Products
                             .Find(filter)
                             .ToListAsync();
        }*/
    }
}
