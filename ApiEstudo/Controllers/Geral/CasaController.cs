using ApiEstudo.Domain.Entity.Geral;
using ApiEstudo.Framework.Exceptions;
using ApiEstudo.Framework.Helpers;
using ApiEstudo.Service.Interface.Geral;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEstudo.Controllers.Geral
{
    public class CasaController : MasterCrudController<Casa>
    {
        public CasaController(ILogger<MasterCrudController<Casa>> logger, ICasaService service, string includePatch = "Mensagens") : base(logger, service, includePatch)
        {

        }
    }
}
