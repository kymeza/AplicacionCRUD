using AplicacionCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TransaccionesAPITests
{
    public static class DatosDeMuestra
    {
        public static void CrearUsuarios(sistemaUsuariosContext dbContext)
        {
            dbContext.Usuarios.Add(new Usuario { CodigoUsuario = "11111111-1", Email = "asd@asd.com", Password = "asdf1", Nombre = "Kyron", Apellido = "Meza" });
            dbContext.Usuarios.Add(new Usuario { CodigoUsuario = "22222222-2", Email = "qwe@asd.com", Password = "qwer2", Nombre = "Josué", Apellido = "Bolívar" });
            dbContext.Usuarios.Add(new Usuario { CodigoUsuario = "33333333-3", Email = "zxc@asd.com", Password = "zxcv3", Nombre = "Marilena", Apellido = "Pérez" });
            //CTR + D --> Para duplicar una linea de codigo
            dbContext.SaveChanges();
        }

        public static void CrearCuentas(sistemaUsuariosContext dbContext)
        {
            dbContext.Cuentas.Add(new Cuenta { CodigoUsuario = "11111111-1", CodigoCuenta = "12345678", DescripcionCuenta = "Cuenta TEST 01" });
            dbContext.Cuentas.Add(new Cuenta { CodigoUsuario = "22222222-2", CodigoCuenta = "98765432", DescripcionCuenta = "Cuenta TEST 02" });
            dbContext.Cuentas.Add(new Cuenta { CodigoUsuario = "33333333-3", CodigoCuenta = "11222333", DescripcionCuenta = "Cuenta TEST 03" });
            dbContext.SaveChanges();
        }

        public static void CrearTransacciones(sistemaUsuariosContext dbContext)
        {
            dbContext.Transacciones.Add(new Transaccione { CodigoUsuario = "11111111-1", CodigoCuenta = "12345678",  Monto = 10000 });
            dbContext.Transacciones.Add(new Transaccione { CodigoUsuario = "11111111-1", CodigoCuenta = "12345678",  Monto = 5000 });
            dbContext.Transacciones.Add(new Transaccione { CodigoUsuario = "11111111-1", CodigoCuenta = "12345678",  Monto = 9500 });
            dbContext.Transacciones.Add(new Transaccione { CodigoUsuario = "22222222-2", CodigoCuenta = "98765432",  Monto = 15000 });
            dbContext.Transacciones.Add(new Transaccione { CodigoUsuario = "33333333-3", CodigoCuenta = "11222333",  Monto = 15000 });
        }

    }
}
