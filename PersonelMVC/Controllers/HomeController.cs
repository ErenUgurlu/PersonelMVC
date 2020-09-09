using PersonelMVC.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    public class HomeController : Controller
    {
        sirketEntities db = new sirketEntities();
        // GET: Home
        [Route("Home")]
        public ActionResult Index()
        {
            return View();
        }
        public int ToplamPersonel()
        {

            return db.personel.Count();
        }

    }
}