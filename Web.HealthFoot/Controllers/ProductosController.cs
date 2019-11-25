using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {



        // GET: Productos
        public ActionResult Index()
        {

            HealthEntities db = new HealthEntities();
            List<PRODUCTO> products = db.PRODUCTO.ToList();

            return View(products);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            HealthEntities db = new HealthEntities();
            List<INSUMO> supplies = db.INSUMO.ToList();
            List<CATEGORIA> category = db.CATEGORIA.ToList();
            ViewBag.insumos = supplies;
            ViewBag.categotias = category;

            ViewBag.Category = new SelectList(category, "ID", "NOMBRE"); ;
            ViewBag.Supplies = new SelectList(supplies, "ID", "NOMBRE"); ;

            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            var success = false;
            var message = "";
            var data = 0;
            List<List<string>> errors = new List<List<string>>();

            var nombre = formCollection["nombre"];
            var descripcion = formCollection["descripcion"];
            var cantidad = formCollection["cantidad"];
            var categoria = formCollection["Category"];
            var precio = formCollection["precio"];

            if (nombre.Trim().Length == 0)
            {
                List<string> name = new List<string>();
                name.Add("nombre");
                name.Add("Nombre necesario");
                errors.Add(name);
            }
            if (descripcion.Trim().Length == 0)
            {
                List<string> description = new List<string>();
                description.Add("descripcion");
                description.Add("Descripcion necesaria");
                errors.Add(description);
            }
            if (cantidad.Trim().Length == 0)
            {
                List<string> quantity = new List<string>();
                quantity.Add("cantidad");
                quantity.Add("Cantidad necesaria");
                errors.Add(quantity);
            }
            if (precio.Trim().Length == 0)
            {
                List<string> price = new List<string>();
                price.Add("precio");
                price.Add("Precio necesario");
                errors.Add(price);
            }

            if (errors.Count == 0)
            {
                using (HealthEntities db = new HealthEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        //                 try
                        //                   {
                        PRODUCTO product = new PRODUCTO();
                        product.NOMBRE = nombre;
                        product.DESCRIPCION = descripcion;
                        product.CANTIDAD = Int32.Parse(cantidad);
                        product.ACTIVO = 1;
                        product.FK_CATEGORIA = Int32.Parse(categoria);
                        product.PRECIO = float.Parse(precio);
                        product.CREATED_AT = DateTime.Now;
                        db.PRODUCTO.Add(product);
                        db.SaveChanges();
                        transaction.Commit();
                        data = product.ID;
                        success = true;


                        //                    }
                        // catch
                        //{
                        //   transaction.Rollback();

                        //}


                    }

                }
            }



            return Json(new
            {
                success,
                message,
                data,
                errors
            });
        }

        public ActionResult Edit(int id)
        {
            HealthEntities db = new HealthEntities();
            List<INSUMO> supplies = db.INSUMO.ToList();
            List<CATEGORIA> category = db.CATEGORIA.ToList();
            ViewBag.insumos = supplies;
            ViewBag.categotias = category;

            ViewBag.Category = category;
            ViewBag.Supplies = new SelectList(supplies, "ID", "NOMBRE"); ;

            PRODUCTO product = db.PRODUCTO.Find(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            var success = false;
            var message = "";
            var data = 0;
            List<List<string>> errors = new List<List<string>>();

            var nombre = formCollection["nombre"];
            var descripcion = formCollection["descripcion"];
            var cantidad = formCollection["cantidad"];
            var categoria = formCollection["Category"];
            var precio = formCollection["precio"];

            if (nombre.Trim().Length == 0)
            {
                List<string> name = new List<string>();
                name.Add("nombre");
                name.Add("Nombre necesario");
                errors.Add(name);
            }
            if (descripcion.Trim().Length == 0)
            {
                List<string> description = new List<string>();
                description.Add("descripcion");
                description.Add("Descripcion necesaria");
                errors.Add(description);
            }
            if (cantidad.Trim().Length == 0)
            {
                List<string> quantity = new List<string>();
                quantity.Add("cantidad");
                quantity.Add("Cantidad necesaria");
                errors.Add(quantity);
            }
            if (precio.Trim().Length == 0)
            {
                List<string> price = new List<string>();
                price.Add("precio");
                price.Add("Precio necesario");
                errors.Add(price);
            }

            if (errors.Count == 0)
            {
                using (HealthEntities db = new HealthEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        //                 try
                        //                   {
                        PRODUCTO product = db.PRODUCTO.Find(id);
                        product.NOMBRE = nombre;
                        product.DESCRIPCION = descripcion;
                        product.CANTIDAD = Int32.Parse(cantidad);
                        product.ACTIVO = 1;
                        product.FK_CATEGORIA = Int32.Parse(categoria);
                        product.PRECIO = float.Parse(precio);
                        db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                        data = product.ID;
                        success = true;


                        //                    }
                        // catch
                        //{
                        //   transaction.Rollback();

                        //}


                    }

                }



            }

            return Json(new
            {
                success,
                message,
                data,
                errors
            });
        }

        public ActionResult Details()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Images(int id)
        {
            var success = false;
            var message = "";


            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Content", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "ImagesProduct");

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        Random rnd = new Random();
                        int rndx = rnd.Next(0, 1000);

                        var fileNamedb = "img_" + id + rndx + "_" + file.FileName;
                        var path = string.Format("{0}\\{1}", pathString, fileNamedb);
                        file.SaveAs(path);

                        using (HealthEntities db = new HealthEntities())
                        {
                            IMAGEN_PRODUCTO image = new IMAGEN_PRODUCTO();
                            image.FK_PRODUCTO = id;
                            image.IMAGEN = fileNamedb;
                            db.IMAGEN_PRODUCTO.Add(image);
                            db.SaveChanges();
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }
            return Json(new { Message = fName });
        }
        [HttpPost]
        public ActionResult DeleteImages(FormCollection formCollection) {
            var success = false;
            var message = "";

            var allKey = formCollection.AllKeys;
            var count = allKey.Length;

            using (HealthEntities db = new HealthEntities()) { 
                for (var x = 0; x < count; x++)
                {
                    string key = allKey[x];
                    var imageId = formCollection[key];
                    IMAGEN_PRODUCTO img= db.IMAGEN_PRODUCTO.Find(Int32.Parse(imageId));
                    db.Entry(img).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                success = true;
                message = "Se eliminarion imagenes";
            }


            return Json(new
            {
                success,
                message,
            });
        }


        [HttpPost]
        public ActionResult DeleteFormula(int id,FormCollection formCollection)
        {
            var success = false;
            var message = "";
            
            return Json(new
            {
                success,
                message,
            });
        }

        [HttpPost]
        public ActionResult NewFormula(int id,FormCollection formCollection)
        {
            var success = false;
            var message = "";

            return Json(new
            {
                success,
                message,
            });
        }
    }
}
