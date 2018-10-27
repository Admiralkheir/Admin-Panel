namespace bitirmeProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adres()
        {
            Ogrenci = new HashSet<Ogrenci>();
        }

        public int adresID { get; set; }

        [StringLength(500)]
        public string koordinat { get; set; }
        [Display(Name ="Adres Bilgisi")]
        [StringLength(500)]
        public string adresBilgi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
    }
}
