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
    
    public partial class ENTREGA
    {
        public int ID { get; set; }
        public int ID_VENTA { get; set; }
        public int ID_EMBARQUE { get; set; }
    
        public virtual EMBARQUE EMBARQUE { get; set; }
    }
}
