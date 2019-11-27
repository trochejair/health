using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.HealthFoot.Models
{
    public class RolModelo
    {

        public RolModelo()
        {

        }

        public List<AspNetRoles> findAll()
        {

            using (var db = new HealthEntities())
            {

                List<AspNetRoles> roles = db.AspNetRoles.ToList();
                return roles;

            }

        }

        public List<EMPLEADO> findEmp(int id) {

            using (var db = new HealthEntities())
            {

                List<EMPLEADO> emp = db.EMPLEADO.Where(e => e.ROL == id).ToList();
                return emp;

            }

        }

        public AspNetRoles find(String Id)
        {

            using (var db = new HealthEntities())
            {

                return db.AspNetRoles.Find(Id);

            }

        }

        public int idNuevo() {

            try
            {

                using (HealthEntities db = new HealthEntities()) {

                    return db.AspNetRoles.Count()+1;

                }

            }
            catch(Exception e) {

                return 0;

            }

        }

        public int insert(AspNetRoles rol) {

            try
            {

                using (var db = new HealthEntities())
                {

                    if (db.AspNetRoles.Find(rol.Id) == null)
                    {

                        db.AspNetRoles.Add(rol);
                        db.SaveChanges();

                        return 1;

                    }
                    else {

                        return 0;

                    }

                }

            }
            catch (Exception e) {

                return -1;

            }

        }

        public Boolean edit(AspNetRoles rol)
        {

            try
            {
                using (var db = new HealthEntities())
                {

                    AspNetRoles rMod = db.AspNetRoles.Find(rol.Id);

                    rMod.Name = rol.Name;

                    db.SaveChanges();

                    return true;

                }

            }
            catch (Exception e)
            {

                return false;

            }

        }

        public Boolean delete(String id) {

            try
            {

                using (var db = new HealthEntities())
                {

                    var rol = db.AspNetRoles.Find(id);
                    db.AspNetRoles.Remove(rol);

                    foreach (var emp in findEmp(Convert.ToInt32(id))) {

                        emp.ROL = null;

                    }

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