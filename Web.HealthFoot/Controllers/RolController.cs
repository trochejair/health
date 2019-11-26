using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.HealthFoot.Models;
using Web.HealthFoot.Models.ViewModelsEmpRol;

namespace Web.HealthFoot.Controllers
{
    public class RolController : Controller
    {

        RolModelo modelo = new RolModelo();

        public ActionResult List()
        {

            List<AspNetRoles> lista = modelo.findAll();
            return View(lista);

        }

        public ActionResult Show(String id)
        {

            return View(modelo.find(id));

        }

        public ActionResult Create()
        {

            

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelRol request)
        {

            if (ModelState.IsValid)
            {
                AspNetRoles rol = new AspNetRoles();

                rol.Id = modelo.idNuevo().ToString();
                rol.Name = request.Name;

                int resultado = modelo.insert(rol);

                if (resultado == 1)
                {

                    return RedirectToAction("List", "Rol");

                }
                else if (resultado == 0)
                {

                    ViewBag.Mensaje = "El rol ya existe";
                    return View(request);

                }
                else {

                    ViewBag.Mensaje = "Ocurrio un error inesperado, por favor intentelo mas tarde";
                    return View(request);

                }

            }
            else {

                return View(request);

            }

        }

        public ActionResult Edit(String id)
        {

            AspNetRoles rol = modelo.find(id);

            ViewModelRol r = new ViewModelRol();

            r.Id = rol.Id;
            r.Name = rol.Name;

            return View(r);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelRol request)
        {

            if (ModelState.IsValid)
            {

                AspNetRoles rol = modelo.find(request.Id);

                if (request.Name != rol.Name)
                {

                    rol.Name = request.Name;

                    if (!modelo.edit(rol))
                    {

                        ViewBag.Mensaje = "El rol ya existe";
                        return View(request);

                    }

                }

                return RedirectToAction("List", "Rol");

            }
            else
            {

                return View(request);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(String id)
        {

            if (modelo.delete(id)) {

                return RedirectToAction("List", "Empleado");

            }

            ViewBag.Mensaje = "Ocurrio un error inesperado";

            return RedirectToAction("List", "Rol");

        }

    }

}