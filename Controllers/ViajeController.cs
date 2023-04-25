using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pasaje5.Models;

namespace Pasaje5.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            List<ViajeCLS> listaViaje = null;
            using(var bd = new BDPasajeEntities1())
            {
                listaViaje = (from viaje in bd.Viaje
                             join lugarOrigen in bd.Lugar
                             on viaje.IIDLUGARORIGEN equals lugarOrigen.IIDLUGAR
                             join lugarDestino in  bd.Lugar
                             on viaje.IIDLUGARDESTINO equals lugarDestino.IIDLUGAR
                             join bus in bd.Bus
                             on viaje.IIDBUS equals bus.IIDBUS
                             select new ViajeCLS
                             {
                                 iidViaje = viaje.IIDVIAJE,
                                 nombreBus = bus.PLACA,
                                 nombreLugarOrigen = lugarOrigen.NOMBRE,
                                 nombreLugarDestino = lugarOrigen.NOMBRE

                             }).ToList();
            }
            return View(listaViaje);
        }
        public ActionResult Agregar()
        {
            ListarCombos();
            return View();
        }
        public void listarLugar()
        {
            List<SelectListItem> listaLugar;
            using (var bd = new BDPasajeEntities1())
            {
                listaLugar = (from tipoContrato in bd.Lugar
                         where tipoContrato.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipoContrato.NOMBRE,
                             Value = tipoContrato.IIDLUGAR.ToString()
                         }).ToList();
                listaLugar.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaLugar = listaLugar;
            }
        }
        public void listarBus()
        {
            List<SelectListItem> listaBus;
            using (var bd = new BDPasajeEntities1())
            {
                listaBus = (from tipoContrato in bd.Bus
                         where tipoContrato.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipoContrato.PLACA,
                             Value = tipoContrato.IIDBUS.ToString()
                         }).ToList();
                listaBus.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaBus = listaBus;
            }
        }
        public void ListarCombos()
        {
            listarBus();
            listarLugar();
        }
    }   
}