using System.Linq.Expressions;
using Tasks.Api.Core.Domain;

namespace Tasks.Api.Core.Abstractions
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task AddAsync(T obj);

        Task UpdateAsync(T obj);

        Task UpdateRangeAsync(IEnumerable<T> obj);

        Task DeleteAsync(T obj);

        Task DeleteRangeAsync(IEnumerable<T> obj);

        Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids);

        Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    }
}
