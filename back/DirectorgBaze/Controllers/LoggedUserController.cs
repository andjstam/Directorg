using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Repository;
using DirectorgBaze.Models;

namespace DirectorgBaze.Controllers
{ 
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoggedUserController : ControllerBase
    {
        private readonly ILoggedUserRepository _repository;

        public LoggedUserController(ILoggedUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LoggedUser>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LoggedUser>>> GetLoggedUsers()
        {
            var products = await _repository.GetLoggedUsers();
            return Ok(products);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LoggedUser>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LoggedUser>>> CheckIfLoginValid([FromQuery(Name = "email")] string email, [FromQuery(Name = "password")] string password) //checkIfUserValid iz frontend projekta
        {
            var products = await _repository.CheckIfLoginValid(email, password);
            return Ok(products);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LoggedUser>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LoggedUser>>> GetUserByEmail(string email)
        {
            var products = await _repository.GetUserByEmail(email);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<LoggedUser>> AddLoggedUser([FromBody] LoggedUser user)
        {
            await _repository.AddLoggedUser(user);
            return new OkObjectResult(user);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteLoggedUser(string id)
        {
            return Ok(await _repository.DeleteLoggedUser(id));
        }


    }
}
