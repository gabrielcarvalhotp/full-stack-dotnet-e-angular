using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface IEventRepository : IRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}