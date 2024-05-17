using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Deneme
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model32")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLADMIN> TBLADMIN { get; set; }
        public virtual DbSet<TBLARACLAR> TBLARACLAR { get; set; }
        public virtual DbSet<TBLARIZADETAY> TBLARIZADETAY { get; set; }
        public virtual DbSet<TBLCARI> TBLCARI { get; set; }
        public virtual DbSet<TBLDEPARTMAN> TBLDEPARTMAN { get; set; }
        public virtual DbSet<TBLFATURABILGI> TBLFATURABILGI { get; set; }
        public virtual DbSet<TBLFATURADETAY> TBLFATURADETAY { get; set; }
        public virtual DbSet<TBLGIDERLER> TBLGIDERLER { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORI { get; set; }
        public virtual DbSet<TBLNOTLARIM> TBLNOTLARIM { get; set; }
        public virtual DbSet<TBLPERSONEL> TBLPERSONEL { get; set; }
        public virtual DbSet<TBLURUN> TBLURUN { get; set; }
        public virtual DbSet<TBLURUNHAREKET> TBLURUNHAREKET { get; set; }
        public virtual DbSet<TBLURUNKABUL> TBLURUNKABUL { get; set; }
        public virtual DbSet<TBLURUNTAKIP> TBLURUNTAKIP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBLADMIN>()
                .Property(e => e.KULLANICIAD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLADMIN>()
                .Property(e => e.SIFRE)
                .IsUnicode(false);

            modelBuilder.Entity<TBLARACLAR>()
                .Property(e => e.AD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLARIZADETAY>()
                .Property(e => e.SORUN)
                .IsUnicode(false);

            modelBuilder.Entity<TBLARIZADETAY>()
                .Property(e => e.ACIKLAMA)
                .IsUnicode(false);

            modelBuilder.Entity<TBLARIZADETAY>()
                .Property(e => e.ISLEMLER)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.AD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.SOYAD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.TELEFON)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.IL)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.ILCE)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.BANKA)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.VERGIDAIRESI)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.VERGINO)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.STATU)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .Property(e => e.ADRES)
                .IsUnicode(false);

            modelBuilder.Entity<TBLCARI>()
                .HasMany(e => e.TBLFATURABILGI)
                .WithOptional(e => e.TBLCARI)
                .HasForeignKey(e => e.CARI);

            modelBuilder.Entity<TBLCARI>()
                .HasMany(e => e.TBLFATURABILGI1)
                .WithOptional(e => e.TBLCARI1)
                .HasForeignKey(e => e.CARI);

            modelBuilder.Entity<TBLCARI>()
                .HasMany(e => e.TBLURUNHAREKET)
                .WithOptional(e => e.TBLCARI)
                .HasForeignKey(e => e.MUSTERI);

            modelBuilder.Entity<TBLCARI>()
                .HasMany(e => e.TBLURUNKABUL)
                .WithOptional(e => e.TBLCARI)
                .HasForeignKey(e => e.CARI);

            modelBuilder.Entity<TBLDEPARTMAN>()
                .Property(e => e.AD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLDEPARTMAN>()
                .Property(e => e.ACIKLAMA)
                .IsUnicode(false);

            modelBuilder.Entity<TBLDEPARTMAN>()
                .HasMany(e => e.TBLPERSONEL)
                .WithOptional(e => e.TBLDEPARTMAN)
                .HasForeignKey(e => e.DEPARTMAN);

            modelBuilder.Entity<TBLFATURABILGI>()
                .Property(e => e.SERI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBLFATURABILGI>()
                .Property(e => e.SIRANO)
                .IsUnicode(false);

            modelBuilder.Entity<TBLFATURABILGI>()
                .Property(e => e.SAAT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBLFATURABILGI>()
                .Property(e => e.VERGIDAIRE)
                .IsUnicode(false);

            modelBuilder.Entity<TBLFATURABILGI>()
                .HasMany(e => e.TBLFATURADETAY)
                .WithOptional(e => e.TBLFATURABILGI)
                .HasForeignKey(e => e.FATURAID);

            modelBuilder.Entity<TBLFATURADETAY>()
                .Property(e => e.URUN)
                .IsUnicode(false);

            modelBuilder.Entity<TBLGIDERLER>()
                .Property(e => e.GIDERACIKLAMA)
                .IsUnicode(false);

            modelBuilder.Entity<TBLKATEGORI>()
                .Property(e => e.AD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLKATEGORI>()
                .HasMany(e => e.TBLURUN)
                .WithOptional(e => e.TBLKATEGORI)
                .HasForeignKey(e => e.KATEGORI);

            modelBuilder.Entity<TBLNOTLARIM>()
                .Property(e => e.BASLIK)
                .IsUnicode(false);

            modelBuilder.Entity<TBLNOTLARIM>()
                .Property(e => e.ICERIK)
                .IsUnicode(false);

            modelBuilder.Entity<TBLPERSONEL>()
                .Property(e => e.AD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLPERSONEL>()
                .Property(e => e.SOYAD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLPERSONEL>()
                .Property(e => e.FOTOGRAF)
                .IsUnicode(false);

            modelBuilder.Entity<TBLPERSONEL>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TBLPERSONEL>()
                .Property(e => e.TELEFON)
                .IsUnicode(false);

            modelBuilder.Entity<TBLPERSONEL>()
                .HasMany(e => e.TBLURUNHAREKET)
                .WithOptional(e => e.TBLPERSONEL)
                .HasForeignKey(e => e.PERSONEL);

            modelBuilder.Entity<TBLPERSONEL>()
                .HasMany(e => e.TBLURUNKABUL)
                .WithOptional(e => e.TBLPERSONEL)
                .HasForeignKey(e => e.PERSONEL);

            modelBuilder.Entity<TBLURUN>()
                .Property(e => e.AD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLURUN>()
                .Property(e => e.MARKA)
                .IsUnicode(false);

            modelBuilder.Entity<TBLURUN>()
                .HasMany(e => e.TBLURUNHAREKET)
                .WithOptional(e => e.TBLURUN)
                .HasForeignKey(e => e.URUN);

            modelBuilder.Entity<TBLURUN>()
                .HasMany(e => e.TBLURUNKABUL)
                .WithOptional(e => e.TBLURUN)
                .HasForeignKey(e => e.URUN);

            modelBuilder.Entity<TBLURUNHAREKET>()
                .Property(e => e.URUNSERINO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBLURUNKABUL>()
                .Property(e => e.URUNSERINO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBLURUNTAKIP>()
                .Property(e => e.DURUM)
                .IsUnicode(false);

            modelBuilder.Entity<TBLURUNTAKIP>()
                .Property(e => e.TAKIPKODU)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
