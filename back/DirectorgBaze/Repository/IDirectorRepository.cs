using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Models;

namespace DirectorgBaze.Repository
{
    public interface IDirectorRepository
    {
        Task<Director> AddDirector(Director director);
        Task<Director> GetDirectorByEmail(string email);
        Task<Director> GetDirectorById(string id);
        Task<Director> UpdateDirector(Director director);
        Task<IEnumerable<Director>> GetAllDirectors();
    }
}
