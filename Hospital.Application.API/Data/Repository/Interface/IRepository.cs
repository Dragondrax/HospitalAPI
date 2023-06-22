using Hospital.Application.API.Model;
using System.Linq.Expressions;

namespace Hospital.Application.API.Data.Repository.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> GetId(Guid Id);
        Task<List<TEntity>> SearchAll();
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
