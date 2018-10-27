namespace bitirmeProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ogrenci")]
    public partial class Ogrenci
    {
        public int ogrenciID { get; set; }

        [Display(Name ="Ad-Soyad")]
        [Required]
        [StringLength(50)]
        public string adSoyad { get; set; }

        public int adresID { get; set; }

        [StringLength(50)]
        public string sinif { get; set; }

        [StringLength(50)]
        public string tcNo { get; set; }

        public int veliID { get; set; }

        public bool gelmeDurum { get; set; }

        public int servisID { get; set; }

        public virtual Adres Adres { get; set; }

        public virtual Servis Servis { get; set; }

        public virtual Veliler Veliler { get; set; }
    }
}
