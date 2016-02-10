using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pjax.Mvc5;

namespace VdfFactoring.Controllers
{
    [Pjax]
    public class TestController : BaseController, IPjax
    {

        public ActionResult Pjax1()
        {
            System.Threading.Thread.Sleep(1500);
            return View();
        }

        public ActionResult Pjax2()
        {
            return View();
        }

        public bool IsPjaxRequest
        {
            get;
            set;
        }

        public string PjaxVersion
        {
            get;
            set;
        }
    }
}