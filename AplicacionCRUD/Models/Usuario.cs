using System;
using System.Collections.Generic;

#nullable disable

namespace AplicacionCRUD.Models
{
    public partial class Usuario
    {
        public string CodigoUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
