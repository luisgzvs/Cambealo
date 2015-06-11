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
        public enum Estado {inactivo, activo, en_transaccion, cambiado};
        public String Fecha { get; set; }
    }
}