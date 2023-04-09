using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pasaje5.Models;

namespace Pasaje5.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        List<EmpleadoCLS> listaEmpleado = null;
        public ActionResult Index()
        {
            using(var bd = new BDPasajeEntities1())
            {
                listaEmpleado = (from empleado in bd.Empleado
                                 join tipousuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals tipousuario.IIDTIPOUSUARIO
                                 join tipocontrato in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals tipocontrato.IIDTIPOCONTRATO
                                 where empleado.BHABILITADO == 1
                                 select new EmpleadoCLS
                                 {
                                     iidEmpleado = empleado.IIDEMPLEADO,
                                     nombre = empleado.NOMBRE,
                                     apPaterno = empleado.APPATERNO,
                                     apMaterno = empleado.APMATERNO,
                                     nombreTipoUsuario = tipousuario.NOMBRE,
                                     nombreTipoContrato = tipocontrato.NOMBRE
                                 }).ToList();//no entiendo na, debo aprender linq
            }
                return View(listaEmpleado);//recuerda mandar el model con los datops
        }
        public void listarComboSexo()
        {
            List<SelectListItem> lista;
            using(var bd = new BDPasajeEntities1())
            {
                lista = (from sexo in bd.Sexo
                         where sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sexo.NOMBRE,
                             Value = sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaSexo = lista;
            }
        }
        public void listarTipoContrato()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from tipoContrato in bd.TipoContrato
                         where tipoContrato.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipoContrato.NOMBRE,
                             Value = tipoContrato.IIDTIPOCONTRATO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoContrato = lista;
            }
        }
        public void listarTipoUsuario()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from tipoUsuario in bd.TipoUsuario
                         where tipoUsuario.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipoUsuario.NOMBRE,
                             Value = tipoUsuario.IIDTIPOUSUARIO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoUsuario = lista;
            }
        }
        public void listarCombos()
        {
            listarComboSexo();
            listarTipoContrato();
            listarTipoUsuario();
        }
        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }
    }
}