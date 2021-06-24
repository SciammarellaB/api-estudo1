using ApiEstudo.Data.Interface.Geral;
using ApiEstudo.Domain.Entity.Geral;
using ApiEstudo.Service.Interface.Geral;

namespace ApiEstudo.Service.Services.Geral
{
    public class MensagemService : CrudService<Mensagem, IMensagemRepository>, IMensagemService
    {
        public MensagemService(IMensagemRepository repository) : base(repository)
        {

        }
    }
}
