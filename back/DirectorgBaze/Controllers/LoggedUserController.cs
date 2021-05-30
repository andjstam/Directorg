﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Repository;
using System.Net;

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
        [ProducesResponseType(typeof(IEnumerable<LoggedUserController>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LoggedUserController>>> GetProducts()
        {
            var products = await _repository.GetLoggedUsers();
            return Ok(products);
        }
    }
}
