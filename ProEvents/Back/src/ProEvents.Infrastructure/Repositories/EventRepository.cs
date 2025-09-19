using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions;
using ProEvents.Infrastructure.Context;

namespace ProEvents.Infrastructure.Repositories
{
    public class EventRepository : ReposiroryBase, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .AsNoTracking()
                .Include(e => e.Batchs)
                .Include(e => e.SocialMedias)
                .OrderBy(e => e.Id);

            if (includeSpeakers)
            {
                query = query
                    .Include(e => e.EventSpeakers)
                    .ThenInclude(es => es.Speaker);
            }

            return await query.ToListAsync();
        }

        public Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            return includeSpeakers ?
                _context.Events
                    .Include(e => e.EventSpeakers)
                    .ThenInclude(es => es.Speaker)
                    .FirstOrDefaultAsync(e => e.Id == eventId) :
                _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
        }
    }
}