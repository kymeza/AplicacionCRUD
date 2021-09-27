using System;
using System.Collections.Generic;

#nullable disable

namespace AplicacionCRUD.Models
{
    public partial class Log
    {
        public string CodigoUsuario { get; set; }
        public string CodigoCuenta { get; set; }
        public string Mensaje { get; set; }
        public int LogId { get; set; }
        public byte[] FechaHora { get; set; }

        public virtual Cuenta Codigo { get; set; }
    }
}
