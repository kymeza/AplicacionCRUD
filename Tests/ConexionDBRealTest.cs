using AplicacionCRUD.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ConexionDBRealTest
    {
        private readonly DbContextOptions<sistemaUsuariosContext> options = new DbContextOptionsBuilder<sistemaUsuariosContext>()
            .UseSqlServer("Server=.\\SQLEXPRESS;Database=sistemaUsuarios;Trusted_Connection=True;")
            .Options;

        private readonly sistemaUsuariosContext dbContext;

        public ConexionDBRealTest()
        {
            dbContext = new sistemaUsuariosContext(options);
        }

        [Test]
        public void LeerDB()
        {
            Assert.NotZero(dbContext.Usuarios.ToList().Count);
        }

    }
}
