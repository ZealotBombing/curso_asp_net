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
    }
}