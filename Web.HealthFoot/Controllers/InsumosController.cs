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
            list = db.INSUMO.ToList();
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

        // GET: Insumos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Insumos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
