//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Perpustakaan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BukuTabel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BukuTabel()
        {
            this.PinjamTabel = new HashSet<PinjamTabel>();
        }
    
        public int ISBN { get; set; }
        public string NamaPengarang { get; set; }
        public string JudulBuku { get; set; }
        public string Tersedia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PinjamTabel> PinjamTabel { get; set; }
    }
}
