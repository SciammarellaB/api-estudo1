using ApiEstudo.Data.Interface.Geral;
using ApiEstudo.Domain.Entity.Geral;
using ApiEstudo.Service.Interface.Geral;

namespace ApiEstudo.Service.Services.Geral
{
    public class CasaService : CrudService<Casa, ICasaRepository>, ICasaService
    {
        public CasaService(ICasaRepository repository) : base(repository)
        {

        }
    }
}
