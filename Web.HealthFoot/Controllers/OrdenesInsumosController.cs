using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    [Authorize]
    public class OrdenesInsumosController : Controller
    {
        // GET: OrdenesInsumos
        public ActionResult Index()
        {
            List<ORDEN_PROVEEDOR> list;
            HealthEntities db = new HealthEntities();
            list = db.ORDEN_PROVEEDOR.ToList();
            return View(list);
        }

        // GET: OrdenesInsumos/Details/5
        public ActionResult Details(int id)
        {
            HealthEntities db = new HealthEntities();
            ORDEN_PROVEEDOR order = db.ORDEN_PROVEEDOR.Find(id);

            return View(order);
        }

        // GET: OrdenesInsumos/Create
        public ActionResult Create()
        {

            List<PROVEEDOR> provider;
            List<INSUMO> supplies;

            using (HealthEntities db = new HealthEntities())
            {
                provider = db.PROVEEDOR.Where(providerModel => providerModel.ACTIVO==1)
                    .ToList();
                supplies = db.INSUMO.Where(input => input.ACTIVO == 1)
                                          .ToList();
            }

            ViewBag.Providers = new SelectList(provider, "ID", "NOMBRE"); ;
            ViewBag.Supplies = new SelectList(supplies, "ID", "NOMBRE"); ;
            return View();
        }

        // POST: OrdenesInsumos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var allKey = collection.AllKeys;
            var count = allKey.Length;
            List<PROVEEDOR> providers;
            List<INSUMO> supplies;

            if (count > 5)
            {
                using (HealthEntities db = new HealthEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                       try
                        {
                            ORDEN_PROVEEDOR ordenProveedor = new ORDEN_PROVEEDOR
                            {
                                FK_PROVEEDOR = Int32.Parse(collection["Providers"]),
                                CREATED_AT = DateTime.Now,
                                FECHA = DateTime.Now
                            };
                            ordenProveedor = db.ORDEN_PROVEEDOR.Add(ordenProveedor);
                            for (var x = 3; x < count; x++)
                            {
                                string key = allKey[x];
                                var name = collection[key];
                                string id = key.Replace("arrayInsumos[", "")
                                               .Replace("][name]", "");
                                var price = collection["arrayInsumos[" + id + "]" + "[price]"];
                                var quantity = collection["arrayInsumos[" + id + "]" + "[quantity]"];
                                var unit = collection["arrayInsumos[" + id + "]" + "[unit]"];

                                x = x + 3;

                                INSUMO_ORDEN insumo = new INSUMO_ORDEN
                                {
                                    PRECIO = float.Parse(price),
                                    UNIDAD_MEDIDA= unit,
                                    FK_INSUMO= Int32.Parse(name),
                                    FK_ORDEN_PROVEEDOR= ordenProveedor.ID,
                                    CANTIDAD = Int32.Parse(quantity),
                                    ACTIVO = 1,
                                    CREATED_AT = DateTime.Now
                                };
                                db.INSUMO_ORDEN.Add(insumo);
                            }
                            db.SaveChanges();
                           transaction.Commit();
                        return RedirectToAction("Index");
                        }
                        catch
                        {
                            transaction.Rollback();
                            ViewBag.Errors = "Almenos agregue un insumo Error";
                        }
                    }
                }
            }
            else
            {

                ViewBag.Errors = "Almenos agregue un insumo";
            }

            using (HealthEntities db = new HealthEntities())
            {
                providers = db.PROVEEDOR.Where(provider => provider.ACTIVO == 1)
                    .ToList();

                supplies = db.INSUMO.Where(input => input.ACTIVO == 1)
                          .ToList();
            }

            ViewBag.Providers = new SelectList(providers, "ID", "NOMBRE"); ;
            ViewBag.Supplies = new SelectList(supplies, "ID", "NOMBRE"); ;
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
