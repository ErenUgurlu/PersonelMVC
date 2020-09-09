using PersonelMVC.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelMVC.View_Models
{
    public class PersonelFromViewModel
    {
        public IEnumerable<Departman> Departmanlar { get; set; }
        public personel Personel { get; set; }
    }
}