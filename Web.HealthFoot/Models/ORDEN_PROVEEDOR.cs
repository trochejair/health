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
    
    public partial class ORDEN_PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDEN_PROVEEDOR()
        {
            this.INSUMO_ORDEN = new HashSet<INSUMO_ORDEN>();
        }
    
        public int ID { get; set; }
        public int FK_PROVEEDOR { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public System.DateTime CREATED_AT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INSUMO_ORDEN> INSUMO_ORDEN { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
    }
}
