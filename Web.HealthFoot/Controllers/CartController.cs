using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart
        [Authorize]
        public ActionResult Index()
        {

            return View();
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
                        order = db.ORDEN.Where(orderdb => orderdb.FK_CLIENTE == client.ID)
                            .Where(orderdb => orderdb.ACTIVO == 1)
                            .First();
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