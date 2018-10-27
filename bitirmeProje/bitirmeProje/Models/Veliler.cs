namespace bitirmeProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Veliler")]
    public partial class Veliler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Veliler()
        {
            Ogrenci = new HashSet<Ogrenci>();
        }

        [Key]
        public int veliID { get; set; }
        [Display(Name ="Veli Ad-Soyad")]
        [StringLength(50)]
        public string adSoyad { get; set; }

        [StringLength(50)]
        public string iletisimTel { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
    }
}
