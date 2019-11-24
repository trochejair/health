using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;
using Web.HealthFoot.Models.ViewModels;

namespace Web.HealthFoot.Controllers
{
    public class InsumosController : Controller
    {
        HealthEntities db = new HealthEntities();
        // GET: Insumos
        public ActionResult Index()
        {


            List<INSUMO> list;
            list = db.INSUMO.Where(input => input.ACTIVO == 1)
                .ToList();
            return View(list);
        }

        // GET: Insumos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Insumos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insumos/Create
        [HttpPost]
        public ActionResult Create(InsumoViewModel insumoView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    INSUMO insumo = new INSUMO();

                    insumo.ACTIVO = 1;
                    insumo.CANTIDAD = 0;
                    insumo.CREATED_AT = DateTime.Now;
                    insumo.NOMBRE = insumoView.NOMBRE;
                    db.INSUMO.Add(insumo);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch
            {
            }


            return View(insumoView);
        }

        // GET: Insumos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Insumos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var success = false;
            var message = "Error";

            if (id != null)
            {
                using (HealthEntities db = new HealthEntities())
                {
                    INSUMO provider = db.INSUMO.Find(id);
                    provider.ACTIVO = 0;
                    db.Entry(provider).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                success = true;
                message = "Transaccion correcta";
            }

            return Json(new
            {
                success,
                message
            }, JsonRequestBehavior.AllowGet);
        }


    }
}
