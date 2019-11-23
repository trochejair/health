using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.HealthFoot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
            /*using (var prod = new DefaultConnectionEntities())
            {
                var productos = prod.PRODUCTO.ToList();
                return View(productos);
            }*/
            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }
    }
}