using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProEvents.Infrastructure.Abstractions.Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext _context;
    public RepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public void DeleteRange(T[] entityArray)
    {
        _context.RemoveRange(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }
}