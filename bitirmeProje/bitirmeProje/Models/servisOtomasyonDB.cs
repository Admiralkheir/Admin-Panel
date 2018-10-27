namespace bitirmeProje.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class servisOtomasyonDB : DbContext
    {
        public servisOtomasyonDB()
            : base("name=servisOtomasyonDB")
        {
        }

        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Koordinat> Koordinat { get; set; }
        public virtual DbSet<KullaniciAdmin> KullaniciAdmin { get; set; }
        public virtual DbSet<Ogrenci> Ogrenci { get; set; }
        public virtual DbSet<Servis> Servis { get; set; }
        public virtual DbSet<Veliler> Veliler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adres>()
                .Property(e => e.koordinat)
                .IsFixedLength();

            modelBuilder.Entity<Adres>()
                .HasMany(e => e.Ogrenci)
                .WithRequired(e => e.Adres)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Koordinat>()
                .HasMany(e => e.Servis)
                .WithRequired(e => e.Koordinat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Servis>()
                .HasMany(e => e.Ogrenci)
                .WithRequired(e => e.Servis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Veliler>()
                .HasMany(e => e.Ogrenci)
                .WithRequired(e => e.Veliler)
                .WillCascadeOnDelete(false);
        }
    }
}
