using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void DeleteRange<T>(T[] entity) where T : Entity;
        Task<bool> SaveChangesAsync();
    }
}