using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface ISpeakerRepository : IRepository
    {
        public Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool includeEvent = false);
        public Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvent = false);
    }
}