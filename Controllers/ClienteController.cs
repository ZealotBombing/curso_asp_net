using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pasaje5.Models;

namespace Pasaje5.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> lstCliente;
            using(var db = new BDPasajeEntities1())
            {
                lstCliente = (from cliente in db.Cliente
                              where cliente.BHABILITADO == 1
                              select new ClienteCLS
                              {
                                  iidcliente = cliente.IIDCLIENTE,
                                  nombre = cliente.NOMBRE,
                                  appaterno = cliente.APMATERNO,
                                  apmaterno = cliente.APMATERNO,
                                  bhabilitado = cliente.BHABILITADO

                              }).ToList();
            }
            return View(lstCliente);//MOdel
        }
        List<SelectListItem> listaSexo;

        private void llenarSexo()
        {
            using(var bd = new BDPasajeEntities1())
            {
                listaSexo = (from sexo in bd.Sexo
                            where sexo.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Text = sexo.NOMBRE,
                                Value = sexo.IIDSEXO.ToString()
                            }).ToList();
            }
        }
        public ActionResult Agregar()
        {
            llenarSexo();//llena el sexo en void y después lo entrega abajo, pero creo que servirpia con return
            ViewBag.lista = listaSexo;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();//para que se vuelva a llenar el combobox
                ViewBag.lista = listaSexo;

                return View(oClienteCLS);
            }
            using(var bd=new BDPasajeEntities1())
            {
                Cliente oCliente = new Cliente();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.appaterno;
                oCliente.APMATERNO = oClienteCLS.appaterno;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonocelular;
                oCliente.TELEFONOFIJO = oClienteCLS.telefonofijo;
                oCliente.BHABILITADO = 1;

                bd.Cliente.Add(oCliente);
                bd.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }
    }
}