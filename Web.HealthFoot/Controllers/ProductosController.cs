using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class ProductosController : Controller
    {


        HealthEntities db = new HealthEntities();
        // GET: Productos
        public ActionResult Index()
        {


            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            List<INSUMO> insumos = db.INSUMO.ToList();
            List<CATEGORIA> categorias = db.CATEGORIA.ToList();
            ViewBag.insumos = insumos;
            ViewBag.categotias = categorias;
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }


        public ActionResult Details()
        {
            return View();
        }

        /*
        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


       
                // POST: Productos/Create
                [HttpPost]
                public ActionResult Create(FormCollection collection)
                {
                    try
                    {
                        // TODO: Add insert logic here

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: Productos/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: Productos/Edit/5
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

                // GET: Productos/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: Productos/Delete/5
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
                */
    }
}
