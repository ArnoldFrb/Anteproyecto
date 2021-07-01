using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Infrastructure.Data;

namespace Anteproyecto.Infrastructure.WebApi.Test.Base
{
    public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly string _connectionString = @"Data Source=C:\\BD\\AnteProyecto.db";
        public ProyectoContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<ProyectoContext>().UseSqlite(_connectionString);
            return new ProyectoContext(builder.Options);
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                #region Reemplazar la inyección del Contexto de Datos de EF Core
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ProyectoContext>));

                services.Remove(descriptor);

                services.AddDbContext<ProyectoContext>(options =>
                {
                    options.UseSqlite(_connectionString);
                });
                #endregion

                #region Eliminar y Crear nueva base de datos. 
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ProyectoContext>();
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    //invocar clase que inicilice los datos semillas. 
                }
                #endregion 
            });
        }
    }
}
