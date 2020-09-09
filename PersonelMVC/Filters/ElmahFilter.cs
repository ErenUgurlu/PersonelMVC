using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;

namespace PersonelMVC.Filters
{
    public class ElmahFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
        }
    }
}