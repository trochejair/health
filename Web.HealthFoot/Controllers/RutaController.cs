using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class RutaController : Controller
    {
        // GET: Ruta
        public ActionResult Index()
        {
            using (var db = new HealthEntities())
            {
                var Rutas = db.RUTA.ToList();
                return View(Rutas);
            }
              
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var Ruta = new HealthEntities().RUTA.Find(id);
            return View("Create", Ruta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Store(RUTA Ruta)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (Ruta.ID == 0)
                {
                    Ruta.InsertaRuta();
                }
                else
                {
                    Ruta.EditaRuta(Ruta.ID);
                }
                return RedirectToAction("Index");
                //}
                //else
                //{
                //  return View("Create",Vehiculo);
                //}

            }
            catch (Exception)
            {
                return View("Create", Ruta);
            }
        }

        //public ActionResult Details()
        //{

        //    var Id = Convert.ToInt32(Request.Form["id"]);

        //    var Vehiculo = new VEHICULO().getVehiculoById(Id);


        //    if (Vehiculo != null)
        //    {
        //        return Json(new { estatus = 0, responseObject = Vehiculo }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { estatus = -1, responseObject = "" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public ActionResult Delete()
        {
            var db = new HealthEntities();
            int id = Convert.ToInt32(Request.Form["item.ID"]);
            var Ruta = db.RUTA.Find(id);
            if (Ruta != null)
            {
                new RUTA().EliminaRuta(id);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}