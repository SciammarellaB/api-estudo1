using ApiEstudo.Data.Interface;
using ApiEstudo.Data.Interface.Geral;
using ApiEstudo.Data.Repository.Geral;
using ApiEstudo.Providers;
using ApiEstudo.Service.Interface.Geral;
using ApiEstudo.Service.Services.Geral;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApiEstudo.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IApiEstudoProvider, ApiEstudoProvider>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Geral
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient<ICasaRepository, CasaRepository>();
            services.AddTransient<ICasaService, CasaService>();

            services.AddTransient<IMensagemRepository, MensagemRepository>();
            services.AddTransient<IMensagemService, MensagemService>();
            #endregion
        }
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["JwtIssuer"],
                    ValidAudience = configuration["JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
