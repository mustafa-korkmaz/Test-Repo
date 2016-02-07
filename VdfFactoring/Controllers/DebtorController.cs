using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Pjax.Mvc5;

namespace VdfFactoring.Controllers
{
    //  [FsisAuthentication]
    [Pjax]
    public class DebtorController : BaseController,IPjax
    {
        //   protected readonly IDebtor debtor;

        //public DebtorController(IDebtor debtor)
        //{
        //    this.debtor = debtor;
        //}
        public bool IsPjaxRequest { get; set; }

        public string PjaxVersion { get; set; }


        public ActionResult Agreement()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult Limit()
        {
            return View();
        }

        // GET: /Debtor/
        public ActionResult Debt()
        {
            return View();
        }

        #region debtor pages common methods

        #endregion debtor pages common methods



    }
}

