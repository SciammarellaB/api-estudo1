namespace ApiEstudo.Domain.Model
{
    public class SessionAppModel
    {
        public long UsuarioId { get; }
        public string UsuarioNome { get; }
        public byte[] UsuarioFoto { get; set; }
        public SessionAppModel(long usuarioId, string usuarioNome)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
        }
    }
}
