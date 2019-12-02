using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class DireccionController : Controller
    {
        private HealthEntities db = new HealthEntities();

        // GET: Direccion
        public ActionResult Index()
        {
            string username = User.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            int idcliente = cliente.ID;
            var dIRECCION = db.DIRECCION.Include(d => d.CLIENTE).Where(d => d.FK_CLIENTE == idcliente);
            return View(dIRECCION.ToList());
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string username = User.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            int idcliente = cliente.ID;
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null || dIRECCION.FK_CLIENTE != idcliente)
            {
                return RedirectToAction("Index");
            }
            return View(dIRECCION);
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            ViewBag.FK_CLIENTE = new SelectList(db.CLIENTE, "ID", "NOMBRE");
            return View();
        }

        // POST: Direccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,CIUDAD,MUNICIPIO,COLONIA,CALLE,CP,NUMERO,ACTIVO,CREATED_AT,FK_CLIENTE")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                var emailAuth = User.Identity.GetUserName();
                dIRECCION.CREATED_AT = System.DateTime.Now;

                var cliente = db.CLIENTE.Where(client => client.EMAIL == emailAuth).First();

                dIRECCION.FK_CLIENTE = cliente.ID;
                dIRECCION.ACTIVO = 1;
                db.DIRECCION.Add(dIRECCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_CLIENTE = new SelectList(db.CLIENTE, "ID", "NOMBRE", dIRECCION.FK_CLIENTE);
            return View(dIRECCION);
        }

        // GET: Direccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            string username = User.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            int idcliente = cliente.ID;
            if (dIRECCION == null || dIRECCION.FK_CLIENTE != idcliente)
            {
                return RedirectToAction("Index");
            }
            ViewBag.FK_CLIENTE = new SelectList(db.CLIENTE, "ID", "NOMBRE", dIRECCION.FK_CLIENTE);
            return View(dIRECCION);
        }

        // POST: Direccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,CIUDAD,MUNICIPIO,COLONIA,CALLE,CP,NUMERO,ACTIVO,CREATED_AT,FK_CLIENTE")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIRECCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_CLIENTE = new SelectList(db.CLIENTE, "ID", "NOMBRE", dIRECCION.FK_CLIENTE);
            return View(dIRECCION);
        }

        // GET: Direccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string username = User.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            int idcliente = cliente.ID;
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null || dIRECCION.FK_CLIENTE != idcliente)
            {

                return RedirectToAction("Index");
            }
            return View(dIRECCION);
        }

        // POST: Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            db.DIRECCION.Remove(dIRECCION);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
