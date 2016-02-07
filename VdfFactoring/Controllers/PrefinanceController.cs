
using System.Web.Mvc;
using Pjax.Mvc5;

namespace VdfFactoring.Controllers
{
    [Pjax]
    public class PrefinanceController : BaseController,IPjax
    {
        public ActionResult PrefinanceInfo()
        {
            return View();
        }

        public ActionResult PrefinanceEntry()
        {
            return View();
        }

        public ActionResult PrefinanceCollection()
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

