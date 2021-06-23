using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DirectorgBaze.Repository;
using DirectorgBaze.Models;

namespace DirectorgBaze.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repository;

        public EventController(IEventRepository repo)
        {
            _repository = repo;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Event), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Event>> AddEvent([FromBody] Event ev)
        {
            return Ok(await _repository.AddEvent(ev));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteEvent(string idEvent)
        {
            return Ok(await _repository.DeleteEvent(idEvent));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Event>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            return Ok(await _repository.GetAllEvents());
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Event>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Event>> GetEventsByDirectorsId([FromQuery] string directorsId)
        {
            return Ok(await _repository.GetEventsByDirectorsId(directorsId));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Event), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Event>> UpdateEvent([FromBody] Event newEvent)
        {
            return Ok(await _repository.UpdateEvent(newEvent));
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventSignedEmployed), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EventSignedEmployed>> AddEventSigned([FromBody] EventSignedEmployed ev)
        {
            return Ok(await _repository.AddEventSigned(ev));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteEventSigned(string id)
        {
            return Ok(await _repository.DeleteEventSigned(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventSignedEmployed>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EventSignedEmployed>>> GetAllEventsSigned()
        {
            return Ok(await _repository.GetAllEventsSigned());
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventSignedEmployed>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EventSignedEmployed>>> GetAllEventsSignedForUser(string userId)
        {
            return Ok(await _repository.GetAllEventsSignedForUser(userId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventSignedEmployed), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EventSignedEmployed>> AddEventEmployed([FromBody] EventSignedEmployed ev)
        {
            return Ok(await _repository.AddEventEmplyed(ev));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteEventEmployed(string id)
        {
            return Ok(await _repository.DeleteEventEmplyed(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventSignedEmployed>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EventSignedEmployed>>> GetAllEventsEmployed()
        {
            return Ok(await _repository.GetAllEventsEmployed());
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventSignedEmployed>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EventSignedEmployed>>> GetAllEventsEmployedForUser(string userId)
        {
            return Ok(await _repository.GetAllEventsSignedForUser(userId));
        }
    }
}
