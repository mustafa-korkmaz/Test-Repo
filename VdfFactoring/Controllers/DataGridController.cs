using System;
using System.Web.Mvc;
using VdfFactoring.Models;
using VdfFactoring.ViewModels;

namespace VdfFactoring.Controllers
{
    public class DataGridController : Controller
    {
        /// <summary>
        /// xhr method that works with dataTables.js server side table
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public ActionResult FillDataGrid(DataGridRequestQueryString queryString)
        {
            queryString.orderedColumnIndex = Int32.Parse(Request.QueryString["order[0][column]"]);

            var columnNameIdentifier = string.Format("columns[{0}][data]", queryString.orderedColumnIndex);
            queryString.orderedColumnName = Request.QueryString[columnNameIdentifier];
        
            queryString.orderBy = Request.QueryString["order[0][dir]"];

            DataGridResponse resp = new DataGridResponse
            {
                draw = queryString.draw,
                data = new CustomerDataGenerator().GenerateCustomerList(queryString),
                recordsFiltered = 505,
                recordsTotal = 505
            };

            return Json(resp, JsonRequestBehavior.AllowGet);
        }

    }
}