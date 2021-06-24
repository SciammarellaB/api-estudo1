using ApiEstudo.Domain.Entity.Geral;
using System.Threading.Tasks;

namespace ApiEstudo.Data.Interface.Geral
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Task<Usuario> Login(string login);
    }
}
