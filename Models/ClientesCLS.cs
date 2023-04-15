using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pasaje5.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id Cliente")]
        [Required]
        public int iidcliente { get; set; }
        [Display(Name = "Nombre Cliente")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Máxima 100")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno Cliente")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Máxima 100")]
        public string appaterno { get; set; }
        [Display(Name = "Apellido Materno Cliente")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Máxima 100")]
        public string apmaterno { get; set; }
        [Display(Name = "Email Cliente")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud Máxima 100")]
        [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
        public string email { get; set; }
        [Display(Name = "Dirección Cliente")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string direccion { get; set; }
        [Display(Name = "Sexo Cliente")]
        [Required]
        public int iidsexo { get; set; }
        [Display(Name = "Teléfono Fijo Cliente")]
        [Required]
        public string telefonoFijo { get; set; }
        [Display(Name = "Teléfono Celular Cliente")]
        [Required]
        public string telefonoCelular { get; set; }
        [Display(Name = "Habilitado")]
        [Required]
        public int? bhabilitado { get; set; }
        [Display(Name = "Tiene Usuario")]
        [Required]
        public int btieneusuario { get; set; }
        [Display(Name = "Tipo Usuario")]
        [Required]
        public char tipousuario { get; set; }
    }
}