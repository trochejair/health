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
    
    public partial class EMBARQUE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMBARQUE()
        {
            this.ENTREGA = new HashSet<ENTREGA>();
        }
    
        public int ID { get; set; }
        public int ID_RUTA { get; set; }
        public int ID_VEHICULO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<int> ACTIVO { get; set; }
        public System.DateTime CREATED_AT { get; set; }
    
        public virtual RUTA RUTA { get; set; }
        public virtual VEHICULO VEHICULO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENTREGA> ENTREGA { get; set; }
    }
}
