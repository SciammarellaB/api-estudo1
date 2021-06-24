using ApiEstudo.Domain.Entity.Geral;
using ApiEstudo.Framework.Exceptions;
using ApiEstudo.Framework.Helpers;
using ApiEstudo.Models;
using ApiEstudo.Service.Interface.Geral;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ApiEstudo.Controllers.Geral
{
    public class UsuarioController : MasterCrudController<Usuario>
    {
        private readonly IUsuarioService _service;
        public UsuarioController(ILogger<MasterCrudController<Usuario>> logger, IUsuarioService service, string includePatch = "UsuarioCasas") : base(logger, service, includePatch)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<Usuario>> Post([FromBody] Usuario model)
        {
            return await base.Post(model);
        }

        [HttpPost("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha([FromBody] AlteraSenhaModel model)
        {
            try
            {
                await _service.AlterarSenha(model.UsuarioId, model.SenhaAntiga, model.SenhaNova);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }
    }
}
