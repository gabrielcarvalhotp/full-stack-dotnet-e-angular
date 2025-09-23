using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Contexts;

namespace ProEvents.Infrastructure.Abstractions
{
    public abstract class RepositoryBase : IRepository
    {
        protected readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : Entity
        {
            await _context.AddAsync(entity, cancellationToken);
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : Entity
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}