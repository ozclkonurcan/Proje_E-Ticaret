using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using eTicaret.Models;
using eTicaret.ViewModel;

namespace eTicaret.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class n11_UrunlerController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/n11_Urunler
        public IHttpActionResult Getn11_Urunler()
        {
            var Tlist = (from a in db.n11_Urunler
                         join p in db.UrunBilgis on a.barkod equals p.barkod
                         where p.magazaId == 2
                         select new
                         {
                             a.Id,
                             a.ktarih,
                             a.durum,
                             a.barkod,
                             a.ayar,
                             a.urunadi,
                             a.n11Id,
                             a.productSellerCode,
                             a.title,
                             a.subtitle,
                             a.description,
                             a.attribute,
                             a.idx,
                             a.panoHas,
                             a.price,
                             a.currencyType,
                             a.image_order,
                             a.saleStartDate,
                             a.saleEndDate,
                             a.productionDate,
                             a.expirationDate,
                             a.productCondition,
                             a.preparingDay,
                             a.discount,
                             a.shipmentTemplate,
                             p.adet,
                             a.sellerStockCode,
                             a.attribute_name,
                             a.attribute_value,
                             a.optionPrice,
                             a.bundle,
                             a.mpn,
                             a.gtin,
                             a.specialProductInf_key,
                             a.specialProductInf_value,
                             a.upFiyatTarih,
                             p.resim,
                             p.milyem,
                             p.gram,
                             p.yuzde,
                             p.komisyon,
                             p.gun


                         }).ToList();


            return Ok(Tlist);
        }

        // GET: api/n11_Urunler/5
        [ResponseType(typeof(n11_Urunler))]
        public IHttpActionResult Getn11_Urunler(long id)
        {
            var result = (from a in db.n11_Urunler
                          join p in db.UrunBilgis on a.barkod equals p.barkod
                          where p.magazaId == 2 && a.Id == id
                          select new
                          {
                              a.Id,
                              a.ktarih,
                              a.durum,
                              a.barkod,
                              a.ayar,
                              a.urunadi,
                              a.n11Id,
                              a.productSellerCode,
                              a.title,
                              a.subtitle,
                              a.description,
                              a.attribute,
                              a.idx,
                              a.panoHas,
                              a.price,
                              a.currencyType,
                              a.image_order,
                              a.saleStartDate,
                              a.saleEndDate,
                              a.productionDate,
                              a.expirationDate,
                              a.productCondition,
                              a.preparingDay,
                              a.discount,
                              a.shipmentTemplate,
                              p.adet,
                              a.sellerStockCode,
                              a.attribute_name,
                              a.attribute_value,
                              a.optionPrice,
                              a.bundle,
                              a.mpn,
                              a.gtin,
                              a.specialProductInf_key,
                              a.specialProductInf_value,
                              a.upFiyatTarih,
                              p.resim,
                              p.milyem,
                              p.gram,
                              p.yuzde,
                              p.komisyon,
                              p.gun
                          }).FirstOrDefault();


            return Ok(result);
        }

        // PUT: api/n11_Urunler/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putn11_Urunler(long id, N11ViewModel n11ViewModel)
        {

            var result = (from a in db.n11_Urunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          where b.magazaId == 2 && a.Id == id
                          select new
                          {
                              N11 = a,
                              Urun = b
                          }).FirstOrDefault();

            result.Urun.milyem = n11ViewModel.milyem;
            result.Urun.komisyon = n11ViewModel.komisyon;
            result.Urun.barkod = n11ViewModel.barkod;
            result.Urun.resim = n11ViewModel.resim;
            result.Urun.urunAdi = n11ViewModel.urunadi;
            result.Urun.adet = n11ViewModel.adet;
            result.N11.image = n11ViewModel.resim;
            result.N11.ktarih = n11ViewModel.ktarih;
            result.N11.durum = n11ViewModel.durum;
            result.N11.barkod = n11ViewModel.barkod;
            result.N11.ayar = n11ViewModel.ayar;
            result.N11.urunadi = n11ViewModel.urunadi;
            result.N11.n11Id = n11ViewModel.n11Id;
            result.N11.productSellerCode = n11ViewModel.productSellerCode;
            result.N11.title = n11ViewModel.title;
            result.N11.subtitle = n11ViewModel.subtitle;
            result.N11.description = n11ViewModel.description;
            result.N11.attribute = n11ViewModel.attribute;
            result.N11.idx = n11ViewModel.idx;
            result.N11.price = n11ViewModel.price;
            result.N11.currencyType = n11ViewModel.currencyType;
            result.N11.image_order = n11ViewModel.image_order;
            result.N11.saleStartDate = n11ViewModel.saleStartDate;
            result.N11.saleEndDate = n11ViewModel.saleEndDate;
            result.N11.productionDate = n11ViewModel.productionDate;
            result.N11.expirationDate = n11ViewModel.expirationDate;
            result.N11.productCondition = n11ViewModel.productCondition;
            result.N11.preparingDay = n11ViewModel.preparingDay;
            result.N11.discount = n11ViewModel.discount;
            result.N11.shipmentTemplate = n11ViewModel.shipmentTemplate;
            result.N11.quantity = n11ViewModel.adet;
            result.N11.sellerStockCode = n11ViewModel.sellerStockCode;
            result.N11.attribute_name = n11ViewModel.attribute_name;
            result.N11.attribute_value = n11ViewModel.attribute_value;
            result.N11.optionPrice = n11ViewModel.optionPrice;
            result.N11.bundle = n11ViewModel.bundle;
            result.N11.mpn = n11ViewModel.mpn;
            result.N11.gtin = n11ViewModel.gtin;
            result.N11.specialProductInf_key = n11ViewModel.specialProductInf_key;
            result.N11.specialProductInf_value = n11ViewModel.specialProductInf_value;
            result.N11.upFiyatTarih = n11ViewModel.upFiyatTarih;

            db.SaveChanges();
            return Ok();
        }

        // POST: api/n11_Urunler
        [ResponseType(typeof(n11_Urunler))]
        public IHttpActionResult Postn11_Urunler(N11ViewModel n11ViewModel)
        {
            if (db.n11_Urunler.Any(x => x.barkod == n11ViewModel.barkod))
            {
                return BadRequest("Bu barkod numarasına sahip bir ürün zaten var.");

            }
            var result = (from a in db.n11_Urunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          select new
                          {
                              N11 = a,
                              Urun = b
                          }).FirstOrDefault();
            db.n11_Urunler.Add(new n11_Urunler()
            {
                            
                             ktarih = n11ViewModel.ktarih,
                             gram = n11ViewModel.gram,
                             durum = n11ViewModel.durum,
                             barkod = n11ViewModel.barkod,
                             ayar = n11ViewModel.ayar,
                             urunadi = n11ViewModel.urunadi,
                             n11Id = n11ViewModel.n11Id,
                             productSellerCode = n11ViewModel.productSellerCode,
                             title = n11ViewModel.title,
                             subtitle = n11ViewModel.subtitle,
                             description = n11ViewModel.description,
                             attribute = n11ViewModel.attribute ,
                             idx = n11ViewModel.idx,
                             panoHas = n11ViewModel.panoHas ,
                             price = n11ViewModel.price,
                             currencyType = n11ViewModel.currencyType,
                             image_order = n11ViewModel.image_order,
                             saleStartDate = n11ViewModel.saleEndDate,
                             saleEndDate = n11ViewModel.saleEndDate,
                             productionDate = n11ViewModel.productionDate,
                             expirationDate = n11ViewModel.expirationDate,
                             productCondition = n11ViewModel.productCondition,
                             preparingDay = n11ViewModel.preparingDay,
                             discount = n11ViewModel.discount,
                             shipmentTemplate = n11ViewModel.shipmentTemplate,
                             quantity = n11ViewModel.adet,
                             sellerStockCode = n11ViewModel.sellerStockCode,
                             attribute_name = n11ViewModel.attribute_name,
                             attribute_value = n11ViewModel.attribute_value,
                             optionPrice = n11ViewModel.optionPrice,
                             bundle = n11ViewModel.bundle,
                             mpn = n11ViewModel.mpn,
                             gtin = n11ViewModel.gtin,
                             specialProductInf_key = n11ViewModel.specialProductInf_key,
                             specialProductInf_value = n11ViewModel.specialProductInf_value,
                             upFiyatTarih = n11ViewModel.upFiyatTarih,
                          

            });
            db.UrunBilgis.Add(new UrunBilgi()
            {
                barkod = n11ViewModel.barkod,
                magazaId = 2,
                urunAdi = n11ViewModel.urunadi,
                gram = n11ViewModel.gram,
                resim = n11ViewModel.resim,
                milyem = n11ViewModel.milyem,
                durum = n11ViewModel.durum,
                komisyon = n11ViewModel.komisyon,
                yuzde = n11ViewModel.yuzde,
                gun = n11ViewModel.gun,
                ayarAdi = n11ViewModel.ayar,
                adet = n11ViewModel.adet
            });

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = n11ViewModel.Id }, n11ViewModel);
        }

        // DELETE: api/n11_Urunler/5
        [ResponseType(typeof(n11_Urunler))]
        public IHttpActionResult Deleten11_Urunler(long id)
        {
            n11_Urunler n11_Urunler = db.n11_Urunler.Find(id);
            if (n11_Urunler == null)
            {
                return NotFound();
            }
            n11_Urunler.durum = false;
            //db.n11_Urunler.Remove(n11_Urunler);
            db.SaveChanges();

            return Ok(n11_Urunler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool n11_UrunlerExists(long id)
        {
            return db.n11_Urunler.Count(e => e.Id == id) > 0;
        }
    }
}