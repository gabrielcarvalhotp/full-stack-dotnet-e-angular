using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface ISocialMediaRepository : IRepository
    {
        Task<IEnumerable<SocialMedia>> GetSocialMediasByEventIdAsync(int eventId, CancellationToken cancellationToken = default);
        Task<IEnumerable<SocialMedia>> GetSocialMediasBySpeakerIdAsync(int speakerId, CancellationToken cancellationToken = default);
    }
}