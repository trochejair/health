using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Web.HealthFoot.Models;

namespace Web.HealthFoot.Controllers
{
    public static class UserId
    {
        private static HealthEntities db = new HealthEntities();
        public static int getUserId(this ClaimsPrincipal user)
        {

            string username = user.Identity.GetUserName();
            var cliente = db.CLIENTE.Where(d => d.EMAIL == username).First();
            return cliente.ID;

        }

    }
}