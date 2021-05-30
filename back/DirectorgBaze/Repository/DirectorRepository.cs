using DirectorgBaze.DBContext;
using DirectorgBaze.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorgBaze.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly IDirectorgDBContex _context;
        public DirectorRepository(IDirectorgDBContex context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Director> AddDirector(Director director)
        {
            await _context
                .directorsCollection
                .InsertOneAsync(director);
            return director;
        }

        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            return await _context
                .directorsCollection
                .Find(p => true)
                .ToListAsync();
        }

        public async Task<Director> GetDirectorByEmail(string email)
        {
            var builder = Builders<Director>.Filter;
            var filter = builder.Eq(u => u.Email, email);

            return await _context
                          .directorsCollection
                          .Find(filter)
                          .FirstOrDefaultAsync();
        }

        public async Task<Director> GetDirectorById(string id)
        {
            var builder = Builders<Director>.Filter;
            var filter = builder.Eq(u => u.Id, id);

            return await _context
                          .directorsCollection
                          .Find(filter)
                          .FirstOrDefaultAsync();
        }

        public async Task<Director> UpdateDirector(Director director)
        {
            var builder = Builders<Director>.Filter;
            var filter = builder.Eq(u => u.Id, director.Id);

            return await _context
                .directorsCollection
                .FindOneAndReplaceAsync(filter, director);
        }
    }
}
