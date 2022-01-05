using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {

            return View();
            }
        }

     

        public ActionResult About()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
        }

        public ActionResult Contact()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
        }
    }
}