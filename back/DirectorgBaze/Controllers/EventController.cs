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
    public class EventController
    {
        private readonly IEventRepository _repository;

    }
}
