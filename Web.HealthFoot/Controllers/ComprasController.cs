using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public class ComprasController : Controller
    {


        HealthEntities db = new HealthEntities();
        // GET: Providers
        public ActionResult Proveedores()
        {
            List<ProviderAddress> list;

                list = (from p in db.PROVEEDOR
                        join d in db.DIRECCION
                        on p.FK_DIRECCION equals d.ID
                        select new ProviderAddress
                        {
                            IDADDRESS =d.ID,
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

        // GET: Providers
        public ActionResult Insumos()
        {

            List<INSUMO> list;
            list = db.INSUMO.ToList();
            return View(list);
        }

        // GET: Providers
        public ActionResult Ordenes()
        {
            List<ORDEN_PROVEEDOR> list;
            list = db.ORDEN_PROVEEDOR.ToList();
            return View(list);
        }

    }
}
