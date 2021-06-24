using ApiEstudo.Data.Extension;
using ApiEstudo.Data.Interface;
using ApiEstudo.Domain.Entity.Geral;
using ApiEstudo.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiEstudo.Data.Context
{
    public class ApiEstudoContext : DbContext
    {
        public SessionAppModel SessionApp { get; }

        public ApiEstudoContext(DbContextOptions<ApiEstudoContext> options) : base(options)
        {

        }

        public ApiEstudoContext(DbContextOptions<ApiEstudoContext> options, IApiEstudoProvider apiEstudoProvider) : base(options)
        {
            SessionApp = apiEstudoProvider.SessionApp;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            #region Geral
            modelBuilder.Entity<Usuario>().HasQueryFilter(p => p.Id == SessionApp.UsuarioId);
            modelBuilder.Entity<UsuarioCasa>().HasKey(p => new {p.UsuarioId, p.CasaId });
            modelBuilder.Entity<Casa>().HasQueryFilter(p => p.UsuarioCasas.Any(cc => cc.UsuarioId == SessionApp.UsuarioId));
            #endregion
        }

        #region Geral
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Casa> Casas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        #endregion
    }
}
