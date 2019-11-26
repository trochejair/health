using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.HealthFoot.Models.ViewModels
{
    public class InsumoViewModel
    {
        [Required]
        [Display(Name ="Nombre")]
        public string NOMBRE { get; set; }

    }
}