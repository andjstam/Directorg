using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Models;

namespace DirectorgBaze.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(string id);
        Task<User> UpdateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> DeleteUser(string idUser);
    }
}
