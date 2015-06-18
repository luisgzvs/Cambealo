using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Cambealo.Models
{
    public class Usuario
    {
        [System.ComponentModel.DataAnnotations.Required]
        public int Id { set; get; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El nombre  es requerido!")]
        public String Nombre { set; get; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Los Apellidos son requeridos!")]
        public String Apellidos { set; get; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El Correo  es requerido!")]
        [System.ComponentModel.DataAnnotations.EmailAddress(ErrorMessage = "El formato de correo no es el indicado!")]
        public String Correo { set; get; }
        [System.ComponentModel.DataAnnotations.DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "La contraseña es requerida!")]
        public String Contraseña { set; get; }
        [System.ComponentModel.DataAnnotations.DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "La confirmacion es requerida!")]
        [System.ComponentModel.DataAnnotations.Compare("Contraseña", ErrorMessage="Las contraseñas no coinciden")]
        public String ConfirmarContraseña { set; get; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El telefono es requerido!")]
        public int Telefono { set; get; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "La edad es requerida!")]
        public int Edad { set; get; }
    }
}