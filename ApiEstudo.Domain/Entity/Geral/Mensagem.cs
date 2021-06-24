using ApiEstudo.Domain.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstudo.Domain.Entity.Geral
{
    [Table("Mensagem", Schema = "Geral")]
    public class Mensagem : IEntity
    {
        public long Id { get; set; }
        public long CasaId { get; set; }
        public Casa Casa { get; set; }
        public string Texto { get; set; }
    }
}
