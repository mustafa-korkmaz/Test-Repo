
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

        public ActionResult Pjax1()
        {
            System.Threading.Thread.Sleep(1500);
            return View();
        }

        public ActionResult Pjax2()
        {
            ViewBag.Title = "Pjax2";
            return View();
        }


        #region DataGrid Sample
        public ActionResult DataGridSample()
        {
            return View();
        }

        public ActionResult ServerSideDataGrid()
        {
            DataGridTestModel model = new DataGridTestModel();
            model.SampleGrid = SetSampleDataGridModel();

            return View(model);
        }

        private DataGridModel SetSampleDataGridModel()
        {
            var pList = GetData(new DataGridRequestQueryString());
            //   var pList = GetComplexPersonViewList();
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
            queryString.orderedColumnIndex = Int32.Parse(Request.QueryString["order[0][column]"]);

            var columnNameIdentifier = string.Format("columns[{0}][data]", queryString.orderedColumnIndex);
            queryString.orderedColumnName = Request.QueryString[columnNameIdentifier];

            queryString.orderBy = Request.QueryString["order[0][dir]"];

            DataGridResponse resp = new DataGridResponse
            {
                draw = queryString.draw,
                data = GetData(queryString),
                recordsFiltered = 100,
                recordsTotal = 100,
            };

            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        private List<SimplePersonViewModel> GetData(DataGridRequestQueryString queryString)
        {
            if (queryString.length==0)
            {
                queryString.length = 1;
            }
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
            return pList.Skip(queryString.start).Take(queryString.length).ToList();
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