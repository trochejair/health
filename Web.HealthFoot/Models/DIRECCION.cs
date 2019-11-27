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
    using System.ComponentModel.DataAnnotations;

    public partial class DIRECCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIRECCION()
        {
            this.PROVEEDOR = new HashSet<PROVEEDOR>();
            this.VENTA = new HashSet<VENTA>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage = "El Estado es requerido")]
        public string ESTADO { get; set; }
        [Required(ErrorMessage = "La Ciudad es requerida")]
        public string CIUDAD { get; set; }
        [Required(ErrorMessage = "El municipio es requerido")]
        public string MUNICIPIO { get; set; }
        [Required(ErrorMessage = "La colonia es requerida")]
        public string COLONIA { get; set; }
        [Required(ErrorMessage = "La calle es requerida")]
        public string CALLE { get; set; }
        [Required(ErrorMessage = "El código postal es requerido")]
        [Range(0, 99999)]
        public string CP { get; set; }
        [Required]
        public string NUMERO { get; set; }
        public Nullable<int> ACTIVO { get; set; }
        public System.DateTime CREATED_AT { get; set; }
        public Nullable<int> FK_CLIENTE { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVEEDOR> PROVEEDOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTA> VENTA { get; set; }
    }
}
