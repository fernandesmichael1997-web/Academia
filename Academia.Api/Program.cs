using System.Text.Json.Serialization;
using Academia.Dominio;
using Academia.Repositorio;
using Academia.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Academia.Api.Extension;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AcademiaDbContext>(options => options.UseSqlite("Data Source=academia.db"));

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                                options.JsonSerializerOptions.Converters.Remove(options.JsonSerializerOptions.Converters.FirstOrDefault(c => c is JsonStringEnumConverter));
                            });

            builder.Services.Scan(scan => scan.FromAssembliesOf(typeof(DominioInjection), typeof(RepositorioInjection))
                            .AddClasses()
                            .AsImplementedInterfaces()
                            .WithScopedLifetime());

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Academia - Agendamento de Aulas",
                    Version = "v1",
                    Description = "API para agendamento de aulas coletivas em academia."
                });
                c.SchemaFilter<DescricaoEnumExtension>();
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAny",
                    x => x
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials());
            });

            var app = builder.Build();

            app.UseCors("AllowAny");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Academia API v1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
        }
    }

