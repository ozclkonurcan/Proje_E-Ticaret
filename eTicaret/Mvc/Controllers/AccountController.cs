using eTicaret.Models;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        //Error
        public ActionResult ErrorPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(mvcLoginModel adminLogin)
        {
            using(eTicaretDbEntities db = new eTicaretDbEntities())
            {
                var obj = db.Kullanicis.Where(x => x.kullaniciAdi == adminLogin.kullaniciAdi && x.kullaniciPassword == adminLogin.kullaniciPassword).FirstOrDefault();
                if(obj == null)
                {
                    adminLogin.loginErrorMessage = "Yanlış kullanıcı adı ve şifre";
                    return View("Index", adminLogin);
                }
                else if(adminLogin.kullaniciAdi == "" || adminLogin.kullaniciPassword == "")
                {
                    TempData["SuccessMessage"] = "İkisinden biri boş yada ikiside boş";
                    return View("Index", adminLogin);
                }
                else
                {
                    Session["K_ID"] = obj.K_ID;
                    Session["kullaniciAdi"] = obj.kullaniciAdi;
                    Session["kullaniciAdiSoyadi"] = obj.kullaniciAdiSoyadi;
                    Session["kullaniciEmail"] = obj.kullaniciEmail;
                    Session["kullaniciResim"] = obj.kullaniciResim;
                    Session["kullaniciUnvan"] = obj.kullaniciUnvan;
                    //Session["kullanicisPassword"] = obj.kullaniciPassword;
                    TempData["SuccessMessage"] = "Giriş Başarılı";
                    return RedirectToAction("", "Urunler");
                }

            }
            
        }

        public ActionResult logout(mvcLoginModel adminLog)
        {
           int K_ID = (int)Session["K_ID"];
            Session.Abandon();
           TempData["BadMsg"] = "Çıkış başarılı"+adminLog.K_ID.ToString();
            return RedirectToAction("Index","Account");
        }

       

    }
}