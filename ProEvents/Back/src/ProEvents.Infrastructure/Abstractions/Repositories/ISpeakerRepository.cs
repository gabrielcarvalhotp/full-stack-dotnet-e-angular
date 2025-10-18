using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions.Repositories;

public interface ISpeakerRepository : IRepository<Speaker>
{
    public Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool includeEvent = false, CancellationToken cancellationToken = default);
    public Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvent = false, CancellationToken cancellationToken = default);
}