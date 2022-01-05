using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Mvc.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: SM_Urunler
        public ActionResult Index()
        {
            if(Session["kullaniciAdi"]== null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
             
            IEnumerable<mvcSmModel> smurunlerlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Sm_Urunler").Result;
            smurunlerlist = response.Content.ReadAsAsync<IEnumerable<mvcSmModel>>().Result;
              
            return View(smurunlerlist);
            }
        }


        public ActionResult SM_UrunlerRemove(long id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Sm_Urunler/" + id).Result;
                TempData["SuccessMessage"] = "Silme işlemi başarılı";
                return RedirectToAction("");
            }
        }

        // //Toplu Update SM
        public ActionResult UrunBilgiEdit(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcUrunBilgiModel());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("urunbilgi/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcUrunBilgiModel>().Result);
                }
            }
        }
        [HttpPost]
        [ValidateInput(false)]//html etiketlerini text e yedirmek için kullandım
        public ActionResult UrunBilgiEdit(mvcUrunBilgiModel urun)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {

                if (urun.Id == 0)
                {

                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("urunbilgi", urun).Result;

                    TempData["SuccessMessage"] = "Ekleme işlemi başarılı";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("urunbilgi/" + urun.Id, urun).Result;
                    TempData["SuccessMessage"] = "Güncelleme işlemi başarılı";
                }
                return RedirectToAction("SM_UrunlerAddOrEdit", "urunler");
            }
        }

        //// Toplu Update SM

        //public ActionResult SM_UrunlerRemove(long id = 0)
        //{
        //    if (Session["kullaniciAdi"] == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    else
        //    {
        //        if (id == 0)
        //            return View(new mvcSmModel());
        //        else
        //        {
        //            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Sm_Urunler/" + id.ToString()).Result;
        //            return View(response.Content.ReadAsAsync<mvcSmModel>().Result);
        //        }
        //    }
        //}


        public ActionResult SM_UrunlerDetails(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcSmModel());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Sm_Urunler/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcSmModel>().Result);
                }
            }
        }
        public ActionResult SM_UrunlerAddOrEdit(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcSmModel());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Sm_Urunler/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcSmModel>().Result);
                }
            }
        }
        [HttpPost]
        [ValidateInput(false)]//html etiketlerini text e yedirmek için kullandım
        public ActionResult SM_UrunlerAddOrEdit(mvcSmModel urun)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
               
                if (urun.Id == 0)
                {
                  
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Sm_Urunler", urun).Result;
       
                    TempData["SuccessMessage"] = "Ekleme işlemi başarılı";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Sm_Urunler/" + urun.Id, urun).Result;
                    TempData["SuccessMessage"] = "Güncelleme işlemi başarılı";
                }
                return RedirectToAction("SM_UrunlerAddOrEdit","urunler");
            }
        }



        //SM_Urunler

        //Get:UrunBilgi
        public ActionResult UrunBilgiList()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                IEnumerable<mvcUrunBilgiModel> urunbilgiliste;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("UrunBilgi").Result;
                urunbilgiliste = response.Content.ReadAsAsync<IEnumerable<mvcUrunBilgiModel>>().Result;
                return View(urunbilgiliste);
            }
        }

        //Get:UrunBilgi

        //Hepsiburada
        public ActionResult HepsiBuradaList()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                IEnumerable<mvcHepsiBuradaModel> hepsiburadaListe;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("HepsiBurada").Result;
                hepsiburadaListe = response.Content.ReadAsAsync<IEnumerable<mvcHepsiBuradaModel>>().Result;
                return View(hepsiburadaListe);
            }
        }

        public ActionResult HepsiBuradaDetails(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcHepsiBuradaModel());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("HepsiBurada/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcHepsiBuradaModel>().Result);
                }
            }
        }
        [HttpPost]
        [ValidateInput(false)]//html etiketlerini text e yedirmek için kullandım
        public ActionResult HepsiBuradaDetails(mvcHepsiBuradaModel hepsiburada)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {

                if (hepsiburada.otosay == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("HepsiBurada", hepsiburada).Result;
                    TempData["SuccessMessage"] = "Ekleme işlemi başarılı";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("HepsiBurada/" + hepsiburada.otosay, hepsiburada).Result;
                    TempData["SuccessMessage"] = "Güncelleme işlemi başarılı";
                }
                return RedirectToAction("HepsiBuradaDetails","urunler");
            }
        }

        //public ActionResult HepsiBuradaDetails(long id = 0)
        //{
        //    if (Session["kullaniciAdi"] == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    else
        //    {
        //        if (id == 0)
        //            return View(new mvcHepsiBuradaModel());
        //        else
        //        {
        //            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("HepsiBurada/" + id.ToString()).Result;
        //            return View(response.Content.ReadAsAsync<mvcHepsiBuradaModel>().Result);
        //        }
        //    }
        //}

        public ActionResult HepsiBuradaRemove(long id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("HepsiBurada/" + id).Result;
                TempData["SuccessMessage"] = "Deleted Successfuly";
                return RedirectToAction("hepsiburadalist");
            }
        }


        //Hepsiburada
        //N11
        public ActionResult N11List()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                IEnumerable<mvcN11Model> n11Liste;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("n11_Urunler").Result;
                n11Liste = response.Content.ReadAsAsync<IEnumerable<mvcN11Model>>().Result;
                return View(n11Liste);
            }
        }
        //public ActionResult N11Details(long id = 0)
        //{
        //    if (Session["kullaniciAdi"] == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    else
        //    {
        //        if (id == 0)
        //            return View(new mvcN11Model());
        //        else
        //        {
        //            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("n11_Urunler/" + id.ToString()).Result;
        //            return View(response.Content.ReadAsAsync<mvcN11Model>().Result);
        //        }
        //    }
        //}
        public ActionResult N11Remove(long id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("n11_Urunler/" + id.ToString()).Result;
                TempData["SuccessMessage"] = "Deleted Successfuly";
                return RedirectToAction("n11list");
            }
        }
        public ActionResult N11Details(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcN11Model());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("n11_Urunler/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcN11Model>().Result);
                }
            }
        }
        [HttpPost]
        public ActionResult N11Details(mvcN11Model n11)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (n11.Id == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("n11_Urunler", n11).Result;
                    TempData["SuccessMessage"] = "Ekleme işlemi başarılı";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("n11_Urunler/" + n11.Id, n11).Result;
                    TempData["SuccessMessage"] = "Güncelleme işlemi başarılı";
                }
                return RedirectToAction("N11Details","urunler");
            }
        }
        //N11
        //Trendyol
        public ActionResult TrendList()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                IEnumerable<mvcTrendyolModel> trendyolList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Trend_AktifUrunler").Result;
                trendyolList = response.Content.ReadAsAsync<IEnumerable<mvcTrendyolModel>>().Result;
                return View(trendyolList);
            }
        }
        //public ActionResult TrendyolDetails(long id = 0)
        //{
        //    if (Session["kullaniciAdi"] == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    else
        //    {
        //        if (id == 0)
        //        return View(new mvcTrendyolModel());
        //    else
        //    {
        //        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Trend_AktifUrunler/" + id.ToString()).Result;
        //        return View(response.Content.ReadAsAsync<mvcTrendyolModel>().Result);
        //    }
        //}
        //}
        public ActionResult TrendyolRemove(long id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Trend_AktifUrunler/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfuly";
            return RedirectToAction("trendlist");
        }
        }
        public ActionResult TrendyolDetails(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcTrendyolModel());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Trend_AktifUrunler/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcTrendyolModel>().Result);
                }
            }
        }
        [HttpPost]
        [ValidateInput(false)]//html etiketlerini text e yedirmek için kullandım
        public ActionResult TrendyolDetails(mvcTrendyolModel trend)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (trend.otosay == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Trend_AktifUrunler", trend).Result;
                    TempData["SuccessMessage"] = "Ekleme işlemi başarılı";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Trend_AktifUrunler/" + trend.otosay, trend).Result;
                    TempData["SuccessMessage"] = "Güncelleme işlemi başarılı";
                }
                return RedirectToAction("TrendyolDetails","urunler");
            }
        }
        //Trendyol
        /// Eptttttttttttttttttt
        public ActionResult EpttList()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                IEnumerable<mvcEpttModel> EpttList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ePtt_Urunler").Result;
                EpttList = response.Content.ReadAsAsync<IEnumerable<mvcEpttModel>>().Result;
                return View(EpttList);
            }
        }

        public ActionResult EpttRemove(long id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("ePtt_Urunler/" + id).Result;
                TempData["SuccessMessage"] = "Deleted Successfuly";
                return RedirectToAction("epttlist");
            }
        }

        public ActionResult EpttDetails(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcEpttModel());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ePtt_Urunler/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcEpttModel>().Result);
                }
            }
        }
        [HttpPost]
        [ValidateInput(false)]//html etiketlerini text e yedirmek için kullandım
        public ActionResult EpttDetails(mvcEpttModel ptt)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (ptt.Id == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("ePtt_Urunler", ptt).Result;
                    TempData["SuccessMessage"] = "Ekleme işlemi başarılı";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("ePtt_Urunler/" + ptt.Id, ptt).Result;
                    TempData["SuccessMessage"] = "Güncelleme işlemi başarılı";
                }
                return RedirectToAction("EpttDetails","urunler");
            }
        }

        //public ActionResult EpttDetails(long id = 0)
        //{
        //    if (Session["kullaniciAdi"] == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    else
        //    {
        //        if (id == 0)
        //            return View(new mvcEpttModel());
        //        else
        //        {
        //            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ePtt_Urunler/" + id.ToString()).Result;
        //            return View(response.Content.ReadAsAsync<mvcEpttModel>().Result);
        //        }
        //    }
        //}
        ///Epttttttttttttttttttttt
        public ActionResult CicekSepetiList()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                IEnumerable<mvcCicekSepetiModel> CicekSepetiList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("cicekSepeti_AktifUrunler").Result;
                CicekSepetiList = response.Content.ReadAsAsync<IEnumerable<mvcCicekSepetiModel>>().Result;
                return View(CicekSepetiList);
            }
        }

        public ActionResult cicekSepetiRemove(long id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("CicekSepeti_AktifUrunler/" + id).Result;
                TempData["SuccessMessage"] = "Deleted Successfuly";
                return RedirectToAction("ciceksepetilist");
            }
        }

       public ActionResult CicekSepetiDetails(long id = 0)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (id == 0)
                    return View(new mvcCicekSepetiModel());
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CicekSepeti_AktifUrunler/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<mvcCicekSepetiModel>().Result);
                }
            }
        }
        [HttpPost]
        [ValidateInput(false)]//html etiketlerini text e yedirmek için kullandım
        public ActionResult CicekSepetiDetails(mvcCicekSepetiModel cicek)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (cicek.otosay == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CicekSepeti_AktifUrunler", cicek).Result;
                    TempData["SuccessMessage"] = "Ekleme işlemi başarılı";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CicekSepeti_AktifUrunler/" + cicek.otosay, cicek).Result;
                    TempData["SuccessMessage"] = "Güncelleme işlemi başarılı";
                }
                return RedirectToAction("CicekSepetiDetails","urunler");
            }
        }

        //        public ActionResult CicekSepetiDetails(long id = 0)
        //        {
        //    if (Session["kullaniciAdi"] == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    else
        //    {
        //        if (id == 0)
        //            return View(new mvcCicekSepetiModel());
        //        else
        //        {
        //            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CicekSepeti_AktifUrunler/" + id.ToString()).Result;
        //            return View(response.Content.ReadAsAsync<mvcCicekSepetiModel>().Result);
        //        }
        //    }
        //}


    }
}