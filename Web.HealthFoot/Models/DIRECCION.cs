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
    
    public partial class DIRECCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIRECCION()
        {
            this.PROVEEDOR = new HashSet<PROVEEDOR>();
            this.VENTA = new HashSet<VENTA>();
        }
    
        public int ID { get; set; }
        public string ESTADO { get; set; }
        public string CIUDAD { get; set; }
        public string MUNICIPIO { get; set; }
        public string COLONIA { get; set; }
        public string CALLE { get; set; }
        public string CP { get; set; }
        public string NUMERO { get; set; }
        public Nullable<int> ACTIVO { get; set; }
        public System.DateTime CREATED_AT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVEEDOR> PROVEEDOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTA> VENTA { get; set; }
    }
}
