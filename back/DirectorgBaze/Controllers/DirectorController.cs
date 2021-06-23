using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DirectorgBaze.Repository;
using System.Threading.Tasks;
using DirectorgBaze.Models;
using System.Net;

namespace DirectorgBaze.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;
        public DirectorController(IDirectorRepository directorRepo)
        {
            this._directorRepository = directorRepo;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Director), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> AddDirector([FromBody] Director director)
        {
            return Ok(await _directorRepository.AddDirector(director));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Director>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Director>>> GetAllDirectors()
        {
            return Ok(await _directorRepository.GetAllDirectors());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Director), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Director>> GetDirectorByEmail([FromQuery] string email)
        {
            return Ok(await _directorRepository.GetDirectorByEmail(email));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Director), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Director>> GetDirectorById([FromQuery] string id)
        {
            return Ok(await _directorRepository.GetDirectorById(id));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Director), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Director>> UpdateDirector([FromBody] Director director)
        {
            return Ok(await _directorRepository.UpdateDirector(director));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteEventEmployed(string id)
        {
            return Ok(await _directorRepository.DeleteDirector(id));
        }
    }
}
