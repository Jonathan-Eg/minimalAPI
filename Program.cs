using Microsoft.EntityFrameworkCore;
using Minimal_API.Dominios.Interfaces;
using Minimal_API.Dominios.Servicos;
using MinimalAPI.Infraestrutura.Db;
using System.Security.Cryptography.X509Certificates;

namespace Minimal_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();


            builder.Services.AddDbContext<DbContexto>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"));
            });
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapPost("/Login", (LoginDTO loginDTO, IAdministradorServico administradorServico) =>
            {
                if (administradorServico.Login(loginDTO) != null)
                {
                    return Results.Ok("Login com sucesso");
                }

                else
                {
                    return Results.Unauthorized();
                }
            });


            app.Run();
        }


        public class LoginDTO

        {
            public string Email { get; set; } = default!;
            public string Senha { get; set; } = default!;

        }

    }
}


