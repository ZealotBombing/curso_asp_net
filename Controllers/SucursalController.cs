using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pasaje5.Models;

namespace Pasaje5.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        List<SucursalCLS> listaSucursal = null;
        public ActionResult Index()
        {
            List<SucursalCLS> listaSucursal;
            using(var bd = new BDPasajeEntities1())
            {
                listaSucursal = (from sucursal in bd.Sucursal
                                 where sucursal.BHABILITADO == 1
                                 select new SucursalCLS
                                 {
                                     iidsucursal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     telefono = sucursal.TELEFONO,
                                     email = sucursal.EMAIL
                                 }).ToList();
            }
            return View(listaSucursal);
        }
        public ActionResult Agregar()
        {
            return View();
        }
    }
}