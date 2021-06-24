using ApiEstudo.Data.Context;
using ApiEstudo.Data.Interface.Geral;
using ApiEstudo.Domain.Entity.Geral;

namespace ApiEstudo.Data.Repository.Geral
{
    public class MensagemRepository : CrudRepository<Mensagem>, IMensagemRepository
    {
        public MensagemRepository(ApiEstudoContext context) : base(context)
        {

        }
    }
}
