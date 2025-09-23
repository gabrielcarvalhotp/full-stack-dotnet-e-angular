using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions;
using ProEvents.Infrastructure.Contexts;

namespace ProEvents.Infrastructure.Repositories
{
    public class BatchRepository : RepositoryBase<Batch>, IBatchRepository
    {
        public BatchRepository(AppDbContext context) : base(context) { }

        public async Task<Batch> GetBatchByIdAsync(int batchId, CancellationToken cancellationToken = default)
        {
            return await _context.Batchs
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == batchId, cancellationToken);
        }

        public async Task<IEnumerable<Batch>> GetBatchesByEventIdAsync(int eventId, CancellationToken cancellationToken = default)
        {
            return await _context.Batchs
                .AsNoTracking()
                .Where(b => b.EventId == eventId)
                .ToListAsync(cancellationToken);
        }
    }
}