using Anteproyecto.Infrastructure.WebApi.Test.Base;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Anteproyecto.Aplication.CrearConvocatoriasService;

namespace Anteproyecto.Infrastructure.WebApi.Test
{
    public class ConvocatoriaText : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public ConvocatoriaText(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PuedeCrearConvocatoriaTestAsync()
        {
            var request = new CrearConvocatoriasRequest()
            {
                FechaInicio = new DateTime(2021, 1, 1),
                FechaCierre = new DateTime(2021, 2, 1),
                CargarProyectos = false
            };

            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var httpClient = _factory.CreateClient();
            var responseHttp = await httpClient.PostAsync("api/Convocatoria", content);
            responseHttp.StatusCode.Should().Be(HttpStatusCode.OK);
            var respuesta = await responseHttp.Content.ReadAsStringAsync();
            respuesta.Should().Be("Se ha añadido la sigiente convocatoria, Inicio: 1/01/2021 12:00:00 a. m. / Fin: 1/02/2021 12:00:00 a. m..");
            var context = _factory.CreateContext();
            var convocatoria = context.Convocatorias.FirstOrDefault(t => t.FechaInicio == new DateTime(2021, 1, 1));
            convocatoria.Should().NotBeNull();
        }
    }
}
