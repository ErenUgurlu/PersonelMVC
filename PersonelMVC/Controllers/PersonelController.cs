using PersonelMVC.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMVC.View_Models;


namespace PersonelMVC.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        sirketEntities db = new sirketEntities();
        // GET: Personel
        [Route("Personel")]
        
        public ActionResult PersonelList()
        {
            var model = db.personel.Include(x=>x.Departman).ToList();
            return View(model);
        }
        [Authorize(Roles = "adm")]
        public ActionResult YeniP()
        {
            var model = new PersonelFromViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new personel()
            };
            
            return View("PersonelForm",model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "adm")]
        public ActionResult Kaydet(personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFromViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return View("PersonelForm",model);
            }
                
            if(personel.p_no == 0)
            {
                db.personel.Add(personel);
            }
            else
            {

                if (personel == null)
                    return HttpNotFound();
                else
                    db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
                        

            }
            db.SaveChanges();
            return RedirectToAction("PersonelList");
        }
        [Authorize(Roles = "adm")]
        public ActionResult Güncelle(int id)
        {
            var model = new PersonelFromViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.personel.Find(id)
            };
            
            if (model == null)
                return HttpNotFound();
            return View("PersonelForm", model);
        }
        [Authorize(Roles = "adm")]
        public ActionResult Sil(int id)
        {
            var silinecekP = db.personel.Find(id);
            if (silinecekP == null)
                HttpNotFound();
            db.personel.Remove(silinecekP);
            db.SaveChanges();
            return RedirectToAction("PersonelList");
        }
        public ActionResult PersonelListele(int id)
        {
            var model = db.personel.Where(x => x.Departman.ID == id).ToList();
            return PartialView(model);
        }
        
        
    }
}