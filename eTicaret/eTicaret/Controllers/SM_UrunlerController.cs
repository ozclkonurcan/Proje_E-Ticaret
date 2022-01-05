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
using eTicaret.ViewModel;

namespace eTicaret.Controllers
{
    public class SM_UrunlerController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/SM_Urunler
        public IHttpActionResult GetSM_Urunler()
        {

            var Tlist = (from a in db.SM_Urunler
                         join p in db.UrunBilgis on a.barkod equals p.barkod
                         where p.magazaId == 5
                         select new
                         {
                             a.Id,
                             a.urunAdi,
                             a.aciklama,
                             a.marka,
                             a.barkod,
                             p.adet,
                             a.desi,
                             a.kdv,
                             p.resim,
                             a.model,
                             a.panoHas,
                             a.maliyet,
                             a.sonFiyat,
                             a.durum,
                             a.upFiyatTarih,
                             p.milyem,
                             p.gram,
                             p.yuzde,
                             p.komisyon,
                             p.gun


                         }).ToList();


            return Ok(Tlist);
        }
     
     

        // GET: api/SM_Urunler/5
        [ResponseType(typeof(SM_Urunler))]
        public IHttpActionResult GetSM_Urunler(long id)
        {
            var result = (from a in db.SM_Urunler
                          join p in db.UrunBilgis on a.barkod equals p.barkod
                          where p.magazaId == 5 && a.Id == id
                          select new
                          {
                              a.Id,
                              a.urunAdi,
                              a.aciklama,
                              a.marka,
                              a.barkod,
                              p.adet,
                              a.desi,
                              a.kdv,
                              p.resim,
                              a.model,
                              a.panoHas,
                              a.maliyet,
                              a.sonFiyat,
                              a.durum,
                              a.upFiyatTarih,
                              p.milyem,
                              p.gram,
                              p.yuzde,
                              p.komisyon,
                              p.gun
                          }).FirstOrDefault();


            return Ok(result);
        }

        // PUT: api/SM_Urunler/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSM_Urunler(long id, SmUrunlerViewModel smUrunlerViewModel)
        {
            var result = (from a in db.SM_Urunler
                          join b in db.UrunBilgis on a.barkod equals b.barkod
                          where b.magazaId == 5 && a.Id == id
                          select new
                          {
                              Sm = a,
                              Urun = b
                          }).FirstOrDefault();

            result.Urun.milyem = smUrunlerViewModel.milyem;
            result.Urun.komisyon = smUrunlerViewModel.komisyon;
            result.Urun.resim = smUrunlerViewModel.resim;
            result.Urun.barkod = smUrunlerViewModel.barkod;
            result.Urun.urunAdi = smUrunlerViewModel.urunAdi;
            result.Urun.adet = smUrunlerViewModel.adet;
            result.Sm.barkod = smUrunlerViewModel.barkod;
            result.Sm.urunAdi = smUrunlerViewModel.urunAdi;
            result.Sm.aciklama = smUrunlerViewModel.aciklama;
            result.Sm.marka = smUrunlerViewModel.marka;
            result.Sm.stok = smUrunlerViewModel.adet;
            result.Sm.desi = smUrunlerViewModel.desi;
            result.Sm.kdv = smUrunlerViewModel.kdv;
            result.Sm.resim = smUrunlerViewModel.resim;
            result.Sm.model = smUrunlerViewModel.model;
            result.Sm.maliyet = smUrunlerViewModel.maliyet;
            result.Sm.sonFiyat = smUrunlerViewModel.sonFiyat;
            result.Sm.durum = smUrunlerViewModel.durum;
            result.Sm.upFiyatTarih = smUrunlerViewModel.upFiyatTarih;



            db.SaveChanges();
            return Ok();
        }

        // POST: api/SM_Urunler
        [ResponseType(typeof(SM_Urunler))]
        public IHttpActionResult PostSM_Urunler(SmUrunlerViewModel smUrunlerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (db.SM_Urunler.Any(x => x.barkod == smUrunlerViewModel.barkod))
            {
                return BadRequest("Bu barkod numarasına sahip bir ürün zaten var.");

            }
            db.SM_Urunler.Add(new SM_Urunler()
            {
                urunAdi = smUrunlerViewModel.urunAdi,
                aciklama = smUrunlerViewModel.aciklama,
                marka = smUrunlerViewModel.marka,
                barkod = smUrunlerViewModel.barkod,
                stok = smUrunlerViewModel.adet,
                desi = smUrunlerViewModel.desi,
                kdv = smUrunlerViewModel.kdv,
                resim = smUrunlerViewModel.resim,
                model = smUrunlerViewModel.model,
                panoHas = smUrunlerViewModel.panoHas,
                maliyet = smUrunlerViewModel.maliyet,
                sonFiyat = smUrunlerViewModel.sonFiyat,
                durum = smUrunlerViewModel.durum,
                upFiyatTarih = smUrunlerViewModel.upFiyatTarih,

            });
            db.UrunBilgis.Add(new UrunBilgi()
            {
                barkod = smUrunlerViewModel.barkod,
                magazaId = 5,
                urunAdi = smUrunlerViewModel.urunAdi,
                gram = smUrunlerViewModel.gram,
                resim = smUrunlerViewModel.resim,
                milyem = smUrunlerViewModel.milyem,
                durum = smUrunlerViewModel.durum,
                komisyon = smUrunlerViewModel.komisyon,
                yuzde = smUrunlerViewModel.yuzde,
                gun = smUrunlerViewModel.gun,
                adet = smUrunlerViewModel.adet
            });
            db.SaveChanges();
                
            return CreatedAtRoute("DefaultApi", new { id = smUrunlerViewModel.Id }, smUrunlerViewModel);
        }

        // DELETE: api/SM_Urunler/5
        [ResponseType(typeof(SM_Urunler))]
        public IHttpActionResult DeleteSM_Urunler(long id, SM_Urunler kek)
        {
            SM_Urunler sM_Urunler = db.SM_Urunler.Find(id);
            if (sM_Urunler == null)
            {
                return NotFound();
            }

            //var records = db.SM_Urunler.Where(x => x.Id > 0).ToList();
            //records.ForEach(e => e.panoHas = 9999); Toplu güncelleştirme denemesi ! çalıştı bu deneme

            // db.SM_Urunler.Remove(sM_Urunler);
            sM_Urunler.durum = false;
            db.SaveChanges();

            return Ok(sM_Urunler);
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SM_UrunlerExists(long id)
        {
            return db.SM_Urunler.Count(e => e.Id == id) > 0;
        }
    }
}