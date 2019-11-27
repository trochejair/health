using System;
using System.Linq;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            using (var db = new HealthEntities())
            {
                var Vehiculos = db.VEHICULO.ToList();

                return View(Vehiculos);
            }    
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var Vehiculo = new VEHICULO().getVehiculoById(id);
            return View("Create",Vehiculo);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Store(VEHICULO Vehiculo)
        {
            try {
                //if (ModelState.IsValid)
                //{
                    if (Vehiculo.ID == 0) { 
                        Vehiculo.InsertaVehiculo();
                    }
                    else
                    {
                        Vehiculo.EditaVehiculo(Vehiculo.ID);
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
                return View("Create",Vehiculo);
            }
        }

        public ActionResult Details()
        {

            var Id = Convert.ToInt32(Request.Form["id"]);

            var Vehiculo = new VEHICULO().getVehiculoById(Id);


            if (Vehiculo != null)
            {
                return Json(new { estatus = 0, responseObject = Vehiculo }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { estatus = -1, responseObject = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete()
        {
            var db = new HealthEntities();
            int id = Convert.ToInt32(Request.Form["item.ID"]);
            var Vehiculo = db.VEHICULO.Find(id);
            if (Vehiculo != null)
            {
                new VEHICULO().EliminaVehiculo(id);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}