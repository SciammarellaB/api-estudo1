using ApiEstudo.Domain.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstudo.Domain.Entity.Geral
{
    [Table("Usuario", Schema = "Geral")]
    public class Usuario : IEntity
    {
        private string _senha;

        public long Id { get; set; }
        [Required] public string Login { get; set; }
        public string Senha { get { return null; } set { _senha = value; } }
        [Required] public DateTime DataHoraCriacao { get; set; }
        [Required] public string Nome { get; set; }
        public byte[] Foto { get; set; }
        public bool Ativo { get; set; }

        public Usuario()
        {
            DataHoraCriacao = DateTime.Now;
            Ativo = true;
        }
        public string GetSenha()
        {
            return _senha;
        }
    }
}
