using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VdfFactoring.ViewModels;
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
                //data = new CustomerDataGenerator().GenerateCustomerList(queryString),
                recordsFiltered = 100,
                recordsTotal = 100,
                data = GetSimplePersonViewList()
            };

            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        private List<SimplePersonViewModel> GetSimplePersonViewList()
        {
            List<SimplePersonViewModel> pList = new List<SimplePersonViewModel>();

            SimplePersonViewModel p = new SimplePersonViewModel();

            for (int i = 0; i < 100; i++)
            {
                p = new SimplePersonViewModel()
                {
                    BirthDate = DateTime.Now.AddDays(-1000 + i).ToShortDateString(),
                    ModifiedDate = DateTime.Now.AddDays(-2000 + i).ToShortDateString(),
                    Salary = i + 10.5,
                    Gender = "E",
                    Id = i,
                    Name = "My name is " + (i + 1)
                };

                pList.Add(p);
            }
            return pList;
        }


    }
}