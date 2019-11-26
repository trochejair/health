using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.HealthFoot.Models.ViewModelsEmpRol
{
    public class ViewModelEmpleado
    {

        public int ID { get; set; }

        [Required(ErrorMessage="El correo electronico es requerido")]
        [EmailAddress]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El apellido paterno es requerido")]
        public string APELIDO_PATERNO { get; set; }

        [Required(ErrorMessage = "El apellido materno es requerido")]
        public string APELLIDO_MATERNO { get; set; }

        [Required(ErrorMessage = "Es necesario definir un rol al empleado")]
        public Nullable<int> ROL { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Es necesario el estado del empleado")]
        public Nullable<int> ACTIVO { get; set; }

    }
}