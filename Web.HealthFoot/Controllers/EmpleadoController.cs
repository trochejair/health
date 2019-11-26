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
    public class EmpleadoController : Controller
    {

        EmpleadoModelo modelo = new EmpleadoModelo();
        RolModelo rol = new RolModelo();

        public ActionResult List()
        {

            List<ViewModelEmpleadoEdit> lista = modelo.findAll();

            return View(lista);

        }

        public ActionResult Show(int id)
        {

            return View(modelo.find(id));

        }

        public ActionResult Create()
        {

            ViewBag.Roles = rol.findAll();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelEmpleado request)
        {

            if (ModelState.IsValid)
            {

                DateTime fecha = DateTime.Now;

                EMPLEADO emp = new EMPLEADO();
                AspNetUsers users = new AspNetUsers();

                users.Email = request.EMAIL;
                users.UserName = request.UserName;
                users.PhoneNumber = request.PhoneNumber;
                users.PasswordHash = request.Password;

                emp.EMAIL = request.EMAIL;
                emp.APELIDO_PATERNO = request.APELIDO_PATERNO;
                emp.APELLIDO_MATERNO = request.APELLIDO_MATERNO;
                emp.ACTIVO = request.ACTIVO;
                //emp.ROL = request.ROL;
                emp.CREATED_AT = fecha;

                int resultado = modelo.insert(emp,users);

                if (resultado == 1)
                {

                    return RedirectToAction("List", "Empleado");

                }
                else if (resultado == 0)
                {

                    ViewBag.Mensaje = "El email ya existe";
                    return View(request);

                }
                else
                {

                    ViewBag.Mensaje = "Ocurrio un error inesperado, por favor intentelo mas tarde";
                    return View(request);

                }

            }
            else {

                return View(request);

            }

        }

        public ActionResult Edit(int id)
        {

            ViewModelEmpleadoEdit e = modelo.find(id);

            ViewBag.Roles = rol.findAll();

            return View(e);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEmpleadoEdit request)
        {

            if (ModelState.IsValid)
            {

                EMPLEADO emp = modelo.findEmp(request.ID);
                ApplicationUser user = modelo.findUs(emp);

                string email = emp.EMAIL;  

                emp.EMAIL = request.EMAIL;
                emp.APELIDO_PATERNO = request.APELIDO_PATERNO;
                emp.APELLIDO_MATERNO = request.APELLIDO_MATERNO;
                emp.ACTIVO = request.ACTIVO;
                emp.ROL = request.ROL;

                user.Email = request.EMAIL;
                user.UserName = request.UserName;
                user.PhoneNumber = request.PhoneNumber;

                int resultado = modelo.edit(emp,email,user);

                if (resultado == 1)
                {

                    return RedirectToAction("List", "Empleado");

                }
                else if (resultado == 0)
                {

                    ViewBag.Mensaje = "El email ya existe";
                    return View(request);

                }
                else
                {

                    ViewBag.Mensaje = "Ocurrio un error inesperado, por favor intentelo mas tarde";
                    return View(request);

                }

            }
            else
            {

                return View(request);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            if (modelo.delete(id))
            {

                return RedirectToAction("List", "Empleado");

            }

            ViewBag.Mensaje = "Ocurrio un error inesperado";

            return RedirectToAction("List", "Empleado");

        }

    }

}