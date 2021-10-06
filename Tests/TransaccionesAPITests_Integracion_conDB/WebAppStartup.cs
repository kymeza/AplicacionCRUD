using AplicacionCRUD;
using AplicacionCRUD.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TransaccionesAPITests_Integracion_conDB
{
    public class WebAppStartup<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var _dbContext = scopedServices.GetRequiredService<sistemaUsuariosContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<WebAppStartup<TStartup>>>();

                    _dbContext.Database.EnsureCreated();

                    try
                    {
                        //DatosDeMuestra.CrearUsuarios(_dbContext);
                        //DatosDeMuestra.CrearCuentas(_dbContext);
                        //DatosDeMuestra.CrearTransacciones(_dbContext);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, "ERROR DB: {e.Message}");
                    }

                }

            });
        }



    }
}
