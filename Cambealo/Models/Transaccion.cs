using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cambealo.Models
{
    public class Transaccion
    {
        public int Id { set; get; }
        public String Ofrecido { set; get; }
        public String Interes { set; get; }
        public String Fecha { set; get; }
        public String Estado { set; get; }
        public int IdUsuario { set; get; }

    }
}