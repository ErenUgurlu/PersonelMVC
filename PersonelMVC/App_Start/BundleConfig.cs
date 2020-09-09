using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PersonelMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                    "~/Scripts/jquery-3.0.0.js" ,
                    "~/Scripts/bootstrap.js" ,
                    "~/Scripts/DataTables/jquery.dataTables.js" ,
                    "~/Scripts/jquery.unobtrusive-ajax.min.js" ,
                    "~/Scripts/DataTables/dataTables.bootstrap4.min.js" ,
                    "~/Scripts/custom.js" ,
                    "~/Scripts/bootbox.min.js" 
                ));
            bundles.Add(new StyleBundle("~/bundles/css").Include(

                "~/Content/bootstrap.css",
                "~/Content/DataTables/css/dataTables.bootstrap4.min.css"

                ));
        }
    }
}