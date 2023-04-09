using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pasaje5.Models
{
    public class EmpleadoCLS
    {
        [Display(Name ="Id Empleado")]
        public int iidEmpleado { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage ="Longitud máxima es 100")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima es 200")]
        public string apPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima es 200")]
        public string apMaterno { get; set; }
        [Display(Name = "Fecha Contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaContrato { get; set; }
        [Display(Name = "Tipo Usuario")]
        [Required]
        public int iidtipoUsuario { get; set; }
        [Display(Name = "Tipo Contrato")]
        [Required]
        public int iidtipoContrato { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public int iidSexo { get; set; }
        public int bhabilitado { get; set; }

        //Propiedades adicionales
        [Display(Name ="Tipo contrato")]
        public string nombreTipoContrato { get; set; }
        [Display(Name ="Tipo usuario")]
        public string nombreTipoUsuario { get; set; }
    }
}