using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pasaje5.Models
{
    public class ViajeCLS
    {
        [Display(Name ="Id viaje")]
        public int iidViaje { get; set; }
        [Display(Name = "Lugar Origen")]
        [Required]
        public int iidLugarOrigen { get; set; }
        [Display(Name = "Id Destino")]
        [Required]
        public int iidLugarDestino { get; set; }
        [Display(Name = "Precio")]
        [Required]
        [Range(0,100000,ErrorMessage = "Rango fuera de índices")]
        public double precio { get; set; }
        [Display(Name = "Fecha Viaje")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaViaje { get; set; }
        [Display(Name = "Bus")]
        [Required]
        public int iidBus { get; set; }
        [Display(Name = "Cantidad de asientos disponibles")]
        [Required]
        public int numeroAsientoDisponible { get; set; }


        //propiedades adicionales
        [Display(Name = "Lugar Origen")]
        public string nombreLugarOrigen { get; set; }
        [Display(Name = "Lugar Destino")]
        public string nombreLugarDestino { get; set; }
        [Display(Name = "Nombre Bus")]
        public string nombreBus{ get; set; }
    }
}