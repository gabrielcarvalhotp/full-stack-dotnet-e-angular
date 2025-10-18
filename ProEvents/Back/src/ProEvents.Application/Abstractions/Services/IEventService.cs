using ProEvents.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProEvents.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task<Event> AddEventAsync(Event @event);
        Task<Event> UpdateEventAsync(int eventId, Event @event);
        Task<bool> DeleteEventAsync(int eventId);
        Task<IEnumerable<Event>> GetAllEventsAsync(bool includeSpeakers = false, CancellationToken cancellationToken = default);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false, CancellationToken cancellationToken = default);
    }
}