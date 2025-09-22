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
    public class SocialMediaRepository : RepositoryBase, ISocialMediaRepository
    {
        public SocialMediaRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<SocialMedia>> GetSocialMediasByEventIdAsync(int eventId, CancellationToken cancellationToken = default)
        {
            return await _context.SocialMedias.Where(sm => sm.EventId == eventId).ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<SocialMedia>> GetSocialMediasBySpeakerIdAsync(int speakerId, CancellationToken cancellationToken = default)
        {
            return await _context.SocialMedias.Where(sm => sm.SpeakerId == speakerId).ToListAsync(cancellationToken);
        }
    }
}