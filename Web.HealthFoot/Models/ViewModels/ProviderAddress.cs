using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Web.HealthFoot.Models
{
    public class ProviderAddress
    {

        public int ID { get; set; }
        public int IDADDRESS { get; set; }
        /****** IT IS ADDRESS INFO ********/


        [Required]
        public string ESTADO { get; set; }
        [Required]
        public string CIUDAD { get; set; }
        [Required]
        public string MUNICIPIO { get; set; }
        [Required]
        public string COLONIA { get; set; }
        [Required]
        public string CALLE { get; set; }
        [Required]
        public string CP { get; set; }
        [Required]
        public string NUMERO { get; set; }

        /************INFO PROVIDER****************/

        [Required]
        public string NOMBRE { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string TELEFONO { get; set; }
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string CORREO { get; set; }
        [Required]
        public string RFC { get; set; }

    }
}