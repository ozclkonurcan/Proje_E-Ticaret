using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eTicaret.Models;
using System.Web.Http.Cors;
using eTicaret.ViewModel;

namespace eTicaret.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class CicekSepeti_AktifUrunlerController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/CicekSepeti_AktifUrunler
        public IHttpActionResult GetCicekSepeti_AktifUrunler()
        {
            var Tlist = (from a in db.CicekSepeti_AktifUrunler
                         join p in db.UrunBilgis on a.barkod equals p.barkod
                         where p.magazaId == 6
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
                             a.panoHas,
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
                             p.resim,
                             p.milyem,
                             p.gram,
                             p.yuzde,
                             p.komisyon,
                             p.gun


                         }).ToList();


            return Ok(Tlist);
        }

        // GET: api/CicekSepeti_AktifUrunler/5
        [ResponseType(typeof(CicekSepeti_AktifUrunler))]
        public IHttpActionResult GetCicekSepeti_AktifUrunler(long id)
        {

            var result = (from e in db.CicekSepeti_AktifUrunler
                          join d in db.UrunBilgis on e.barkod equals d.barkod
                          where d.magazaId == 6 && e.otosay == id
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

        // PUT: api/CicekSepeti_AktifUrunler/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCicekSepeti_AktifUrunler(long id, CicekSepetiViewModel cicekSepetiViewModel)
        {
            var result = (from a in db.CicekSepeti_AktifUrunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          where b.magazaId == 6 && a.otosay == id
                          select new
                          {
                              Cicek = a,
                              Urun = b
                          }).FirstOrDefault();

            result.Urun.milyem = cicekSepetiViewModel.milyem;
            result.Urun.komisyon = cicekSepetiViewModel.komisyon;
            result.Urun.resim = cicekSepetiViewModel.resim;
            result.Urun.barkod = cicekSepetiViewModel.barkod;
            result.Urun.adet = cicekSepetiViewModel.adet;
            result.Cicek.itarih = cicekSepetiViewModel.itarih;
            result.Cicek.silme = cicekSepetiViewModel.silme;
            result.Cicek.ayarAdi = cicekSepetiViewModel.ayarAdi;
            result.Cicek.ayar = cicekSepetiViewModel.ayar;
            result.Cicek.barkod = cicekSepetiViewModel.barkod;
            result.Cicek.brand = cicekSepetiViewModel.brand;
            result.Cicek.kargo = cicekSepetiViewModel.kargo;
            result.Cicek.aciklama = cicekSepetiViewModel.aciklama;
            result.Cicek.cinsiyet = cicekSepetiViewModel.cinsiyet;
            result.Cicek.resim = cicekSepetiViewModel.resim;
            result.Cicek.listeFiyat = cicekSepetiViewModel.listeFiyat;
            result.Cicek.satisFiyat = cicekSepetiViewModel.satisFiyat;
            result.Cicek.kategori = cicekSepetiViewModel.kategori;
            result.Cicek.stok = Convert.ToString(cicekSepetiViewModel.adet);
            result.Cicek.stokKodu = cicekSepetiViewModel.stokKodu;
            result.Cicek.baslik = cicekSepetiViewModel.baslik;
            result.Cicek.kdv = cicekSepetiViewModel.kdv;
            result.Cicek.mail = cicekSepetiViewModel.mail;
            result.Cicek.durum = cicekSepetiViewModel.durum;
            result.Cicek.upTarih = cicekSepetiViewModel.upTarih;
            result.Cicek.upFiyatTarih = cicekSepetiViewModel.upFiyatTarih;
           

            db.SaveChanges();
            return Ok();
        }

        // POST: api/CicekSepeti_AktifUrunler
        [ResponseType(typeof(CicekSepeti_AktifUrunler))]
        public IHttpActionResult PostCicekSepeti_AktifUrunler(CicekSepetiViewModel cicekSepetiViewModel)
        {
            if (db.CicekSepeti_AktifUrunler.Any(x => x.barkod == cicekSepetiViewModel.barkod))
            {
                return BadRequest("Bu barkod numarasına sahip bir ürün zaten var.");

            }
            var result = (from a in db.CicekSepeti_AktifUrunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          select new
                          {
                              Trend = a,
                              Urun = b
                          }).FirstOrDefault();
            db.CicekSepeti_AktifUrunler.Add(new CicekSepeti_AktifUrunler()
            {
                barkod = cicekSepetiViewModel.barkod,
                itarih = cicekSepetiViewModel.itarih,
                silme = cicekSepetiViewModel.silme,
                ayarAdi = cicekSepetiViewModel.ayarAdi,
                ayar = cicekSepetiViewModel.ayar,
                brand = cicekSepetiViewModel.brand,
                kargo = cicekSepetiViewModel.kargo,
                aciklama = cicekSepetiViewModel.aciklama,
                cinsiyet = cicekSepetiViewModel.cinsiyet,
                resim = cicekSepetiViewModel.resim,
                batchId = cicekSepetiViewModel.batchId,
                panoHas = cicekSepetiViewModel.panoHas,
                listeFiyat = cicekSepetiViewModel.listeFiyat,
                satisFiyat = cicekSepetiViewModel.satisFiyat,
                kategori = cicekSepetiViewModel.kategori,
                stok = Convert.ToString(cicekSepetiViewModel.adet),
                stokKodu = cicekSepetiViewModel.stokKodu,
                baslik = cicekSepetiViewModel.baslik,
                kdv = cicekSepetiViewModel.kdv,
                mail = cicekSepetiViewModel.mail,
                durum = cicekSepetiViewModel.durum,
                upTarih = cicekSepetiViewModel.upTarih,
                upFiyatTarih = cicekSepetiViewModel.upFiyatTarih
               

            });
            db.UrunBilgis.Add(new UrunBilgi()
            {
                barkod = cicekSepetiViewModel.barkod,
                magazaId = 6,
                ayarAdi = cicekSepetiViewModel.ayarAdi,
                ayar = cicekSepetiViewModel.ayar,
                urunAdi = cicekSepetiViewModel.baslik,
                gram = cicekSepetiViewModel.gram,
                resim = cicekSepetiViewModel.resim,
                milyem = cicekSepetiViewModel.milyem,
                durum = cicekSepetiViewModel.durum,
                komisyon = cicekSepetiViewModel.komisyon,
                yuzde = cicekSepetiViewModel.yuzde,
                gun = cicekSepetiViewModel.gun,
                adet = cicekSepetiViewModel.adet
               
            });


            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cicekSepetiViewModel.otosay }, cicekSepetiViewModel);
        }

        // DELETE: api/CicekSepeti_AktifUrunler/5
        [ResponseType(typeof(CicekSepeti_AktifUrunler))]
        public IHttpActionResult DeleteCicekSepeti_AktifUrunler(long id)
        {
            CicekSepeti_AktifUrunler cicekSepeti_AktifUrunler = db.CicekSepeti_AktifUrunler.Find(id);
            if (id == null)
            {
                return NotFound();
            }

            //db.CicekSepeti_AktifUrunler.Remove(cicekSepeti_AktifUrunler);
            cicekSepeti_AktifUrunler.silme = true;
            db.SaveChanges();

            return Ok(cicekSepeti_AktifUrunler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CicekSepeti_AktifUrunlerExists(long id)
        {
            return db.CicekSepeti_AktifUrunler.Count(e => e.otosay == id) > 0;
        }
    }
}