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
    public class ePtt_UrunlerController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/ePtt_Urunler
        public IHttpActionResult GetePtt_Urunler()
        {
            var Tlist = (from a in db.ePtt_Urunler
                         join p in db.UrunBilgis on a.barkod equals p.barkod
                         where p.magazaId == 3
                         select new
                         {
                             a.Id,
                             a.aciklama,
                             a.aktif,
                             a.kategori,
                             a.anaKategoriId,
                             a.altKategoriAdi,
                             a.altKategoriId,
                             a.barkod,
                             a.boyX,
                             a.boyY,
                             a.boyZ,
                             a.desi,
                             a.durum,
                             a.garantiSure,
                             a.GarantiVerenFirma,
                             a.Iskonto,
                             a.KDVOran,
                             a.KDVli,
                             a.KDVsiz,
                             a.KategoriBilgisiGuncelle,
                             a.Mevcut,
                             p.adet,
                             a.ShopId,
                             a.Tag,
                             a.TedarikciAltKategoriAdi,
                             a.TedarikciAltKategoriId,
                             a.TedarikciSanalKategoriId,
                             a.UrunAdi,
                             a.UrunId,
                             a.UzunAciklama,
                             a.fiyat,
                             a.upTime,
                             a.adurum,
                             a.YeniKategoriId,
                             a.upFiyatTarih,
                             a.panoHas,
                             p.resim,
                             p.milyem,
                             p.gram,
                             p.yuzde,
                             p.komisyon,
                             p.gun


                         }).ToList();


            return Ok(Tlist);
        }

        // GET: api/ePtt_Urunler/5
        [ResponseType(typeof(ePtt_Urunler))]
        public IHttpActionResult GetePtt_Urunler(long id)
        {
            var result = (from a in db.ePtt_Urunler
                          join p in db.UrunBilgis on a.barkod equals p.barkod
                          where p.magazaId == 3 && a.Id == id
                          select new
                          {
                              a.Id,
                              a.aciklama,
                              a.aktif,
                              a.kategori,
                              a.anaKategoriId,
                              a.altKategoriAdi,
                              a.altKategoriId,
                              a.barkod,
                              a.boyX,
                              a.boyY,
                              a.boyZ,
                              a.desi,
                              a.durum,
                              a.garantiSure,
                              a.GarantiVerenFirma,
                              a.Iskonto,
                              a.KDVOran,
                              a.KDVli,
                              a.KDVsiz,
                              a.KategoriBilgisiGuncelle,
                              a.Mevcut,
                              p.adet,
                              a.ShopId,
                              a.Tag,
                              a.TedarikciAltKategoriAdi,
                              a.TedarikciAltKategoriId,
                              a.TedarikciSanalKategoriId,
                              a.UrunAdi,
                              a.UrunId,
                              a.UzunAciklama,
                              a.fiyat,
                              a.upTime,
                              a.adurum,
                              a.YeniKategoriId,
                              a.upFiyatTarih,
                              a.panoHas,
                              p.resim,
                              p.milyem,
                              p.gram,
                              p.yuzde,
                              p.komisyon,
                              p.gun
                          }).FirstOrDefault();


            return Ok(result);
        }

        // PUT: api/ePtt_Urunler/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutePtt_Urunler(long id, EpttViewModel epttViewModel)
        {
            var result = (from a in db.ePtt_Urunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          where b.magazaId == 3 && a.Id == id
                          select new
                          {
                              Eptt = a,
                              Urun = b
                          }).FirstOrDefault();

            result.Urun.milyem = epttViewModel.milyem;
            result.Urun.komisyon = epttViewModel.komisyon;
            result.Urun.resim = epttViewModel.resim;
            result.Urun.barkod = epttViewModel.barkod;
            result.Urun.urunAdi = epttViewModel.UrunAdi;
            result.Urun.adet = epttViewModel.adet;
            result.Eptt.aciklama = epttViewModel.aciklama;
            result.Eptt.aktif = epttViewModel.aktif;
            result.Eptt.kategori = epttViewModel.kategori;
            result.Eptt.anaKategoriId = epttViewModel.anaKategoriId;
            result.Eptt.altKategoriAdi = epttViewModel.altKategoriAdi;
            result.Eptt.altKategoriId = epttViewModel.altKategoriId;
            result.Eptt.barkod = epttViewModel.barkod;
            result.Eptt.boyX = epttViewModel.boyX;
            result.Eptt.boyY = epttViewModel.boyY;
            result.Eptt.boyZ = epttViewModel.boyZ;
            result.Eptt.desi = epttViewModel.desi;
            result.Eptt.durum = epttViewModel.durum;
            result.Eptt.garantiSure = epttViewModel.garantiSure;
            result.Eptt.GarantiVerenFirma = epttViewModel.GarantiVerenFirma;
            result.Eptt.Iskonto = epttViewModel.Iskonto;
            result.Eptt.KDVOran = epttViewModel.KDVOran;
            result.Eptt.KDVli = epttViewModel.KDVli;
            result.Eptt.KDVsiz = epttViewModel.KDVsiz;
            result.Eptt.KategoriBilgisiGuncelle = epttViewModel.KategoriBilgisiGuncelle;
            result.Eptt.Mevcut = epttViewModel.Mevcut;
            result.Eptt.Miktar = epttViewModel.adet;
            result.Eptt.ShopId = epttViewModel.ShopId;
            result.Eptt.Tag = epttViewModel.Tag;
            result.Eptt.TedarikciAltKategoriAdi = epttViewModel.TedarikciAltKategoriAdi;
            result.Eptt.TedarikciAltKategoriId = epttViewModel.TedarikciAltKategoriId;
            result.Eptt.TedarikciSanalKategoriId = epttViewModel.TedarikciSanalKategoriId;
            result.Eptt.UrunAdi = epttViewModel.UrunAdi;
            result.Eptt.UrunId = epttViewModel.UrunId;
            result.Eptt.UzunAciklama = epttViewModel.UzunAciklama;
            result.Eptt.fiyat = epttViewModel.fiyat;
            result.Eptt.upTime = epttViewModel.upTime;
            result.Eptt.adurum = epttViewModel.adurum;
            result.Eptt.YeniKategoriId = epttViewModel.YeniKategoriId;
            result.Eptt.upFiyatTarih = epttViewModel.upFiyatTarih;
            result.Urun.resim = epttViewModel.resim;
            result.Eptt.UrunResimleri = epttViewModel.resim;

            db.SaveChanges();
            return Ok();
        }

        // POST: api/ePtt_Urunler
        [ResponseType(typeof(ePtt_Urunler))]
        public IHttpActionResult PostePtt_Urunler(EpttViewModel epttViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (db.ePtt_Urunler.Any(x => x.barkod == epttViewModel.barkod))
            {
                return BadRequest("Bu barkod numarasına sahip bir ürün zaten var.");

            }
            var result = (from a in db.ePtt_Urunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          select new
                          {
                              Eptt = a,
                              Urun = b
                          }).FirstOrDefault();
            db.ePtt_Urunler.Add(new ePtt_Urunler()
            {
                             aciklama = epttViewModel.aciklama,
                             aktif = epttViewModel.aktif,
                             kategori = epttViewModel.kategori,
                             anaKategoriId  = epttViewModel.anaKategoriId,
                             altKategoriAdi = epttViewModel.altKategoriAdi,
                             altKategoriId = epttViewModel.altKategoriId,
                             barkod = epttViewModel.barkod,
                             boyX = epttViewModel.boyX,
                             boyY = epttViewModel.boyY,
                             boyZ = epttViewModel.boyZ,
                             desi = epttViewModel.desi,
                             durum = epttViewModel.durum,
                             garantiSure = epttViewModel.garantiSure,
                             GarantiVerenFirma = epttViewModel.GarantiVerenFirma,
                             Iskonto = epttViewModel.Iskonto,
                             KDVOran = epttViewModel.KDVOran,
                             KDVli = epttViewModel.KDVli,
                             KDVsiz = epttViewModel.KDVsiz,
                             KategoriBilgisiGuncelle = epttViewModel.KategoriBilgisiGuncelle,
                             Mevcut = epttViewModel.Mevcut,
                             Miktar = epttViewModel.adet,
                             ShopId = epttViewModel.ShopId,
                             Tag = epttViewModel.Tag,
                             TedarikciAltKategoriAdi = epttViewModel.TedarikciAltKategoriAdi,
                             TedarikciAltKategoriId = epttViewModel.TedarikciAltKategoriId,
                             TedarikciSanalKategoriId = epttViewModel.TedarikciSanalKategoriId,
                             UrunAdi = epttViewModel.UrunAdi,
                             UrunId = epttViewModel.UrunId,
                             UzunAciklama = epttViewModel.UzunAciklama,
                             fiyat = epttViewModel.fiyat,
                             upTime = epttViewModel.upTime,
                             adurum = epttViewModel.adurum,
                             YeniKategoriId = epttViewModel.YeniKategoriId,
                             upFiyatTarih = epttViewModel.upFiyatTarih,
                             panoHas = epttViewModel.panoHas,
                             UrunResimleri = epttViewModel.resim
                          

            });
            db.UrunBilgis.Add(new UrunBilgi()
            {
                barkod = epttViewModel.barkod,
                magazaId = 3,
                urunAdi = epttViewModel.UrunAdi,
                gram = epttViewModel.gram,
                resim = epttViewModel.resim,
                milyem = epttViewModel.milyem,
                komisyon = epttViewModel.komisyon,
                yuzde = epttViewModel.yuzde,
                gun = epttViewModel.gun,
                adet = epttViewModel.adet
            });


            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = epttViewModel.Id }, epttViewModel);
        }

        // DELETE: api/ePtt_Urunler/5
        [ResponseType(typeof(ePtt_Urunler))]
        public IHttpActionResult DeleteePtt_Urunler(long id)
        {
            ePtt_Urunler ePtt_Urunler = db.ePtt_Urunler.Find(id);
            if (ePtt_Urunler == null)
            {
                return NotFound();
            }
            ePtt_Urunler.durum = "2";
            //db.ePtt_Urunler.Remove(ePtt_Urunler);
            db.SaveChanges();

            return Ok(ePtt_Urunler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ePtt_UrunlerExists(long id)
        {
            return db.ePtt_Urunler.Count(e => e.Id == id) > 0;
        }
    }
}
