using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Models;

namespace DirectorgBaze.Repository
{
    public interface ILoggedUserRepository
    {
        Task<IEnumerable<LoggedUser>> GetLoggedUsers();  //GetAllUsers

        Task<LoggedUser> CheckIfLoginValid(string email, string password); //CheckIfUserValid

        Task<LoggedUser> GetUserByEmail(string email);

        Task AddLoggedUser(LoggedUser loggedUser);
        Task<bool> DeleteLoggedUser(string idLoggedUser);

        //Task<LoggedUser> GetLoggedUser(string id);
        //Task<LoggedUser> GetLoggedUserByEmail(string email);

        /*Task<IEnumerable<LoggedUser>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName); Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);*/
    }
}
