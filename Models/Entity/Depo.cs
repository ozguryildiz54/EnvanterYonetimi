//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnvanterYonetimi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Depo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Depo()
        {
            this.Modeller = new HashSet<Modeller>();
        }
    
        public int depoId { get; set; }
        public int cihazTuruId { get; set; }
        public string envNo { get; set; }
        public string seriNo { get; set; }
        public System.DateTime garantiBas { get; set; }
        public string durum { get; set; }
        public string kullanim { get; set; }
        public System.DateTime islemZaman { get; set; }
        public string islemiYapan { get; set; }
        public string aciklama { get; set; }
    
        public virtual CihazTuru CihazTuru { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Modeller> Modeller { get; set; }
    }
}
