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
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Trend_AktifUrunlerController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/Trend_AktifUrunler
        //public IQueryable<Trend_AktifUrunler> GetTrend_AktifUrunler()
        //{
        //    return db.Trend_AktifUrunler;
        //}
        public IHttpActionResult GetTrend_AktifUrunler()
        {
            var Tlist = (from a in db.Trend_AktifUrunler
                         join p in db.UrunBilgis on a.barkod equals p.barkod
                         where p.magazaId == 1
                         select new
                         {
                             a.otosay,
                             a.itarih,
                             a.silme,
                             a.ayarAdi,
                             a.ayar,
                             a.barkod,
                             a.brand,
                             a.kargo,
                             a.aciklama,
                             a.cinsiyet,
                             p.resim,
                             a.panoHas,
                             p.milyem,
                             a.listeFiyat,
                             a.satisFiyat,
                             a.kategori,
                             p.adet,
                             a.stokKodu,
                             a.baslik,
                             a.kdv,
                             a.mail,
                             a.durum,
                             a.upTarih,
                             a.upFiyatTarih,
                             p.gram,
                             p.yuzde,
                             p.komisyon,
                             p.gun


                         }).ToList();


            return Ok(Tlist);
        }
        // GET: api/Trend_AktifUrunler/5
        [ResponseType(typeof(Trend_AktifUrunler))]
        public IHttpActionResult GetTrend_AktifUrunler(long id)
        {
            //Trend_AktifUrunler trend_AktifUrunler = db.Trend_AktifUrunler.Find(id);
            //if (trend_AktifUrunler == null)
            //{
            //    return NotFound();
            //}

            //return Ok(trend_AktifUrunler);
            var result = (from e in db.Trend_AktifUrunler
                          join d in db.UrunBilgis on e.barkod equals d.barkod
                          where d.magazaId == 1 && e.otosay == id
                          select new
                          {
                              e.otosay,
                              e.barkod,
                              d.resim,
                              d.komisyon,
                              d.yuzde,
                              d.gun,
                              d.gram,
                              d.milyem,
                              e.itarih,
                              e.silme,
                              e.ayarAdi,
                              e.ayar,
                              e.brand,
                              e.kargo,
                              e.aciklama,
                              e.cinsiyet,
                              e.panoHas,
                              e.listeFiyat,
                              e.satisFiyat,
                              e.kategori,
                              d.adet,
                              e.stokKodu,
                              e.baslik,
                              e.kdv,
                              e.mail,
                              e.durum,
                              e.upTarih,
                              e.upFiyatTarih
                          }).FirstOrDefault();


            return Ok(result);
        }

       
           [ResponseType(typeof(void))]
        public IHttpActionResult PutTrend_AktifUrunler(long id,TrendViewModel trendViewModel)
        {
            
            

            var result = (from a in db.Trend_AktifUrunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          where b.magazaId == 1 && a.otosay == id
                          select new
                          {
                              Trend = a,
                              Urun = b
                          }).FirstOrDefault();

            result.Urun.milyem = trendViewModel.milyem;
            result.Urun.komisyon = trendViewModel.komisyon;
            result.Urun.resim = trendViewModel.resim;
            result.Urun.barkod = trendViewModel.barkod;
            result.Urun.adet = trendViewModel.adet;
            result.Trend.itarih = trendViewModel.itarih;
            result.Trend.silme = trendViewModel.silme;
            result.Trend.ayarAdi = trendViewModel.ayarAdi;
            result.Trend.ayar = trendViewModel.ayar;
            result.Trend.barkod = trendViewModel.barkod;
            result.Trend.brand = trendViewModel.brand;
            result.Trend.kargo = trendViewModel.kargo;
            result.Trend.aciklama = trendViewModel.aciklama;
            result.Trend.cinsiyet = trendViewModel.cinsiyet;
            result.Trend.resim = trendViewModel.resim;
            result.Trend.listeFiyat = trendViewModel.listeFiyat;
            result.Trend.satisFiyat = trendViewModel.satisFiyat;
            result.Trend.kategori = trendViewModel.kategori;
            result.Trend.stok = Convert.ToString(trendViewModel.adet);
            result.Trend.stokKodu = trendViewModel.stokKodu;
            result.Trend.baslik = trendViewModel.baslik;
            result.Trend.kdv = trendViewModel.kdv;
            result.Trend.mail = trendViewModel.mail;
            result.Trend.durum = trendViewModel.durum;
            result.Trend.upTarih = trendViewModel.upTarih;
            result.Trend.upFiyatTarih = trendViewModel.upFiyatTarih;

            db.SaveChanges();
            return Ok();


            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != trend_AktifUrunler.otosay)
            //{
            //    return BadRequest();
            //}

            //db.Entry(trend_AktifUrunler).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!Trend_AktifUrunlerExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Trend_AktifUrunler
        [ResponseType(typeof(Trend_AktifUrunler))]
        public IHttpActionResult  PostTrend_AktifUrunler(TrendViewModel trendViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (db.Trend_AktifUrunler.Any(x => x.barkod == trendViewModel.barkod))
            {
                return BadRequest("Bu barkod numarasına sahip bir ürün zaten var.");

            }
            var result = (from a in db.Trend_AktifUrunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          select new
                          {
                              Trend = a,
                              Urun = b
                          }).FirstOrDefault();
            db.Trend_AktifUrunler.Add(new Trend_AktifUrunler()
            {
                barkod = trendViewModel.barkod,
                itarih = trendViewModel.itarih,
                silme = trendViewModel.silme,
                ayarAdi = trendViewModel.ayarAdi,
                ayar = trendViewModel.ayar,
                brand = trendViewModel.brand,
                kargo = trendViewModel.kargo,
                aciklama = trendViewModel.aciklama,
                cinsiyet = trendViewModel.cinsiyet,
                resim = trendViewModel.resim,
                panoHas = trendViewModel.panoHas,
                listeFiyat = trendViewModel.listeFiyat,
                satisFiyat = trendViewModel.satisFiyat,
                kategori = trendViewModel.kategori,
                stok = Convert.ToString(trendViewModel.adet),
                stokKodu = trendViewModel.stokKodu,
                baslik = trendViewModel.baslik,
                kdv = trendViewModel.kdv,
                mail = trendViewModel.mail,
                durum = trendViewModel.durum,
                upTarih = trendViewModel.upTarih,
                upFiyatTarih = trendViewModel.upFiyatTarih

            });
            db.UrunBilgis.Add(new UrunBilgi()
            {
                barkod = trendViewModel.barkod,
                magazaId=1,
                ayarAdi = trendViewModel.ayarAdi,
                ayar = trendViewModel.ayar,
                urunAdi = trendViewModel.baslik,
                gram = trendViewModel.gram,
                resim = trendViewModel.resim,
                milyem = trendViewModel.milyem,
                durum = trendViewModel.durum,
                komisyon = trendViewModel.komisyon,
                yuzde = trendViewModel.yuzde,
                gun = trendViewModel.gun,
                adet = trendViewModel.adet
            });

        
        db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trendViewModel.otosay }, trendViewModel);
        }

        // DELETE: api/Trend_AktifUrunler/5
        [ResponseType(typeof(Trend_AktifUrunler))]
        public IHttpActionResult DeleteTrend_AktifUrunler(long id)
        {
            Trend_AktifUrunler trend_AktifUrunler = db.Trend_AktifUrunler.Find(id);
            if (trend_AktifUrunler == null)
            {
                return NotFound();
            }
            trend_AktifUrunler.silme = true;
            //db.Trend_AktifUrunler.Remove(trend_AktifUrunler);
            db.SaveChanges();

            return Ok(trend_AktifUrunler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Trend_AktifUrunlerExists(long id)
        {
            return db.Trend_AktifUrunler.Count(e => e.otosay == id) > 0;
        }
    }
}