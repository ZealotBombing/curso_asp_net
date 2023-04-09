﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pasaje5.Models
{
    public class BusCLS
    {
        [Display(Name ="Id Bus")]
        public int iidBus { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required]
        public int iidSucursal { get; set; }
        [Display(Name = "Tipo Bus")]
        [Required]
        public int iidTipoBus { get; set; }
        [Display(Name ="Placa")]
        [Required]
        [StringLength(100,ErrorMessage ="Longitud máxima es de 100")]
        public string placa { get; set; }
        [Display(Name = "Fecha Compra")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaCompra { get; set; }
        [Display(Name = "Nombre Modelo")]
        [Required]
        public int iidModelo { get; set; }
        [Display(Name = "Número de Filas")]
        [Required]
        public int numeroFilas { get; set; }
        [Display(Name = "Número de columnas")]
        [Required]
        public int numeroColumnas { get; set; }
        public int bhabilitado { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string descripcion { get; set; }
        [Display(Name = "Observación")]
        [StringLength(200, ErrorMessage ="Longitud Máxima es 200")]
        [Required]
        public string observacion { get; set; }
        [Display(Name = "Nombre Marca")]
        [Required]
        public int iidmarca { get; set; }
        //Propiedades adicionales
        [Display(Name = "Nombre Sucursal")]
        public string nombreSucursal { get; set; }
        [Display(Name = "Nombre Tipo Bus")]
        public string nombreTipoBus { get; set; }//estos nombres están en otra tabla
        [Display(Name = "Nombre Modelo")]
        public string nombreModelo { get; set; }
    }
}