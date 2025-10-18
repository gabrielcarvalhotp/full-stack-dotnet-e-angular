using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions.Repositories;
using ProEvents.Infrastructure.Contexts;

namespace ProEvents.Infrastructure.Repositories
{
    public class SpeakerRepository : RepositoryBase<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool includeEvent = false, CancellationToken cancellationToken = default)
        {
            IQueryable<Speaker> query = _context.Speakers
                .AsNoTracking()
                .Include(s => s.SocialMedias);

            if (includeEvent)
            {
                query = query
                    .Include(s => s.EventSpeakers)
                    .ThenInclude(es => es.Event);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvent = false, CancellationToken cancellationToken = default)
        {
            IQueryable<Speaker> query = _context.Speakers
                .AsNoTracking()
                .Include(s => s.SocialMedias);

            if (includeEvent)
            {
                query = query
                    .Include(s => s.EventSpeakers)
                    .ThenInclude(es => es.Event);
            }

            return query.FirstOrDefaultAsync(s => s.Id == speakerId, cancellationToken);
        }
    }
}