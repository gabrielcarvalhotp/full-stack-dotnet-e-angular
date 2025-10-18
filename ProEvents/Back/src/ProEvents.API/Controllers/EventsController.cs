using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEvents.Application.Abstractions.Services;
using ProEvents.Domain.Entities;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var @event = await _eventService.GetEventByIdAsync(id);
            return Ok(@event);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event @event)
        {
            var newEvent = await _eventService.AddEventAsync(@event);
            return Ok(newEvent);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Event @event)
        {
            var updatedEvent = await _eventService.UpdateEventAsync(id, @event);
            return Ok(updatedEvent);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}