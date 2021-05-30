using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DirectorgBaze.Repository;
using System.Net;
using DirectorgBaze.Models;

namespace DirectorgBaze.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
       
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> AddUser([FromBody]User user)
        {
            return Ok(await _repository.AddUser(user));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return Ok(await _repository.GetAllUsers());
        }
            
        [HttpGet]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> GetUserByEmail([FromRoute]string email)
        {
            return Ok(await _repository.GetUserByEmail(email));
        }

        [HttpGet]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> GetUserById([FromRoute] string id)
        {
            return Ok(await _repository.GetUserById(id));
        }

        [HttpPut]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            return Ok(await _repository.UpdateUser(user));
        }
    }
    
}