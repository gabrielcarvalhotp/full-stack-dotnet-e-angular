using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEvents.Infrastructure.Contexts;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EventsController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public IActionResult Get() =>
            Ok(_context.Events.ToList());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await _context.Events.FirstOrDefaultAsync(e => e.Id == id));
    }
}