using PersonelMVC.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PersonelMVC.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        sirketEntities db = new sirketEntities();
        
        [Route("Departman")]
        
        public ActionResult DepartmanList()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        
        [HttpGet]
        [Authorize(Roles = "adm")]
        public ActionResult YeniD()         //bu action result ın amacı departmanEkle görünümünü ekrana göstermek
        {
            return View("Departmanform",new Departman());
        }

        
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "adm")]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
                return View("DepartmanForm");
            if (departman.ID == 0)
                db.Departman.Add(departman);

            else
            {
                var güncellenecekDepartman = db.Departman.Find(departman.ID);
                if (güncellenecekDepartman == null)
                    return HttpNotFound();
                else
                    güncellenecekDepartman.DepartmanIsmi = departman.DepartmanIsmi;
            }
            
            db.SaveChanges();
            return RedirectToAction("DepartmanList", "Departman");
        }
        [Authorize(Roles = "adm")]
        public ActionResult Güncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm",model);
        }
        [Authorize(Roles = "adm")]
        public ActionResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);
            if (silinecekDepartman == null)
                return HttpNotFound();
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return RedirectToAction("","Departman");
        }

    }
    
}