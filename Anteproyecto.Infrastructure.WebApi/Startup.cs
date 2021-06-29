using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Anteproyecto.Infrastructure.Data.Repositories;
using GestionProyectos.Infrastructure.Systems;
using Infrastructure.Data;
using Infrastructure.Data.Base;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Anteproyecto.Infrastructure.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("ProyectoContext");//obtiene la configuracion del appsettitgs

            services.AddDbContext<ProyectoContext>(opt => opt.UseSqlite(connectionString).EnableSensitiveDataLogging(true));

            ///Inyección de dependencia Especifica
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0#register-additional-services-with-extension-methods
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //Crear Instancia por peticion
            services.AddScoped<IUsuarioRepository, UsuarioRepository>(); //Crear Instancia por peticion
            services.AddScoped<IProyectoRepository, ProyectoRepository>(); //Crear Instancia por peticion
            services.AddScoped<IConvocatoriaRepository, ConvocatoriaRepository>(); //Crear Instancia por peticion
            services.AddScoped<IEvaluacionRepository, EvaluacionRepository>(); //Crear Instancia por peticion
            services.AddScoped<IObservacionRepository, ObservacionRepository>(); //Crear Instancia por peticion
            services.AddScoped<IDbContext, ProyectoContext>(); //Crear Instancia por peticion
            services.AddScoped<IMailServer, MailServer>(); //Crear Instancia por peticion

            //inyección del servicio de mail

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Anteproyecto.Infrastructure.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Anteproyecto.Infrastructure.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
