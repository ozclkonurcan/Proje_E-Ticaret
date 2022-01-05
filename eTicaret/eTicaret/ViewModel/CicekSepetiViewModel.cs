using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.ViewModel
{
    public class CicekSepetiViewModel
    {
        public long otosay { get; set; }
        public Nullable<System.DateTime> itarih { get; set; }
        public Nullable<bool> silme { get; set; }
        public string ayarAdi { get; set; }
        public Nullable<int> ayar { get; set; }
        public string barkod { get; set; }
        public string brand { get; set; }
        public string kargo { get; set; }
        public string aciklama { get; set; }
        public string cinsiyet { get; set; }
        public string resim { get; set; }
        public Nullable<decimal> gun { get; set; }
        public Nullable<decimal> komisyon { get; set; }
        public Nullable<decimal> yuzde { get; set; }
        public Nullable<decimal> gram { get; set; }
        public Nullable<decimal> milyem { get; set; }
        public Nullable<decimal> panoHas { get; set; }
        public Nullable<decimal> listeFiyat { get; set; }
        public Nullable<decimal> satisFiyat { get; set; }
        public string kategori { get; set; }
        public Nullable<int> adet { get; set; }
        //public string stok { get; set; }
        public string stokKodu { get; set; }
        public string baslik { get; set; }
        public string kdv { get; set; }
        public string mail { get; set; }
        public Nullable<bool> durum { get; set; }
        public Nullable<System.DateTime> upTarih { get; set; }
        public Nullable<System.DateTime> upFiyatTarih { get; set; }
        public string batchId { get; set; }
    }
}