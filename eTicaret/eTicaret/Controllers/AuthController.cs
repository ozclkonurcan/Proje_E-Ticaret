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
using System.Web.Security;
using eTicaret.Models;

namespace eTicaret.Controllers
{
    public class AuthController : ApiController
    {
        private eTicaretDbEntities db = new eTicaretDbEntities();

        // GET: api/Auth
        public IQueryable<Kullanici> GetKullanicis()
        {
            return db.Kullanicis;
        }


        [HttpGet]
        public HttpResponseMessage ValidLogin(string kullaniciAdi,string kullaniciPassword)
        {
            if(kullaniciAdi == "ozclkonur" && kullaniciPassword == "a")
            {
                return Request.CreateResponse(HttpStatusCode.OK, TokenManager1.GenerateToken(kullaniciAdi));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, "User name and password is invalid");
            }
        }

        // GET: api/Auth/5
        [ResponseType(typeof(Kullanici))]
        public IHttpActionResult GetKullanici(int id)
        {
            Kullanici kullanici = db.Kullanicis.Find(id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return Ok(kullanici);
        }

        // PUT: api/Auth/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKullanici(int id, Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kullanici.K_ID)
            {
                return BadRequest();
            }

            db.Entry(kullanici).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciExists(id))
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

        // POST: api/Auth
        [ResponseType(typeof(Kullanici))]
        public IHttpActionResult Login(Kullanici model,string returnUrl)
        {
          var dataItem = db.Kullanicis.Where(x => x.kullaniciAdi == model.kullaniciAdi && x.kullaniciPassword == model.kullaniciPassword).First();

          

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kullanicis.Add(model);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.K_ID }, model);
        }

        // DELETE: api/Auth/5
        [ResponseType(typeof(Kullanici))]
        public IHttpActionResult DeleteKullanici(int id)
        {
            Kullanici kullanici = db.Kullanicis.Find(id);
            if (kullanici == null)
            {
                return NotFound();
            }

            db.Kullanicis.Remove(kullanici);
            db.SaveChanges();

            return Ok(kullanici);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KullaniciExists(int id)
        {
            return db.Kullanicis.Count(e => e.K_ID == id) > 0;
        }
    }
}