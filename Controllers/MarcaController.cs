using Pasaje5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasaje5.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        //Entity framework siempres se usa en el controlador, nunca en el model o la vista
        public ActionResult Index()
        {
            List<MarcaCLS> listaMarca = null;
            using (var bd = new BDPasajeEntities1())
            {
                listaMarca = (from marca in bd.Marca //creo que esto es un linq
                              where marca.BHABILITADO == 1
                              select new MarcaCLS
                              {
                                    iidamarca = marca.IIDMARCA,
                                    nombre = marca.NOMBRE,
                                    descripcion = marca.DESCRIPCION
                              }).ToList();//tranforma la consulta en list        
            }
            return View(listaMarca);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Editar(int id)
        {
            MarcaCLS oMarcaCLS = new MarcaCLS();
            using(var bd = new BDPasajeEntities1())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(id)).First();//First es para que devuelva un objero y no una lista
                oMarcaCLS.iidamarca = oMarca.IIDMARCA;
                oMarcaCLS.nombre = oMarca.NOMBRE;
                oMarcaCLS.descripcion = oMarca.DESCRIPCION;
            }
            return View(oMarcaCLS);
        }
        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCls)//trae el model de la vista (creo)
        {
            if (!ModelState.IsValid)
            {
                return View(oMarcaCls);
            }
            else
            {
                using(var bd = new BDPasajeEntities1())
                {
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = oMarcaCls.nombre;
                    oMarca.DESCRIPCION = oMarcaCls.descripcion;
                    oMarca.BHABILITADO = 1;
                    //se le pasó todo la vista a las properties del objeto (creo)
                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                }
                   
            }
            return RedirectToAction("Index");
        }
    }
}