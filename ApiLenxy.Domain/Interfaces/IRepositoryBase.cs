using ApiLenxy.Domain.Entites;
using System.Linq.Expressions;

namespace ApiLenxy.Domain.Interfaces;

public interface IRepositoryBase<T> where T : Entity
{
    Task<IEnumerable<T>> GetAsync(params Expression<Func<T, object>>[] includes);
    Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includes);
    Task<T> CreateAsync(T model);
    Task<T> UpdateAsync(T model, params Expression<Func<T, object>>[] includes);
    Task DeleteAsync(Guid id);
}
