using ApiEstudo.Domain.Interface;
using ApiEstudo.Models.Shared;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiEstudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterBaseController : ControllerBase
    {
        protected PageResultModel GetPageResult<TEntity>(IQueryable query, ODataQueryOptions<TEntity> options) where TEntity : class, IEntity
        {
            var odataSettings = new ODataQuerySettings();

            if (options.Filter != null)
                query = options.Filter.ApplyTo(query, odataSettings);

            var count = (query as IQueryable<TEntity>).LongCount();

            if (options.OrderBy != null)
                query = options.OrderBy.ApplyTo(query, odataSettings);

            if (options.Skip != null)
                query = options.Skip.ApplyTo(query, odataSettings);

            if (options.Top != null)
                query = options.Top.ApplyTo(query, odataSettings);

            if (options.SelectExpand != null)
            {
                if (!options.SelectExpand.Context.DefaultQuerySettings.EnableExpand)
                    throw new System.InvalidOperationException("Informe o include via header!");

                query = options.SelectExpand.ApplyTo(query, odataSettings);
            }

            return new PageResultModel(query, count);
        }

        protected IQueryable<TEntity> GetFiltered<TEntity>(IQueryable query, ODataQueryOptions<TEntity> options) where TEntity : class, IEntity
        {
            var odataSettings = new ODataQuerySettings();

            if (options.Filter != null)
                query = options.Filter.ApplyTo(query, odataSettings);

            if (options.OrderBy != null)
                query = options.OrderBy.ApplyTo(query, odataSettings);

            if (options.Skip != null)
                query = options.Skip.ApplyTo(query, odataSettings);

            if (options.Top != null)
                query = options.Top.ApplyTo(query, odataSettings);

            if (options.SelectExpand != null)
                query = options.SelectExpand.ApplyTo(query, odataSettings);

            return query.Cast<TEntity>();
        }
    }
}
