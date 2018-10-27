namespace bitirmeProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullaniciAdmin")]
    public partial class KullaniciAdmin
    {
        [Key]
        public int kullaniciID { get; set; }

        
        [Required]
        [StringLength(50)]
        [Display(Name = "Kullanýcý Adý")]
        public string kullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Þifre")]
        public string sifre { get; set; }
    }
}
