using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Context;

namespace ProEvents.Infrastructure.Abstractions
{
    public class ReposiroryBase : IRepository
    {
        private readonly AppDbContext _context;
        public ReposiroryBase(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : Entity
        {
            _context.AddAsync(entity);
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