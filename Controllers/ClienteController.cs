﻿using System;
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
                              }).ToList();
            }
            return View(lstCliente);//MOdel
        }
        public ActionResult Editar(int id)
        {
            ClienteCLS oClienteCLS = new ClienteCLS();
            using(var bd = new BDPasajeEntities1())
            {
                llenarSexo();
                //ViewBag.lista = listaSexo;

                Cliente oCliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(id)).First();
                oClienteCLS.iidcliente = oCliente.IIDCLIENTE;
                oClienteCLS.nombre = oCliente.NOMBRE;
                oClienteCLS.appaterno = oCliente.APPATERNO;
                oClienteCLS.apmaterno = oCliente.APMATERNO;
                oClienteCLS.direccion = oCliente.DIRECCION;
                oClienteCLS.email = oCliente.EMAIL;
                oClienteCLS.iidsexo = (int)oCliente.IIDSEXO;//castear
                oClienteCLS.telefonoCelular = oCliente.TELEFONOCELULAR;
                oClienteCLS.telefonoFijo = oCliente.TELEFONOFIJO;
            }
            return View(oClienteCLS);
        }
        [HttpPost]
        public ActionResult Editar(ClienteCLS oClienteCLS)
        {
            int idCliente = oClienteCLS.iidcliente;
            //if (!ModelState.IsValid)
            //{
            //    llenarSexo();
            //    return View(oClienteCLS);
            //}
            using (var bd = new BDPasajeEntities1())
            {
                Cliente oCliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(idCliente)).First();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.appaterno;
                oCliente.APMATERNO = oClienteCLS.apmaterno;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOFIJO = oClienteCLS.telefonoFijo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonoFijo;

                bd.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        private void llenarSexo()
        {
            List<SelectListItem> listaSexo;

            using (var bd = new BDPasajeEntities1())
            {
                listaSexo = (from sexo in bd.Sexo
                            where sexo.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Text = sexo.NOMBRE,
                                Value = sexo.IIDSEXO.ToString()
                            }).ToList();
                listaSexo.Insert(0,new SelectListItem{ Text="--Seleccione--", Value = ""});
                ViewBag.lista = listaSexo;

            }
        }
        public ActionResult Agregar()
        {
            llenarSexo();//llena el sexo en void y después lo entrega abajo, pero creo que servirpia con return
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();//para que se vuelva a llenar el combobox
                //ViewBag.lista = listaSexo;

                return View(oClienteCLS);
            }  //sin esto es como funciona
            using (var bd=new BDPasajeEntities1())
            {
                Cliente oCliente = new Cliente();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.appaterno;
                oCliente.APMATERNO = oClienteCLS.appaterno;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonoCelular;
                oCliente.TELEFONOFIJO = oClienteCLS.telefonoFijo;
                oCliente.BHABILITADO = 1;

                bd.Cliente.Add(oCliente);
                bd.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }
       
        
    }
}