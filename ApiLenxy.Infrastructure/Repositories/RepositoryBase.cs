using ApiLenxy.Domain.Entites;
using ApiLenxy.Domain.Interfaces;
using ApiLenxy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiLenxy.Infrastructure.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
{
    private readonly DataContext _context;
    public RepositoryBase(DataContext dataContext)
    {
        _context = dataContext;
    }

    public async Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
            query = query.Include(include);
        var result = await query.SingleOrDefaultAsync(x => x.Id == id);
        return result!;
    }

    public async Task<T> CreateAsync(T model)
    {
        await _context.Set<T>().AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<T> UpdateAsync(T model, params Expression<Func<T, object>>[] includes)
    {
        _context.Set<T>().Update(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        var result = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        if(result != null)
            _context.Set<T>().Remove(result);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAsync(params Expression<Func<T, object>>[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var item in includes)
            query = query.Include(item);
        return await query.AsNoTracking().ToListAsync();
    }
}
