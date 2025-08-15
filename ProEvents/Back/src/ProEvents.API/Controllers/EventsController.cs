using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProEvents.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        public EventsController()
        {
        }

        [HttpGet]
        public IActionResult Get() => Ok("Sucess");
    }
}