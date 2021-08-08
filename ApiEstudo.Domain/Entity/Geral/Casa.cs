using ApiEstudo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstudo.Domain.Entity.Geral
{
    [Table("Casa", Schema = "Geral")]
    public class Casa : IEntity
    {
        public long Id { get; set; }
        [Required] public string Nome { get; set; }
        [Required] public DateTime DataHoraCriacao { get; set; }
        [Required] public long AdminId { get; set; }
        public Usuario Admin { get; set; }
        public bool Ativo { get; set; }
        public ICollection<UsuarioCasa> UsuarioCasas { get; set; }
        public ICollection<Mensagem> Mensagens { get; set; }
        public int QuantidadePessoas => UsuarioCasas.Count;

        public Casa()
        {
            UsuarioCasas = new List<UsuarioCasa>();
            Mensagens = new List<Mensagem>();
        }
    }
}
