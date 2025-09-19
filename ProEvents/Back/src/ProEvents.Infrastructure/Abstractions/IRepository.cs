using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.Abstractions
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void DeleteRange<T>(T[] entity) where T : Entity;
        Task<bool> SaveChangesAsync();
    }
}