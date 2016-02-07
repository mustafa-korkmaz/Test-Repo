using Pjax.Mvc5;
using System.Web.Mvc;


namespace VdfFactoring.Controllers
{
    [Pjax]
    public class TradeVehicleController : BaseController, IPjax
    {
        public bool IsPjaxRequest { get; set; }

        public string PjaxVersion { get; set; }

        public ActionResult TradeVehicleList()
        {
            return View();
        }

        public ActionResult PledgedVehicleList()
        {
            return View();
        }

    }
}

