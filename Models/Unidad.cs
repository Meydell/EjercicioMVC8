//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjercicioMVC8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Unidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unidad()
        {
            this.Estadias = new HashSet<Estadia>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Unidad")]
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int PlantaId { get; set; }
        public int DoctorId { get; set; }
    
        public virtual Planta Planta { get; set; }
        public virtual Doctor Doctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estadia> Estadias { get; set; }
    }
}
