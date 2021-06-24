using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstudo.Domain.Entity.Geral
{
    [Table("Usuario_Casa", Schema = "Geral")]
    public class UsuarioCasa
    {
        public long UsuarioId { get; set; }
        public long CasaId { get; set; }
        public Casa Casa { get; set; }
    }
}
