using ApiEstudo.Domain.Model;
using ApiEstudo.Framework.Exceptions;
using ApiEstudo.Framework.Helpers;
using ApiEstudo.Models;
using ApiEstudo.Service.Interface.Geral;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstudo.Controllers
{
    public class AutenticadorController : MasterBaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;

        public AutenticadorController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        private string GenerateJwtToken(long id, string nome)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Upn, id.ToString()),
                new Claim(ClaimTypes.Name, nome)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtExpireMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("usuario")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var usuario = await _usuarioService.Login(model.Login, model.Senha);

                var retorno = new
                {
                    Dados = new SessionAppModel(usuario.Id, usuario.Nome)
                    {
                        UsuarioFoto = usuario.Foto
                    },
                    Token = GenerateJwtToken(usuario.Id, usuario.Nome)
                };

                return Ok(retorno);

            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }
    }
}
