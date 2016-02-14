using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
            var resp = new DataGridResponseViewModel(queryString)
            {
                //     data = new CustomerDataGenerator().GenerateCustomerList(queryString),
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
                    Salary = i + 10.5,
                    Name = "My name is " + (i + 1),
                    Gender = "E",
                    Id = i,
                    BirthDate = DateTime.Now.AddDays(-1000 + i).ToShortDateString(),
                    ModifiedDate = DateTime.Now.AddDays(-2000 + i).ToShortDateString(),
                };

                pList.Add(p);
            }
            return pList;
        }


    }
}