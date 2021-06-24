using ApiEstudo.Domain.Entity.Geral;
using ApiEstudo.Service.Interface.Geral;
using Microsoft.Extensions.Logging;

namespace ApiEstudo.Controllers.Geral
{
    public class MensagemController : MasterCrudController<Mensagem>
    {
        public MensagemController(ILogger<MasterCrudController<Mensagem>> logger, IMensagemService service, string includePatch = "") : base(logger, service, includePatch)
        {

        }
    }
}
