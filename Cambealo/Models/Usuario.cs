using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cambealo.Models
{
    public class Usuario
    {
        public int Id { set; get; }
        public String Nombre { set; get; }
        public String Apellidos { set; get; }
        public String Correo { set; get; }
        public String Contraseña { set; get; }
        public int Telefono { set; get; }
        public int Edad { set; get; }
    }
}