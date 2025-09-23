using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProEvents.Application.Abstractions;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions;

namespace ProEvents.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<EventService> _logger;
        public EventService(IEventRepository eventRepository, ILogger<EventService> logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;
        }

        public async Task<Event> AddEventAsync(Event @event)
        {
            await _eventRepository.AddAsync(@event);
            await _eventRepository.SaveChangesAsync();
            return @event;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var @event = await _eventRepository.GetEventByIdAsync(eventId);
            if (@event == null) return false;
            _eventRepository.Delete(@event);
            return await _eventRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool includeSpeakers = false, CancellationToken cancellationToken = default)
        {
            var events = await _eventRepository.GetAllEventsAsync(includeSpeakers, cancellationToken);
            return events;
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false, CancellationToken cancellationToken = default)
        {
            var @event = await _eventRepository.GetEventByIdAsync(eventId, includeSpeakers, cancellationToken);
            return @event;
        }

        public async Task<Event> UpdateEventAsync(int eventId, Event @event)
        {
            var myEvent = await _eventRepository.GetEventByIdAsync(eventId);
            if (myEvent == null)
            {
                _logger.LogError($"EventService.UpdateEventAsync with event Id: {eventId} not found");
                return null;
            }

            myEvent.Location = @event.Location;
            myEvent.EventDate = @event.EventDate;
            myEvent.Theme = @event.Theme;
            myEvent.NumberPeople = @event.NumberPeople;
            myEvent.ImageURL = @event.ImageURL;
            myEvent.Phone = @event.Phone;
            myEvent.Email = @event.Email;
            
            _eventRepository.Update(myEvent);
            await _eventRepository.SaveChangesAsync();
            return await _eventRepository.GetEventByIdAsync(eventId);
        }

    }
}