//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class UrunBilgi
    {
        public long Id { get; set; }
        public Nullable<int> magazaId { get; set; }
        public string magazaAdi { get; set; }
        public string ayarAdi { get; set; }
        public Nullable<int> ayar { get; set; }
        public string barkod { get; set; }
        public string urunAdi { get; set; }
        public Nullable<decimal> gram { get; set; }
        public string resim { get; set; }
        public Nullable<decimal> milyem { get; set; }
        public Nullable<bool> durum { get; set; }
        public Nullable<int> adet { get; set; }
        public Nullable<decimal> komisyon { get; set; }
        public string fiyatAdi { get; set; }
        public string anagrup { get; set; }
        public string tezgahgrup { get; set; }
        public Nullable<decimal> gamiktar { get; set; }
        public Nullable<decimal> yuzde { get; set; }
        public Nullable<decimal> gun { get; set; }
    }
}