using PersonelMVC.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    public class SecurityController : Controller
    {
        sirketEntities db = new sirketEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici)
        {
            
            var kullaniciKontrol = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre);
            if (kullaniciKontrol != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciKontrol.KullaniciAdi, false);
                return RedirectToAction("Index","Home");
            }
                
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";

                return View();
            }
                
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}