using ApiEstudo.Data.Context;
using ApiEstudo.Data.Interface;
using ApiEstudo.Domain.Interface;
using ApiEstudo.Framework.Exceptions;
using ApiEstudo.Framework.Helpers;
using System.Threading.Tasks;

namespace ApiEstudo.Data.Repository
{
    public class CrudRepository<TEntity> : QueryRepository<TEntity>, ICrudRepository<TEntity> where TEntity : class, IEntity
    {
        public CrudRepository(ApiEstudoContext context) : base(context)
        {

        }

        public async Task Insert(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Remove(long id)
        {
            var entity = await GetByIdNoIncludeAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Detached(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public async Task SaveChangesAsync()
        {

            await _context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
