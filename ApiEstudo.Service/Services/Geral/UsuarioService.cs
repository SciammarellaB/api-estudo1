using ApiEstudo.Data.Interface.Geral;
using ApiEstudo.Domain.Entity.Geral;
using ApiEstudo.Framework.Exceptions;
using ApiEstudo.Framework.Helpers;
using ApiEstudo.Service.Interface.Geral;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstudo.Service.Services.Geral
{    
    public class UsuarioService : CrudService<Usuario, IUsuarioRepository>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
                
        }

        private Usuario GerarSenha(Usuario usuario)
        {
            var hasher = new PasswordHasher<Usuario>();
            usuario.Senha = hasher.HashPassword(usuario, usuario.GetSenha());

            return usuario;
        }

        private bool VerificaSenha(Usuario usuario, string senha)
        {
            var hasher = new PasswordHasher<Usuario>();

            return hasher.VerifyHashedPassword(usuario, usuario.GetSenha(), senha) == PasswordVerificationResult.Success;
        }

        private bool LoginExistente(Usuario usuario)
        {
            //return Get().Any(x => x.Login == usuario.Login);
            return _repository.GetAll().IgnoreQueryFilters().Any(x => x.Login == usuario.Login);
        }

        public async override Task Post(Usuario usuario)
        {

            if (string.IsNullOrEmpty(usuario.GetSenha()))
                throw new BadRequestException("Informe uma senha válida!");

            if (LoginExistente(usuario))
            {
                throw new BadRequestException("Já existe um usuário utilizando esse login");
            }

            else
            {
                usuario = GerarSenha(usuario);

                await base.Post(usuario);
            }

        }

        public async override Task Patch(long id, JsonPatchDocument<Usuario> model, string include)
        {
            var domain = string.IsNullOrEmpty(include) ? await GetTracking(id) : await GetTracking(id, include);

            if (domain == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            model.ApplyTo(domain);

            await SaveChangesAsync();
        }

        public async override Task Put(Usuario usuario)
        {
            await base.Put(usuario);
        }

        public async Task AlterarSenha(long id, string senhaAntiga, string senhaNova)
        {
            var usuario = await Get(id);

            if (usuario == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            if (!VerificaSenha(usuario, senhaAntiga))
                throw new BadRequestException("Senha incorreta!");

            usuario.Senha = senhaNova;
            usuario = GerarSenha(usuario);

            await base.Put(usuario);
        }

        public async Task<Usuario> Login(string login, string senha)
        {
            var usuario = await _repository.Login(login);

            var hasher = new PasswordHasher<Usuario>();

            if (hasher.VerifyHashedPassword(usuario, usuario?.GetSenha() ?? "", senha) != PasswordVerificationResult.Failed)
                return usuario;

            throw new BadRequestException("Login e/ou senha incorretos");
        }
    }
}

