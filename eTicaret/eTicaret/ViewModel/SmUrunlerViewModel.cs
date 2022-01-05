using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.ViewModel
{
    public class SmUrunlerViewModel
    {
        public long Id { get; set; }
        public string urunAdi { get; set; }
        public string aciklama { get; set; }
        public string marka { get; set; }
        public string barkod { get; set; }
        //public Nullable<int> stok { get; set; }
        public Nullable<decimal> desi { get; set; }
        public Nullable<decimal> kdv { get; set; }
        public string resim { get; set; }
        public string model { get; set; }
        public Nullable<int> adet { get; set; }
        public Nullable<decimal> gun { get; set; }
        public Nullable<decimal> komisyon { get; set; }
        public Nullable<decimal> yuzde { get; set; }
        public Nullable<decimal> gram { get; set; }
        public Nullable<decimal> milyem { get; set; }
        public Nullable<decimal> panoHas { get; set; }
        public Nullable<decimal> maliyet { get; set; }
        public Nullable<decimal> sonFiyat { get; set; }
        public Nullable<bool> durum { get; set; }
        public Nullable<System.DateTime> upFiyatTarih { get; set; }
    }
}