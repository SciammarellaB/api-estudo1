using ApiEstudo.Data.Interface;
using ApiEstudo.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace ApiEstudo.Providers
{
    public class ApiEstudoProvider : IApiEstudoProvider
    {
        public SessionAppModel SessionApp { get; }

        public ApiEstudoProvider(IHttpContextAccessor accessor)
        {
            try
            {
                if (accessor.HttpContext == null)
                    return;

                var excecoes = new string[] { "/api/autenticador/usuario", "/api/empresa/logo" };

                if (excecoes.Contains(accessor.HttpContext.Request.Path.ToString()))
                    return;

                if ("/api/usuario" == accessor.HttpContext.Request.Path.ToString() && accessor.HttpContext.Request.Method == "POST")
                    return;

                var identity = accessor.HttpContext.User;

                SessionApp = new SessionAppModel(
                    long.Parse(identity.FindFirst(ClaimTypes.Upn).Value),                    
                    identity.FindFirst(ClaimTypes.Name).Value
                );

            }
            catch (Exception)
            {
                accessor.HttpContext.Response.StatusCode = 500;
                accessor.HttpContext.Response.WriteAsync("Empresa não informado!"); ;

                throw new InvalidOperationException("Empresa não informado!");
            }
        }

    }
}
