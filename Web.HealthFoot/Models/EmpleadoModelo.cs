using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.HealthFoot.Models.ViewModelsEmpRol;

namespace Web.HealthFoot.Models
{
    public class EmpleadoModelo
    {

        ApplicationDbContext context = new ApplicationDbContext();

        public EmpleadoModelo()
        {

        }

        public List<ViewModelEmpleadoEdit> findAll()
        {

            List<ViewModelEmpleadoEdit> datos;
            using (var db = new HealthEntities())
            {
            
                datos = (from e in db.EMPLEADO
                         join u in db.AspNetUsers
                         on e.EMAIL equals u.Email
                         select new ViewModelEmpleadoEdit
                         {

                             ID = e.ID,
                             EMAIL = e.EMAIL,
                             UserName = u.UserName,
                             PhoneNumber = u.PhoneNumber,
                             APELIDO_PATERNO = e.APELIDO_PATERNO,
                             APELLIDO_MATERNO = e.APELLIDO_MATERNO,
                             ROL = e.ROL,
                             ACTIVO = e.ACTIVO,
                             CREATED_AT = e.CREATED_AT

                         }).ToList();

                return datos;

            }

        }

        public ViewModelEmpleadoEdit find(int Id)
        {

            ViewModelEmpleadoEdit datos;
            using (var db = new HealthEntities())
            {

                datos = (from e in db.EMPLEADO
                         join u in db.AspNetUsers
                         on e.EMAIL equals u.Email
                         where e.ID == Id
                         select new ViewModelEmpleadoEdit
                         {

                             ID = e.ID,
                             EMAIL = e.EMAIL,
                             UserName = u.UserName,
                             PhoneNumber = u.PhoneNumber,
                             APELIDO_PATERNO = e.APELIDO_PATERNO,
                             APELLIDO_MATERNO = e.APELLIDO_MATERNO,
                             ROL = e.ROL,
                             ACTIVO = e.ACTIVO,
                             CREATED_AT = e.CREATED_AT

                         }).ToList().First();

                return datos;

            }

        }

        public EMPLEADO findEmp(int Id)
        {

            using (var db = new HealthEntities()) {

                return db.EMPLEADO.Find(Id);

            }

        }

        public ApplicationUser findUs(EMPLEADO emp)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return userManager.FindByEmail(emp.EMAIL);

        }

        public int insert(EMPLEADO emp,AspNetUsers user) {

            try
            {
                using (var db = new HealthEntities())
                {

                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    using (var dbTransaccion = db.Database.BeginTransaction()) {

                        if (db.EMPLEADO.Where(e => e.EMAIL == emp.EMAIL).Count() == 0 && userManager.FindByEmail(user.Email)==null)
                        {

                            try
                            {
                                
                                var us = new ApplicationUser();
                                
                                us.Email = user.Email;
                                us.UserName = user.UserName;
                                us.PhoneNumber = user.PhoneNumber;
                                string password = user.PasswordHash;
                                
                                userManager.Create(us, password);
                                
                                db.EMPLEADO.Add(emp);
                                db.SaveChanges();

                                dbTransaccion.Commit();

                                return 1;

                            }
                            catch (Exception e) {

                                dbTransaccion.Rollback();

                                return -1;

                            }

                        }
                        else
                        {

                            return 0;

                        }

                    }

                }

            }
            catch (Exception e) {

                return -1;

            }

        }

        public int edit(EMPLEADO emp,String Email,ApplicationUser user)
        {

            try
            {
                using (var db = new HealthEntities())
                {

                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    using (var dbTransaccion = db.Database.BeginTransaction())
                    {

                        if (emp.EMAIL==Email || db.EMPLEADO.Where(e => e.EMAIL == emp.EMAIL).Count()==0)
                        {

                            try
                            {

                                var us = userManager.FindByEmail(Email);
                                us.UserName = user.UserName;
                                us.Email = user.Email;
                                us.PhoneNumber = user.PhoneNumber;

                                userManager.Update(us);

                                EMPLEADO eMod = db.EMPLEADO.Find(emp.ID);

                                eMod.APELIDO_PATERNO = emp.APELIDO_PATERNO;
                                eMod.APELLIDO_MATERNO = emp.APELLIDO_MATERNO;
                                eMod.EMAIL = emp.EMAIL;
                                eMod.ACTIVO = emp.ACTIVO;
                                eMod.ROL = emp.ROL;

                                db.SaveChanges();

                                dbTransaccion.Commit();

                                return 1;

                            }
                            catch (Exception e)
                            {

                                dbTransaccion.Rollback();

                                return -1;

                            }

                        }
                        else {

                            return 0;

                        }

                    }

                }

            }
            catch (Exception e)
            {

                return -1;

            }

        }

        public Boolean delete(int id) {

            try
            {

                using (var db = new HealthEntities())
                {

                    var empleado = db.EMPLEADO.Find(id);
                    db.EMPLEADO.Remove(empleado);
                    db.SaveChanges();

                    return true;

                }

            }
            catch (Exception e) {

                return false;

            }

        }

    }

}