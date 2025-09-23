using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface IBatchRepository : IRepository<Batch>
    {
        public Task<Batch> GetBatchByIdAsync(int batchId, CancellationToken cancellationToken = default);
        public Task<IEnumerable<Batch>> GetBatchesByEventIdAsync(int eventId, CancellationToken cancellationToken = default);
    }
}