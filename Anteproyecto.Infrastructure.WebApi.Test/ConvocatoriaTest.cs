using Anteproyecto.Infrastructure.WebApi.Test.Base;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Anteproyecto.Aplication.ConvocatoriaService.ActivarCargaProyectosService;
using static Anteproyecto.Aplication.ConvocatoriaService.CrearConvocatoriaService;
using static Anteproyecto.Aplication.ConvocatoriaService.DesactivarCargaProyectosService;

namespace Anteproyecto.Infrastructure.WebApi.Test
{
    public class ConvocatoriaTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public ConvocatoriaTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PuedeCrearConvocatoriaTestAsync()
        {
            var request = new CrearConvocatoriaRequest(new DateTime(2021, 1, 1), new DateTime(2021, 2, 1), false);

            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var httpClient = _factory.CreateClient();
            var responseHttp = await httpClient.PostAsync("api/Convocatoria/CrearConvocatoria", content);
            responseHttp.StatusCode.Should().Be(HttpStatusCode.OK);
            var respuesta = await responseHttp.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CrearConvocatoriaResponse>(respuesta);
            response.Mensaje.Should().Be($"Se ha creado la convocatoria para las fechas: Inicio: {request.FechaInicio} / Cierre: {request.FechaCierre}");
            var context = _factory.CreateContext();
            var convocatoria = context.Convocatorias.FirstOrDefault(t => t.FechaInicio == new DateTime(2021, 1, 1));
            convocatoria.Should().NotBeNull();
        }

        [Fact]
        public async Task PuedeActivarConvocatoriaTestAsync()
        {
            var request = new CrearConvocatoriaRequest(new DateTime(2021, 1, 1), new DateTime(2021, 2, 1), false);

            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var httpClient = _factory.CreateClient();
            var responseHttp = await httpClient.PostAsync("api/Convocatoria/CrearConvocatoria", content);
            responseHttp.StatusCode.Should().Be(HttpStatusCode.OK);
            var respuesta = await responseHttp.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CrearConvocatoriaResponse>(respuesta);
            response.Mensaje.Should().Be($"Se ha creado la convocatoria para las fechas: Inicio: {request.FechaInicio} / Cierre: {request.FechaCierre}");
            var context = _factory.CreateContext();
            var convocatoria = context.Convocatorias.FirstOrDefault(t => t.FechaInicio == new DateTime(2021, 1, 1));
            convocatoria.Should().NotBeNull();

            var requestActivar = new ActivarCargaProyectosRequest(1);

            var jsonObjectActivar = JsonConvert.SerializeObject(requestActivar);
            var contentActivar = new StringContent(jsonObjectActivar, Encoding.UTF8, "application/json");
            var httpClientActivar = _factory.CreateClient();
            var responseHttpActivar = await httpClientActivar.PostAsync("api/Convocatoria/ActivarCargaProyectos", contentActivar);
            responseHttpActivar.StatusCode.Should().Be(HttpStatusCode.OK);
            var respuestaActivar = await responseHttpActivar.Content.ReadAsStringAsync();
            var responseActivar = JsonConvert.DeserializeObject<ActivarCargaProyectosResponse>(respuestaActivar);
            responseActivar.Mensaje.Should().Be("Carga de proyectos activada.");
            var contextActivar = _factory.CreateContext();
            var convocatoriaActivar = contextActivar.Convocatorias.FirstOrDefault(t => t.Id == 1);
            convocatoriaActivar.Should().NotBeNull();
        }

        [Fact]
        public async Task PuedeDesactivarConvocatoriaTestAsync()
        {
            var request = new CrearConvocatoriaRequest(new DateTime(2021, 1, 1), new DateTime(2021, 2, 1), true);

            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var httpClient = _factory.CreateClient();
            var responseHttp = await httpClient.PostAsync("api/Convocatoria/CrearConvocatoria", content);
            responseHttp.StatusCode.Should().Be(HttpStatusCode.OK);
            var respuesta = await responseHttp.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CrearConvocatoriaResponse>(respuesta);
            response.Mensaje.Should().Be($"Se ha creado la convocatoria para las fechas: Inicio: {request.FechaInicio} / Cierre: {request.FechaCierre}");
            var context = _factory.CreateContext();
            var convocatoria = context.Convocatorias.FirstOrDefault(t => t.FechaInicio == new DateTime(2021, 1, 1));
            convocatoria.Should().NotBeNull();


            var requestDesactivar = new DesactivarCargaProyectosRequest(1);

            var jsonObjectDesactivar = JsonConvert.SerializeObject(requestDesactivar);
            var contentDesactivar = new StringContent(jsonObjectDesactivar, Encoding.UTF8, "application/json");
            var httpClientDesactivar = _factory.CreateClient();
            var responseHttpDesactivar = await httpClientDesactivar.PostAsync("api/Convocatoria/DesactivarCargaProyectos", contentDesactivar);
            responseHttpDesactivar.StatusCode.Should().Be(HttpStatusCode.OK);
            var respuestaDesactivar = await responseHttpDesactivar.Content.ReadAsStringAsync();
            var responseDesactivar = JsonConvert.DeserializeObject<DesactivarCargaProyectosResponse>(respuestaDesactivar);
            responseDesactivar.Mensaje.Should().Be("Carga de proyectos desactivada.");
            var contextDesactivar = _factory.CreateContext();
            var convocatoriaDesactivar = contextDesactivar.Convocatorias.FirstOrDefault(t => t.FechaInicio == new DateTime(2021, 1, 1));
            convocatoriaDesactivar.Should().NotBeNull();
        }
    }
}
