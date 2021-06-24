using ApiEstudo.Domain.Interface;
using ApiEstudo.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstudo.Data.Interface
{
    public interface IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetByIdAsync(long id);
        Task<TEntity> GetByIdAsync(long id, string include);
        Task<TEntity> GetByIdTrackingAsync(long id);
        Task<TEntity> GetByIdTrackingAsync(long id, string include);
        Task<TEntity> GetByIdNoIncludeAsync(long id);
        Task<TEntity> GetByIdTrackingNoFilterAsync(long id);
        IQueryable<TEntity> GetAll(string include = "");
        IQueryable<TEntity> GetAllNoInclude();
        SessionAppModel SessionApp { get; }
    }
}
