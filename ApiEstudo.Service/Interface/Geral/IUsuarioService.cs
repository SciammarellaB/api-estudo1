using ApiEstudo.Domain.Entity.Geral;
using System.Threading.Tasks;

namespace ApiEstudo.Service.Interface.Geral
{
    public interface IUsuarioService : ICrudService<Usuario>
    {
        Task Post(Usuario usuario);
        Task<Usuario> Login(string login, string senha);
        Task AlterarSenha(long id, string senhaAntiga, string senhaNova);
    }
}
