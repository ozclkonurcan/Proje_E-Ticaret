using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcN11Model
    {

        public long Id { get; set; }
        public Nullable<System.DateTime> ktarih { get; set; }
        public Nullable<bool> durum { get; set; }
        public string barkod { get; set; }
        public string ayar { get; set; }
        public string urunadi { get; set; }
        public Nullable<decimal> gun { get; set; }
        public Nullable<decimal> komisyon { get; set; }
        public Nullable<decimal> yuzde { get; set; }
        public Nullable<decimal> gram { get; set; }
        public Nullable<decimal> panoHas { get; set; }
        public Nullable<decimal> milyem { get; set; }
        public Nullable<long> n11Id { get; set; }
        public string productSellerCode { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public string attribute { get; set; }
        public string idx { get; set; }

        public Nullable<decimal> price { get; set; }
        public string currencyType { get; set; }
        public string resim { get; set; }
        public Nullable<int> image_order { get; set; }
        public Nullable<System.DateTime> saleStartDate { get; set; }
        public Nullable<System.DateTime> saleEndDate { get; set; }
        public Nullable<System.DateTime> productionDate { get; set; }
        public Nullable<System.DateTime> expirationDate { get; set; }
        public Nullable<int> productCondition { get; set; }
        public Nullable<int> preparingDay { get; set; }
        public Nullable<int> discount { get; set; }
        public string shipmentTemplate { get; set; }
        public Nullable<int> adet { get; set; }
        //public Nullable<int> quantity { get; set; }
        public string sellerStockCode { get; set; }
        public string attribute_name { get; set; }
        public string attribute_value { get; set; }
        public Nullable<decimal> optionPrice { get; set; }
        public string bundle { get; set; }
        public string mpn { get; set; }
        public string gtin { get; set; }
        public string specialProductInf_key { get; set; }
        public string specialProductInf_value { get; set; }
        public Nullable<System.DateTime> upFiyatTarih { get; set; }
    }
}