using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcEpttModel
    {
        public long Id { get; set; }
        public string aciklama { get; set; }
        public string agirlik { get; set; }
        public Nullable<bool> aktif { get; set; }
        public string kategori { get; set; }
        public Nullable<int> anaKategoriId { get; set; }
        public string altKategoriAdi { get; set; }
        public Nullable<int> altKategoriId { get; set; }
        public string barkod { get; set; }
        public string boyX { get; set; }
        public string boyY { get; set; }
        public string boyZ { get; set; }
        public string desi { get; set; }
        public string durum { get; set; }
        public string garantiSure { get; set; }
        public string GarantiVerenFirma { get; set; }
        public Nullable<decimal> Iskonto { get; set; }
        public Nullable<decimal> KDVOran { get; set; }
        public Nullable<decimal> KDVli { get; set; }
        public Nullable<decimal> KDVsiz { get; set; }
        public string KategoriBilgisiGuncelle { get; set; }
        public Nullable<bool> Mevcut { get; set; }
        public Nullable<int> adet { get; set; }
      //  public Nullable<int> Miktar { get; set; }
        public Nullable<int> ShopId { get; set; }
        public string Tag { get; set; }
        public string TedarikciAltKategoriAdi { get; set; }
        public Nullable<int> TedarikciAltKategoriId { get; set; }
        public Nullable<int> TedarikciSanalKategoriId { get; set; }
        public string UrunAdi { get; set; }
        public Nullable<int> UrunId { get; set; }
        public string UzunAciklama { get; set; }
        public string resim { get; set; }
        public Nullable<decimal> gun { get; set; }
        public Nullable<decimal> komisyon { get; set; }
        public Nullable<decimal> yuzde { get; set; }
        public Nullable<decimal> gram { get; set; }
        public Nullable<decimal> milyem { get; set; }
        public Nullable<decimal> panoHas { get; set; }
        public Nullable<decimal> fiyat { get; set; }
        public Nullable<System.DateTime> upTime { get; set; }
        public Nullable<bool> adurum { get; set; }
        public string YeniKategoriId { get; set; }
        public Nullable<System.DateTime> upFiyatTarih { get; set; }
    }
}