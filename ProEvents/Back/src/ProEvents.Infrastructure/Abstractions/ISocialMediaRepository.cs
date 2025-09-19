using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface ISocialMediaRepository
    {
        Task<IEnumerable<SocialMedia>> GetSocialMediasByEventIdAsync(int eventId);
        Task<IEnumerable<SocialMedia>> GetSocialMediasBySpeakerIdAsync(int speakerId);
    }
}