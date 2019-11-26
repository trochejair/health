using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.HealthFoot.Models.ViewModelsEmpRol
{
    public class ViewModelRol
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

    }
}