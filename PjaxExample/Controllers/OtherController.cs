
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pjax.Mvc5;

namespace VdfFactoring.Controllers
{
    [Pjax]
    public class OtherController : BaseController, IPjax
    {

        public bool IsPjaxRequest { get; set; }

        public string PjaxVersion { get; set; }

        // GET: /Other/
        //    [FsisAuthentication]
        public ActionResult Stocks()
        {
            return View();
        }

        // [FsisAuthentication]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //     [FsisAuthentication]
        public ActionResult VDFAutoFinance()
        {
            //ViewBag.Id = "vdfAutoFinance";

            return View();
        }

    }
}
