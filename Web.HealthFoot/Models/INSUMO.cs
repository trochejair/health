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
    
    public partial class INSUMO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INSUMO()
        {
            this.INSUMO_ORDEN = new HashSet<INSUMO_ORDEN>();
        }
    
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<int> ACTIVO { get; set; }
        public System.DateTime CREATED_AT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INSUMO_ORDEN> INSUMO_ORDEN { get; set; }
    }
}