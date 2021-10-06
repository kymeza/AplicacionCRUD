using AplicacionCRUD;
using AplicacionCRUD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.TransaccionesAPITests_Integracion_conDB
{
    public class TransaccionesAPITests : IClassFixture<WebAppStartup<Startup>>
    {
        private readonly HttpClient _client;

        public TransaccionesAPITests(WebAppStartup<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ObetnerTransacciones()
        {
            var httpResponse = await _client.GetAsync("/api/Transacciones");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var transacciones = JsonConvert.DeserializeObject<IEnumerable<Transaccione>>(stringResponse);
            Assert.Contains(transacciones, t => t.CodigoCuenta == "12345678");
        }


    }
}
