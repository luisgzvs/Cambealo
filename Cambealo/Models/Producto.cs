using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cambealo.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Foto { get; set; }
        public String Estado { get; set; }
        public String Fecha { get; set; }
        public int IdUsuario { get; set; }
    }
}