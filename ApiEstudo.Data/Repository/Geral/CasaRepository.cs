using ApiEstudo.Data.Context;
using ApiEstudo.Data.Interface.Geral;
using ApiEstudo.Domain.Entity.Geral;

namespace ApiEstudo.Data.Repository.Geral
{
    public class CasaRepository : CrudRepository<Casa>, ICasaRepository
    {
        public CasaRepository(ApiEstudoContext context) : base(context)
        {

        }
    }
}
