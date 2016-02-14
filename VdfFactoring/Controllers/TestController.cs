
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pjax.Mvc5;
using VdfFactoring.ViewModels;
using VdfFactoring.Models;

namespace VdfFactoring.Controllers
{
    [Pjax]
    public class TestController : BaseController, IPjax
    {

        #region DataGrid Sample
        public ActionResult ServerSideDataGrid()
        {
            DataGridTestModel model = new DataGridTestModel();
            model.SampleGrid = InitializeGrid();

            return View(model);
        }

        /// <summary>
        ///  there is no data in grid but we want to show it in page with column names and table name.
        /// </summary>
        /// <returns></returns>
        private DataGridModel InitializeGrid()
        {
            var pList = new List<SimplePersonViewModel>();
            var model = new DataGridModel(pList, "Sample dynamic data grid");
            return model;
        }

        /// <summary>
        /// xhr method that works with dataTables.js server side table
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public ActionResult FillDataGrid(DataGridRequestQueryString queryString)
        {
            DataGridResponseViewModel resp = GetResponse(queryString);

            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// assume that tihs data comes from business layer.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private DataGridResponseViewModel GetResponse(DataGridRequestQueryString queryString)
        {
            DataGridResponseViewModel model = new DataGridResponseViewModel(queryString);

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
            model.data = pList.Skip(queryString.start).Take(queryString.length).ToList();
            model.recordsTotal = pList.Count;

            return model;
        }

        #endregion DataGrid Sample


        #region pjax

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

        #endregion pjax
    }
}