using ApiEstudo.Data.Context;
using ApiEstudo.Data.Interface.Geral;
using ApiEstudo.Domain.Entity.Geral;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiEstudo.Data.Repository.Geral
{
   public class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApiEstudoContext context) : base(context)
        {

        }
        public override void Update(Usuario entity)
        {
            _context.Entry(entity).Property(x => x.Login).IsModified = false;

            base.Update(entity);
        }

        public async Task<Usuario> Login(string login)
        {
            var usuario = await _context.Usuarios
                    //.Include(x => x.Perfil)
                    //.Include(x => x.Empresa)
                    .IgnoreQueryFilters()
                    .SingleOrDefaultAsync(x => x.Login.ToUpper() == login.ToUpper());

            return usuario;
        }
    }
}
