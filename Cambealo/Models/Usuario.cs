using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cambealo.Models
{
    public class Usuario
    {
        public int id { set; get; }
        public String nombre { set; get; }
        public String apellidos { set; get; }
        public String correo { set; get; }
        public String contraseña { set; get; }
        public int telefono { set; get; }
        public int edad { set; get; }
    }
}