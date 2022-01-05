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
    public class HepsiBuradaController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/HepsiBurada
        public IHttpActionResult GetHepsiBuradas()
        {
            var Tlist = (from a in db.HepsiBuradas
                         join p in db.UrunBilgis on a.barkod equals p.barkod
                         where p.magazaId == 7
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
                             a.listeFiyat,
                             a.satisFiyat,
                             a.kategori,
                             p.adet,
                             a.stokKodu,
                             a.baslik,
                             a.categoryId,
                             a.HepsiburadaSku,
                             a.kdv,
                             a.mail,
                             a.durum,
                             a.upTarih,
                             a.upFiyatTarih,
                             p.milyem,
                             p.gram,
                             p.yuzde,
                             p.komisyon,
                             p.gun


                         }).ToList();


            return Ok(Tlist);
        }

        // GET: api/HepsiBurada/5
        [ResponseType(typeof(HepsiBurada))]
        public IHttpActionResult GetHepsiBurada(long id)
        {
            var result = (from e in db.HepsiBuradas
                          join d in db.UrunBilgis on e.barkod equals d.barkod
                          where d.magazaId == 7 && e.otosay == id
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
                              e.categoryId,
                              e.HepsiburadaSku,
                              e.kdv,
                              e.mail,
                              e.durum,
                              e.upTarih,
                              e.upFiyatTarih
                          }).FirstOrDefault();


            return Ok(result);
        }

        // PUT: api/HepsiBurada/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHepsiBurada(long id, HepsiBuradaViewModel hepsiBuradaViewModel)
        {
            var result = (from a in db.HepsiBuradas
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          where b.magazaId == 7 && a.otosay == id
                          select new
                          {
                              Hepsi = a,
                              Urun = b
                          }).FirstOrDefault();

            result.Urun.milyem = hepsiBuradaViewModel.milyem;
            result.Urun.komisyon = hepsiBuradaViewModel.komisyon;
            result.Urun.resim = hepsiBuradaViewModel.resim;
            result.Urun.barkod = hepsiBuradaViewModel.barkod;
            result.Urun.adet = hepsiBuradaViewModel.adet;
            result.Hepsi.itarih = hepsiBuradaViewModel.itarih;
            result.Hepsi.silme = hepsiBuradaViewModel.silme;
            result.Hepsi.ayarAdi = hepsiBuradaViewModel.ayarAdi;
            result.Hepsi.ayar = hepsiBuradaViewModel.ayar;
            result.Hepsi.barkod = hepsiBuradaViewModel.barkod;
            result.Hepsi.brand = hepsiBuradaViewModel.brand;
            result.Hepsi.kargo = hepsiBuradaViewModel.kargo;
            result.Hepsi.aciklama = hepsiBuradaViewModel.aciklama;
            result.Hepsi.cinsiyet = hepsiBuradaViewModel.cinsiyet;
            result.Hepsi.resim = hepsiBuradaViewModel.resim;
            result.Hepsi.listeFiyat = hepsiBuradaViewModel.listeFiyat;
            result.Hepsi.satisFiyat = hepsiBuradaViewModel.satisFiyat;
            result.Hepsi.kategori = hepsiBuradaViewModel.kategori;
            result.Hepsi.stok = Convert.ToString(hepsiBuradaViewModel.adet);
            result.Hepsi.stokKodu = hepsiBuradaViewModel.stokKodu;
            result.Hepsi.baslik = hepsiBuradaViewModel.baslik;
            result.Hepsi.categoryId = hepsiBuradaViewModel.categoryId;
            result.Hepsi.HepsiburadaSku = hepsiBuradaViewModel.HepsiburadaSku;
            result.Hepsi.kdv = hepsiBuradaViewModel.kdv;
            result.Hepsi.mail = hepsiBuradaViewModel.mail;
            result.Hepsi.durum = hepsiBuradaViewModel.durum;
            result.Hepsi.upTarih = hepsiBuradaViewModel.upTarih;
            result.Hepsi.upFiyatTarih = hepsiBuradaViewModel.upFiyatTarih;

            db.SaveChanges();
            return Ok();
        }

        // POST: api/HepsiBurada
        [ResponseType(typeof(HepsiBurada))]
        public IHttpActionResult PostHepsiBurada(HepsiBuradaViewModel hepsiBuradaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (db.HepsiBuradas.Any(x => x.barkod == hepsiBuradaViewModel.barkod))
            {
                return BadRequest("Bu barkod numarasına sahip bir ürün zaten var.");

            }

            var result = (from a in db.HepsiBuradas
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          select new
                          {
                              Hepsi = a,
                              Urun = b
                          }).FirstOrDefault();
            db.HepsiBuradas.Add(new HepsiBurada()
            {
                barkod = hepsiBuradaViewModel.barkod,
                itarih = hepsiBuradaViewModel.itarih,
                silme = hepsiBuradaViewModel.silme,
                ayarAdi = hepsiBuradaViewModel.ayarAdi,
                ayar = hepsiBuradaViewModel.ayar,
                brand = hepsiBuradaViewModel.brand,
                kargo = hepsiBuradaViewModel.kargo,
                aciklama = hepsiBuradaViewModel.aciklama,
                cinsiyet = hepsiBuradaViewModel.cinsiyet,
                resim = hepsiBuradaViewModel.resim,
                panoHas = hepsiBuradaViewModel.panoHas,
                listeFiyat = hepsiBuradaViewModel.listeFiyat,
                satisFiyat = hepsiBuradaViewModel.satisFiyat,
                kategori = hepsiBuradaViewModel.kategori,
                stok = Convert.ToString(hepsiBuradaViewModel.adet),
                stokKodu = hepsiBuradaViewModel.stokKodu,
                baslik = hepsiBuradaViewModel.baslik,
                categoryId = hepsiBuradaViewModel.categoryId,
                HepsiburadaSku = hepsiBuradaViewModel.HepsiburadaSku,
                kdv = hepsiBuradaViewModel.kdv,
                mail = hepsiBuradaViewModel.mail,
                durum = hepsiBuradaViewModel.durum,
                upTarih = hepsiBuradaViewModel.upTarih,
                upFiyatTarih = hepsiBuradaViewModel.upFiyatTarih

            });
            db.UrunBilgis.Add(new UrunBilgi()
            {
                barkod = hepsiBuradaViewModel.barkod,
                magazaId = 7,
                ayarAdi = hepsiBuradaViewModel.ayarAdi,
                ayar = hepsiBuradaViewModel.ayar,
                urunAdi = hepsiBuradaViewModel.baslik,
                gram = hepsiBuradaViewModel.gram,
                resim = hepsiBuradaViewModel.resim,
                milyem = hepsiBuradaViewModel.milyem,
                durum = hepsiBuradaViewModel.durum,
                komisyon = hepsiBuradaViewModel.komisyon,
                yuzde = hepsiBuradaViewModel.yuzde,
                gun = hepsiBuradaViewModel.gun,
                adet = hepsiBuradaViewModel.adet
            });


            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hepsiBuradaViewModel.otosay }, hepsiBuradaViewModel);
        }

        // DELETE: api/HepsiBurada/5
        [ResponseType(typeof(HepsiBurada))]
        public IHttpActionResult DeleteHepsiBurada(long id)
        {
            HepsiBurada hepsiBurada = db.HepsiBuradas.Find(id);
            if (hepsiBurada == null)
            {
                return NotFound();
            }
            hepsiBurada.silme = true;
            //db.HepsiBuradas.Remove(hepsiBurada);
            db.SaveChanges();

            return Ok(hepsiBurada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HepsiBuradaExists(long id)
        {
            return db.HepsiBuradas.Count(e => e.otosay == id) > 0;
        }
    }
}