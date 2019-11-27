using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    
    public class EmbarqueController : Controller
    {
       
        // GET: Embarque
        public ActionResult Index()
        {
            var Embarques=new EMBARQUE().GetEmbarques();
            return View(Embarques);
        }

        public ActionResult Create()
        {
            var db = new HealthEntities();
            Variables(db);
                return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Store(EMBARQUE Embarque)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (Embarque.ID == 0)
                {
                    Embarque.InsertaEmbarque();
                }
                else
                {
                    Embarque.EditaEmbarque(Embarque.ID);
                }
                return RedirectToAction("Index");
                //}
                //else
                //{
                //  return View("Create",Vehiculo);
                //}

            }
            catch (Exception e)
            {
                Variables(new HealthEntities());
                return View("Create", Embarque);
            }
        }

        public ActionResult Edit(int id)
        {
            var Embarque = new HealthEntities().EMBARQUE.Find(id);
            Variables(new HealthEntities());
            return View("Create",Embarque);
        }

        public ActionResult Entrega(int id)
        {
            var db = new HealthEntities();

            var Embarque = db.EMBARQUE.Find(id);

            ViewBag.ventas = db.VENTA.ToList();

            ViewBag.entregas = db.ENTREGA.Where(b => b.ID_EMBARQUE == id).ToArray();

            return View(Embarque);
        }

        public ActionResult Add()
        {
            var IDE = Request.Form["IDE"];
            var IDV = Request.Form["IDV"];

            var Entrega = new ENTREGA();
            Entrega.ID_EMBARQUE =Convert.ToInt32(IDE);
            Entrega.ID_VENTA = Convert.ToInt32(IDV);

            var db = new HealthEntities();
            db.ENTREGA.Add(Entrega);
            db.SaveChanges();

            return RedirectToAction("Entrega",new { id = Convert.ToInt32(IDE)});
        }

        public ActionResult Remove()
        {
            var IDE =Convert.ToInt32(Request.Form["id"]);
            var ID = Convert.ToInt32(Request.Form["ide"]);

            var db = new HealthEntities();

            var Entrega = db.ENTREGA.Find(IDE);

            db.ENTREGA.Remove(Entrega);
            db.SaveChanges();

            return RedirectToAction("Entrega", new { id = ID });
        }

        public void Variables(HealthEntities  db)
        {
            ViewBag.vehiculos = db.VEHICULO.ToList().Where(z => z.ACTIVO == 1);
            ViewBag.rutas = db.RUTA.Select(v => new SelectListItem
            {
                Text = v.INICIO + "-" + v.FIN,
                Value = v.ID.ToString()
            });
        }

    }
}