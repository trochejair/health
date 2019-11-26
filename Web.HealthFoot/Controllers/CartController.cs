using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.HealthFoot.Models;
using System.Data.Entity;

namespace Web.HealthFoot.Controllers
{
    public class CartController : Controller
    {

        private HealthEntities db = new HealthEntities();

        [Authorize]
        public ActionResult Index()
        {
            string username = User.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            int idcliente = cliente.ID;
            var detalle_orden = db.DETALLE_ORDEN.Include(d => d.ORDEN).Include(d => d.PRODUCTO).Where(d => d.ORDEN.FK_CLIENTE == idcliente && d.ORDEN.ACTIVO == 1);
            //var imagenes = db.IMAGEN_PRODUCTO;
            return View(detalle_orden.ToList());

        }

        public ActionResult Agregar(int id)
        {

            DETALLE_ORDEN detalle = db.DETALLE_ORDEN.Find(id);
            PRODUCTO producto = db.PRODUCTO.Find(detalle.FK_PRODUCTO);
            if (producto.CANTIDAD >= 1)
            {

                detalle.CANTIDAD = detalle.CANTIDAD + 1;
                detalle.SUBTOTAL = ((detalle.CANTIDAD) * detalle.PRODUCTO.PRECIO);

                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();

                producto.CANTIDAD = producto.CANTIDAD - 1;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                ViewBag.Errors = "Producto fuera de existencia";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Quitar(int id)
        {
            DETALLE_ORDEN detalle = db.DETALLE_ORDEN.Find(id);
            PRODUCTO producto = db.PRODUCTO.Find(detalle.FK_PRODUCTO);
            if (detalle.CANTIDAD>1)
            {
                
                detalle.CANTIDAD = detalle.CANTIDAD - 1;
                detalle.SUBTOTAL = ((detalle.CANTIDAD) * detalle.PRODUCTO.PRECIO);

                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();

                producto.CANTIDAD = producto.CANTIDAD + 1;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();


            }
            else
            {
                producto.CANTIDAD = producto.CANTIDAD + 1;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                db.DETALLE_ORDEN.Remove(detalle);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            DETALLE_ORDEN detalle = db.DETALLE_ORDEN.Find(id);
            PRODUCTO producto = db.PRODUCTO.Find(detalle.FK_PRODUCTO);
            producto.CANTIDAD =producto.CANTIDAD+detalle.CANTIDAD;
            db.DETALLE_ORDEN.Remove(detalle);
            //db.Entry(detalle).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Entrega()
        {

            string username = User.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            int idcliente = cliente.ID;
            var orden = db.ORDEN.Where(d=>d.ACTIVO==1).Where(d=>d.FK_CLIENTE==idcliente).First();
            if (orden.ACTIVO == 1)
            {
                var detalle = db.DETALLE_ORDEN.Where(d => d.FK_ORDEN == orden.ID).Sum(d => d.CANTIDAD*d.PRODUCTO.PRECIO);
                ViewBag.Total = detalle;
                ViewBag.Iva = detalle * 0.16;
                ViewBag.Subtotal = detalle - (detalle * .16);
                var Direcciones = cliente.DIRECCION.ToList();

                return View(Direcciones);
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Finalizar(FormCollection form)
        {

            var idDirec = form["selection"];
            string username = User.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            int idcliente = cliente.ID;
            var orden = db.ORDEN.Where(d => d.ACTIVO == 1).Where(d => d.FK_CLIENTE == idcliente).First();

            VENTA venta = new VENTA();
            venta.FK_ORDEN = orden.ID;

            venta.CREATED_AT= System.DateTime.Now;
            venta.FECHA = System.DateTime.Now;
            venta.FK_DIRECCION = Int32.Parse(idDirec);
            db.VENTA.Add(venta);
            db.SaveChanges();

            orden.ACTIVO = 0;
            db.Entry(orden).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Product","Home");
        }


        [HttpPost]
        public ActionResult AddCart(FormCollection form)
        {
            var success = false;
            var message = "Error del servidor";
            var session = User.Identity.GetUserName();
            Models.CLIENTE client = null;
             Models.ORDEN order = null;
            Models.PRODUCTO product = null;

            if (session != "")
            {
                using (HealthEntities db = new HealthEntities())
                {
                    client = db.CLIENTE.Where(clientdb => clientdb.EMAIL == session).First();

                    if (db.ORDEN.ToList().Count > 0)
                    {
                        try
                        {

                            order = db.ORDEN.Where(orderdb => orderdb.FK_CLIENTE == client.ID)
                                .Where(orderdb => orderdb.ACTIVO == 1)
                                .First();
                        }
                        catch {
                            order = null;
                        }

                    }
                    product = db.PRODUCTO.Find(Int32.Parse( form["product-id"]));
                    if (product.CANTIDAD > 0)
                    {
                        if (order == null)
                        {
                            order = new ORDEN();
                            order.FECHA = System.DateTime.Now;
                            order.FK_CLIENTE = client.ID;
                            order.ESTATUS = "En espera";
                            order.ACTIVO = 1;
                            order.CREATED_AT = System.DateTime.Now;
                            db.ORDEN.Add(order);
                            db.SaveChanges();

                        }

                        Models.DETALLE_ORDEN detailOrder = new DETALLE_ORDEN();
                        detailOrder.FK_ORDEN = order.ID;
                        detailOrder.FK_PRODUCTO = product.ID;
                        detailOrder.CANTIDAD = 1;
                        detailOrder.SUBTOTAL = product.PRECIO * 1;
                        product.CANTIDAD = product.CANTIDAD - 1;

                        db.DETALLE_ORDEN.Add(detailOrder);
                        db.SaveChanges();
                        db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        success = true;
                        message = "Producto Agregado";

                    }
                    else
                    {
                        message = "Producto Agotado";
                    }


                }
            }
            else
            {
                message = "Inice sesión";
            }
            return Json(new {
                success,
                message
            });
        }
    }
}