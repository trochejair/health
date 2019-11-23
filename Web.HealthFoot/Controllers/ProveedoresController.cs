﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class ProveedoresController : Controller
    {

        // GET: Proveedores
        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction("Proveedores", "Compras");


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

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proveedores/Delete/5
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

        public ActionResult Ordenes(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
