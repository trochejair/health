using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class OrdenesInsumosController : Controller
    {
        HealthEntities db = new HealthEntities();
        // GET: OrdenesInsumos
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdenesInsumos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenesInsumos/Create
        public ActionResult Create()
        {


            List<PROVEEDOR> provider;

            provider = db.PROVEEDOR.ToList();



            ViewBag.Providers = new SelectList(provider, "ID", "NOMBRE"); ;
            return View();
        }

        // POST: OrdenesInsumos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var allKey = collection.AllKeys;
                var count = allKey.Length;
                if (count > 2)
                {
                    ORDEN_PROVEEDOR ordenProveedor = new ORDEN_PROVEEDOR();
                    ordenProveedor.FK_PROVEEDOR = Int32.Parse(collection["Providers"]);
                    ordenProveedor.CREATED_AT = DateTime.Now;
                    ordenProveedor.FECHA = DateTime.Now;
                    ordenProveedor = db.ORDEN_PROVEEDOR.Add(ordenProveedor);
                    db.SaveChanges();
                    for (var x = 2; x < count; x++)
                    {
                        string key = allKey[x];
                        var name = collection[key];
                        string id = key.Replace("arrayInsumos[", "")
                                       .Replace("][name]", "");
                        var price = collection["arrayInsumos[" + id + "]" + "[price]"];
                        var quantity = collection["arrayInsumos[" + id + "]" + "[quantity]"];
                        var unit = collection["arrayInsumos[" + id + "]" + "[unit]"];

                        x = x + 3;

                        INSUMO insumo = new INSUMO();
                        insumo.NOMBRE = name;
                        insumo.CANTIDAD = Int32.Parse(quantity);
                        //insumo.DESCRIPCION = "";
                        //insumo.UNIDAD_MEDIDA = unit;
                        insumo.ACTIVO = 1;
                        //insumo.FK_ORDEN_PROVEEDOR = ordenProveedor.ID;
                        insumo.CREATED_AT = DateTime.Now;
                        db.INSUMO.Add(insumo);

                    }
                    db.SaveChanges();


                    return RedirectToAction("Ordenes", "Compras");
                }
                else {

                    ViewBag.Errors = "Almenos agregue un insumo";
                }
            }
            catch
            {
            }


            List<PROVEEDOR> provider;
            provider = db.PROVEEDOR.ToList();
            ViewBag.Providers = new SelectList(provider, "ID", "NOMBRE"); ;
            return View();

        }

        // GET: OrdenesInsumos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenesInsumos/Edit/5
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

        // GET: OrdenesInsumos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesInsumos/Delete/5
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
