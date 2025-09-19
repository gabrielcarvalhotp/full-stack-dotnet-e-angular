using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface IBatchRepository : IRepository
    {
        public Task<Batch> GetBatchByIdAsync(int batchId);
        public Task<IEnumerable<Batch>> GetBatchesByEventIdAsync(int eventId);
    }
}