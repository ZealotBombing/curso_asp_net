using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pasaje5.Models;

namespace Pasaje5.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;
            using (var bd = new BDPasajeEntities1())
            {
                listaBus = (from bus in bd.Bus
                            join sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                            join tipoBus in bd.TipoBus
                            on bus.IIDTIPOBUS equals tipoBus.IIDTIPOBUS
                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO
                            where bus.BHABILITADO == 1
                            select new BusCLS
                            {
                                iidBus = bus.IIDBUS,
                                placa = bus.PLACA,
                                nombreModelo = tipoModelo.NOMBRE,
                                nombreSucursal = sucursal.NOMBRE,
                                nombreTipoBus = tipoBus.NOMBRE
                            }).ToList();
            }
            return View(listaBus);
        }
        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(BusCLS oBusCls)
        {
            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(oBusCls);
            }
            using(var bd = new BDPasajeEntities1())
            {
                Bus oBus = new Bus();
                oBus.IIDSUCURSAL = oBusCls.iidSucursal;
                oBus.IIDTIPOBUS = oBusCls.iidTipoBus;
                oBus.PLACA = oBusCls.placa;
                oBus.FECHACOMPRA = oBusCls.fechaCompra;
                oBus.IIDMODELO = oBusCls.iidModelo;
                oBus.NUMEROFILAS = oBusCls.numeroFilas;
                oBus.NUMEROCOLUMNAS = oBusCls.numeroColumnas;
                oBus.DESCRIPCION = oBusCls.descripcion;
                oBus.OBSERVACION = oBusCls.observacion;
                oBus.IIDMARCA = oBusCls.iidmarca;
                oBus.BHABILITADO = 1;

                bd.Bus.Add(oBus);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            listarCombos();
            BusCLS oBusCls = new BusCLS();
            using(var bd = new BDPasajeEntities1())
            {
                Bus oBus = bd.Bus.Where(p => p.IIDBUS.Equals(id)).First();
                oBusCls.iidBus = oBus.IIDBUS;
                oBusCls.iidSucursal = (int)oBus.IIDSUCURSAL;
                oBusCls.iidTipoBus = (int)oBus.IIDTIPOBUS;
                oBusCls.placa = oBus.PLACA;
                oBusCls.fechaCompra = (DateTime)oBus.FECHACOMPRA;
                oBusCls.iidModelo = (int)oBus.IIDMODELO;
                oBusCls.numeroColumnas = (int)oBus.NUMEROCOLUMNAS;
                oBusCls.numeroFilas = (int)oBus.NUMEROFILAS;
                oBusCls.descripcion = oBus.DESCRIPCION;
                oBusCls.observacion = oBus.OBSERVACION;
                oBusCls.iidmarca = (int)oBus.IIDMARCA;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editar(BusCLS oBusCLS)
        {
            int idBus = oBusCLS.iidBus;
            if (!ModelState.IsValid)
            {
                return View(oBusCLS);
            }
            using(var bd = new BDPasajeEntities1())
            {
                Bus oBus = bd.Bus.Where(p =>
                p.IIDBUS.Equals(idBus)).First();

                oBus.IIDSUCURSAL = oBusCLS.iidSucursal;
                oBus.PLACA = oBusCLS.placa;
                oBus.FECHACOMPRA = oBusCLS.fechaCompra;
                oBus.IIDMODELO = oBusCLS.iidModelo;
                oBus.NUMEROCOLUMNAS = oBusCLS.numeroColumnas;
                oBus.NUMEROFILAS = oBusCLS.numeroFilas;
                oBus.DESCRIPCION = oBusCLS.descripcion;
                oBus.IIDMARCA = oBusCLS.iidmarca;

                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public void listarTipoBus()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.TipoBus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoBus = lista;
            }
        }
        public void listarTipoMarca()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Marca
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMARCA.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaMarca = lista;
            }
        }
        public void listarModelo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Modelo
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMODELO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoModelo = lista;
            }
        }
        public void listarSucursal()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Sucursal
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDSUCURSAL.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaSucursal = lista;
            }
        }
        public void listarCombos()
        {
            listarSucursal();
            listarModelo();
            listarTipoMarca();
            listarTipoBus();
        }
    }
}