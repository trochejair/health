//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.HealthFoot.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLEADO
    {
        public int ID { get; set; }
        public string EMAIL { get; set; }
        public string APELIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public Nullable<int> ROL { get; set; }
        public System.DateTime CREATED_AT { get; set; }
        public Nullable<int> ACTIVO { get; set; }
    }
}
