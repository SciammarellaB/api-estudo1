namespace ApiEstudo.Models
{
    public class AlteraSenhaModel
    {
        public long UsuarioId { get; set; }
        public string SenhaAntiga { get; set; }
        public string SenhaNova { get; set; }
    }
}
