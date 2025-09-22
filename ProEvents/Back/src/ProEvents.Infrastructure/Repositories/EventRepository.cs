using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool includeSpeakers = false, CancellationToken cancellationToken = default)
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

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false, CancellationToken cancellationToken = default)
        {
            IQueryable<Event> query = _context.Events
                .AsNoTracking()
                .Include(e => e.Batchs)
                .Include(e => e.SocialMedias);

            if (includeSpeakers)
            {
                query = query
                    .Include(e => e.EventSpeakers)
                    .ThenInclude(es => es.Speaker);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);
        }
    }
}