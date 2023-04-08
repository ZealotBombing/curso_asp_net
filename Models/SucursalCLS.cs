using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pasaje5.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id sucursal")]
        public int iidsucursal { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [StringLength(100,ErrorMessage ="Longitud máxima es 100")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima es 200")]
        public string direccion { get; set; }
        [Display(Name = "Teléfono Sucursal")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud máxima es 10")]
        public string telefono { get; set; }
        [Display(Name = "Email Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud máxima es 100")]
        public string email { get; set; }
        [Display(Name = "Fecha Apertura")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime fechaApertura { get; set; }
        public int dhabilitado { get; set; }
    }
}


