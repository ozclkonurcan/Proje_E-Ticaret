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
   
    public class UrunBilgiController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/UrunBilgi
        public IQueryable<UrunBilgi> GetUrunBilgis()
        {
            return db.UrunBilgis;
        }

        // GET: api/UrunBilgi
   
        // GET: api/UrunBilgi/5
        [ResponseType(typeof(UrunBilgi))]
        public IHttpActionResult GetUrunBilgi(long id)
        {
            UrunBilgi urunBilgi = db.UrunBilgis.Find(id);
            if (urunBilgi == null)
            {
                return NotFound();
            }

            return Ok(urunBilgi);
        }

        // PUT: api/UrunBilgi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUrunBilgi(long id, UrunBilgi urunBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != urunBilgi.Id)
            {
                return BadRequest();
            }

            db.Entry(urunBilgi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunBilgiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
       
        // POST: api/UrunBilgi
        //[ResponseType(typeof(UrunBilgi))]
        //public IHttpActionResult PostUrunBilgi(UrunBilgi urunBilgi)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.UrunBilgis.Add(urunBilgi);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = urunBilgi.Id }, urunBilgi);
        //}

        // POST: api/SM_Urunler
        [ResponseType(typeof(UrunBilgi))]
        public IHttpActionResult PostUrunBilgi(UrunBilgiViewModel urunBilgiViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var records = (from a in db.UrunBilgis
                      
                           where a.magazaId == urunBilgiViewModel.magazaId
                         
                           select new
                           {
                              
                               Urun = a,
                           }).ToList();

            records.ForEach(e =>
            {
                e.Urun.yuzde = urunBilgiViewModel.yuzde;
                e.Urun.gun = urunBilgiViewModel.gun;
                e.Urun.komisyon = urunBilgiViewModel.komisyon;
                e.Urun.adet = urunBilgiViewModel.adet;

            });
           // records.ForEach(e =>  e.Urun.yuzde = urunBilgiViewModel.yuzde  ); //Toplu güncelleştirme denemesi! çalıştı bu deneme
                                                                             //// db.UrunBilgis.Remove(urunBilgi);

            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = urunBilgiViewModel.Id }, urunBilgiViewModel);
        }

        ////DELETE: api/UrunBilgi/5
        //[ResponseType(typeof(UrunBilgi))]
        //[Route("api/[all_update]")] 
        //public IHttpActionResult DeleteUrunBilgi(long id, UrunBilgiViewModel urunBilgiViewModel)
        //{

        //    var records = (from a in db.SM_Urunler
        //                   join b in db.UrunBilgis on a.barkod equals b.barkod
        //                   where b.magazaId == 5
        //                   select new
        //                   {
        //                       Sm = a,
        //                       Urun = b
        //                   }).ToList();
        //    records.ForEach(e => e.Sm.panoHas = urunBilgiViewModel.panoHas); //Toplu güncelleştirme denemesi! çalıştı bu deneme
        //    //// db.UrunBilgis.Remove(urunBilgi);
        //    db.SaveChanges();

        //    return Ok();
        //}
        // PUT: api/UrunBilgi/5 for all update
        //[HttpPut]
        //[Route("api/{allupdatePUT}")]
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUrunBilgi2(long id, UrunBilgiViewModel urunBilgiViewModel)
        //{
        //    var records = (from a in db.SM_Urunler
        //                   join b in db.UrunBilgis on a.barkod equals b.barkod
        //                   where b.magazaId == 5
        //                   select new
        //                   {
        //                       Sm = a,
        //                       Urun = b
        //                   }).ToList();
        //    records.ForEach(e => e.Sm.panoHas = urunBilgiViewModel.panoHas); //Toplu güncelleştirme denemesi! çalıştı bu deneme
        //    //// db.UrunBilgis.Remove(urunBilgi);
        //    db.SaveChanges();
        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UrunBilgiExists(long id)
        {
            return db.UrunBilgis.Count(e => e.Id == id) > 0;
        }
    }
}