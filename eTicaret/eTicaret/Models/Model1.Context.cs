﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eTicaret.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class eTicaretDbEntities : DbContext
    {
        public eTicaretDbEntities()
            : base("name=eTicaretDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AktifUrunler> AktifUrunlers { get; set; }
        public virtual DbSet<CicekSepeti_AktifUrunler> CicekSepeti_AktifUrunler { get; set; }
        public virtual DbSet<ePtt_Urunler> ePtt_Urunler { get; set; }
        public virtual DbSet<eTicaretFirma> eTicaretFirmas { get; set; }
        public virtual DbSet<HepsiBurada> HepsiBuradas { get; set; }
        public virtual DbSet<int_satis> int_satis { get; set; }
        public virtual DbSet<n11_Urunler> n11_Urunler { get; set; }
        public virtual DbSet<Sheet> Sheets { get; set; }
        public virtual DbSet<Sheet2> Sheet2 { get; set; }
        public virtual DbSet<SM_Urunler> SM_Urunler { get; set; }
        public virtual DbSet<Trend_AktifUrunler> Trend_AktifUrunler { get; set; }
        public virtual DbSet<UrunBarkod> UrunBarkods { get; set; }
        public virtual DbSet<UrunBilgi> UrunBilgis { get; set; }
        public virtual DbSet<Urunler> Urunlers { get; set; }
        public virtual DbSet<vadeFark> vadeFarks { get; set; }
        public virtual DbSet<ziynetUrunKombin> ziynetUrunKombins { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
    }
}
