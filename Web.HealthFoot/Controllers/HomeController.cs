using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ind = new HealthEntities())
            {
                //Cuando es una búsqueda general, se invoca al método List
                var productos = ind.PRODUCTO.ToList();
                return View(productos);
            }
            
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Product()
        {
            var prod = new HealthEntities();
           
            var productos = prod.PRODUCTO.ToList();
            var img = prod.IMAGEN_PRODUCTO.ToList();
            return View(productos);
            

            
        }

        public ActionResult ProductDetail(int Id)
        {
            var db = new HealthEntities();
            var Producto = db.PRODUCTO.Find(Id);
            return View(Producto);
                          
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }
        [Authorize]
        public ActionResult Profile()
        {
            CLIENTE client = null;
            using (HealthEntities db = new HealthEntities())

            {
                var email = User.Identity.GetUserName();

                client = db.CLIENTE.Where(clientdb => clientdb.EMAIL == email).First();

            }

            return View(client);
        }
    }
}