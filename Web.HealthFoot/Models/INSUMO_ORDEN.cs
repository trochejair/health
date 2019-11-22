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
    
    public partial class INSUMO_ORDEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INSUMO_ORDEN()
        {
            this.FORMULA = new HashSet<FORMULA>();
        }
    
        public int ID { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public string UNIDAD_MEDIDA { get; set; }
        public Nullable<int> ACTIVO { get; set; }
        public System.DateTime CREATED_AT { get; set; }
        public int FK_ORDEN_PROVEEDOR { get; set; }
        public int FK_INSUMO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORMULA> FORMULA { get; set; }
        public virtual INSUMO INSUMO { get; set; }
        public virtual ORDEN_PROVEEDOR ORDEN_PROVEEDOR { get; set; }
    }
}