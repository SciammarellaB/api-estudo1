using ApiEstudo.Domain.Interface;
using System.Threading.Tasks;

namespace ApiEstudo.Data.Interface
{
    public interface ICrudRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        Task Remove(long id);
        void Remove(TEntity entity);
        void Detached(TEntity entity);
        Task SaveChangesAsync();
    }
}
