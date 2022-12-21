using MediatR;
using Microsoft.OpenApi.Models;
using Npgsql;
using Scharff.Application.Queries.Client.GetClientById;
using Scharff.Infrastructure.Queries.Client.GetClientById;
using System.Data;
using System.Reflection;

namespace Scharff.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Assembly application = AppDomain.CurrentDomain.Load("Scharff.Application");
            Assembly infrastructure = AppDomain.CurrentDomain.Load("Scharff.Infrastructure");

            //HttpClient configuration
            services.AddHttpClient("HttpClientName").ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                return handler;
            });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Scharff API",
                        Description = "APIS FACTURACION"
                    });
            });

            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            //DataBase
            string connection = Configuration.GetSection("ConnectionStrings").GetValue<string>("Scharff_BD");
            services.AddTransient<IDbConnection>(x => new NpgsqlConnection(connection));

            services.AddTransient(typeof(IGetClientById), typeof(GetClientById));

            //MediatR
            services.AddMediatR(application);
            services.AddMvc().AddControllersAsServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
