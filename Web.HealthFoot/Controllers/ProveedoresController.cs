using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    [Authorize]
    public class ProveedoresController : Controller
    {

        HealthEntities db = new HealthEntities();

        // GET: Proveedores
        public ActionResult Index()
        {
            List<ProviderAddress> list;

            list = (from p in db.PROVEEDOR
                    join d in db.DIRECCION
                    on p.FK_DIRECCION equals d.ID
                    where p.ACTIVO == 1 
                    select new ProviderAddress
                    {
                        IDADDRESS = d.ID,
                        ESTADO = d.ESTADO,
                        CIUDAD = d.CIUDAD,
                        MUNICIPIO = d.MUNICIPIO,
                        COLONIA = d.COLONIA,
                        CALLE = d.COLONIA,
                        CP = d.CP,
                        NUMERO = d.NUMERO,

                        ID = p.ID,
                        NOMBRE = p.NOMBRE,
                        TELEFONO = p.TELEFONO,
                        CORREO = p.CORREO,
                        RFC = p.RFC
                    }).ToList();



            return View(list);
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int id)
        {

            ProviderAddress provider;

            using (HealthEntities db = new HealthEntities())
            {
                provider = (from p in db.PROVEEDOR
                            join d in db.DIRECCION
                            on p.FK_DIRECCION equals d.ID
                            where p.ID == id
                            select new ProviderAddress
                            {
                                IDADDRESS = d.ID,
                                ESTADO = d.ESTADO,
                                CIUDAD = d.CIUDAD,
                                MUNICIPIO = d.MUNICIPIO,
                                COLONIA = d.COLONIA,
                                CALLE = d.COLONIA,
                                CP = d.CP,
                                NUMERO = d.NUMERO,

                                ID = p.ID,
                                NOMBRE = p.NOMBRE,
                                TELEFONO = p.TELEFONO,
                                CORREO = p.CORREO,
                                RFC = p.RFC
                            }).ToList().First();
            }

            return View(provider);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        public ActionResult Create(ProviderAddress models)
        {

            if (ModelState.IsValid)
            {
                using (HealthEntities db = new HealthEntities())
                {

                    DIRECCION address = new DIRECCION();
                    address.ID = 0;
                    address.ACTIVO = 1;
                    address.CALLE = models.CALLE;
                    address.ESTADO = models.ESTADO;
                    address.CIUDAD = models.CIUDAD;
                    address.MUNICIPIO = models.MUNICIPIO;
                    address.COLONIA = models.COLONIA;
                    address.CP = models.CP;
                    address.NUMERO = models.NUMERO;
                    address.CREATED_AT = DateTime.Now;
                    db.DIRECCION.Add(address);
                    PROVEEDOR provider = new PROVEEDOR();
                    provider.NOMBRE = models.NOMBRE;
                    provider.TELEFONO = models.TELEFONO;
                    provider.CORREO = models.CORREO;
                    provider.RFC = models.RFC;
                    provider.FK_DIRECCION = address.ID;
                    provider.ACTIVO = 1;
                    provider.CREATED_AT = DateTime.Now;
                    db.PROVEEDOR.Add(provider);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            return View(models);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int id)
        {
            ProviderAddress provider;

            using (HealthEntities db = new HealthEntities())
            {
                provider = (from p in db.PROVEEDOR
                            join d in db.DIRECCION
                            on p.FK_DIRECCION equals d.ID
                            where p.ID == id
                            select new ProviderAddress
                            {
                                IDADDRESS = d.ID,
                                ESTADO = d.ESTADO,
                                CIUDAD = d.CIUDAD,
                                MUNICIPIO = d.MUNICIPIO,
                                COLONIA = d.COLONIA,
                                CALLE = d.COLONIA,
                                CP = d.CP,
                                NUMERO = d.NUMERO,

                                ID = p.ID,
                                NOMBRE = p.NOMBRE,
                                TELEFONO = p.TELEFONO,
                                CORREO = p.CORREO,
                                RFC = p.RFC
                            }).ToList().First();
            }


            return View(provider);
        }

        // POST: Proveedores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProviderAddress models)
        {

            using (HealthEntities db = new HealthEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {


                        PROVEEDOR provider = db.PROVEEDOR.Find(id);
                        DIRECCION address = provider.DIRECCION;

                        address.CALLE = models.CALLE;
                        address.ESTADO = models.ESTADO;
                        address.CIUDAD = models.CIUDAD;
                        address.MUNICIPIO = models.MUNICIPIO;
                        address.COLONIA = models.COLONIA;
                        address.CP = models.CP;
                        address.NUMERO = models.NUMERO;

                        provider.NOMBRE = models.NOMBRE;
                        provider.TELEFONO = models.TELEFONO;
                        provider.CORREO = models.CORREO;
                        provider.RFC = models.RFC;
                        provider.DIRECCION = address;

                        db.Entry(provider).State = System.Data.Entity.EntityState.Modified;
                        
                        db.Entry(address).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction("Index");
            }
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int id)
        {
            var success = false;
            var message = "Error";

            if (id != null) {
                using(HealthEntities db = new HealthEntities()){
                    PROVEEDOR provider = db.PROVEEDOR.Find(id);
                    provider.ACTIVO = 0;
                    db.Entry(provider).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                success = true;
                message = "Transaccion correcta";
            }

            return Json(new {
                success,
                message 
            }, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Ordenes(int id)
        {
            HealthEntities db = new HealthEntities();

            List<ORDEN_PROVEEDOR> orders = db.ORDEN_PROVEEDOR
                .Where(order => order.FK_PROVEEDOR == id)
                .ToList();

            return View(orders);
        }
    }
}
