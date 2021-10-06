using AplicacionCRUD.Controllers;
using AplicacionCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace Tests
{
    public class TransaccionesTests
    {

        private DbContextOptions<sistemaUsuariosContext> options = new DbContextOptionsBuilder<sistemaUsuariosContext>()
            .UseInMemoryDatabase(databaseName: "sistemaUsuarios")
            .Options;

        public TransaccionesTests()
        {
            using (var context = new sistemaUsuariosContext(options))
            {
                context.Usuarios.Add(new Usuario { CodigoUsuario = "11111111-1", Email = "asd@asd.com", Password = "asdf1", Nombre = "Kyron", Apellido = "Meza" });
                context.Cuentas.Add(new Cuenta {CodigoUsuario = "11111111-1",CodigoCuenta="12345678",DescripcionCuenta="Cuenta TEST" });
                context.SaveChanges();
            }
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BaseDeDatosEnMemoria_Existe()
        {
            var _context = new sistemaUsuariosContext(options);

            var count = _context.Usuarios.CountAsync().Result;

            Assert.NotZero(count);

        }

        //[Test]
        //public void HomeController_PostTransaccion_TransaccionDeposito10000()
        //{
        //    Mock<ILogger<TransaccionesController>>
        //    var _context = new sistemaUsuariosContext(options);

        //    TransaccionesController controlador = new TransaccionesController(_context);

        //    Transaccione payload = new Transaccione();


        //    var response = controlador.PostTransaccion(payload);

        //    Assert.AreEqual(response, "RESPUESTA A TESTEAR");
        //}

        //[Test]
        //public void TestIntegracionExterna_PostTransaccion_Return201Created()
        //{
        //    var client = new RestClient("https://localhost:44396/api/transacciones");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", "{\n\t\"codigoUsuario\":\"12345678-9\",\n\t\"codigoCuenta\":\"12345678\",\n\t\"monto\":10000\n}", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);

        //    Assert.AreEqual("Created", response.StatusCode.ToString());

        //}



        
    }
}