
using System;
using System.Collections.Generic;
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

        public ActionResult DataGridSample()
        {
            return View();
        }

        public ActionResult PartialDataGrid()
        {
            DataGridTestModel model = new DataGridTestModel();
            model.SampleGrid = SetSampleDataGridModel();

            return View(model);
        }

        private DataGridModel SetSampleDataGridModel()
        {
            var pList = GetSimplePersonViewList();
            //   var pList = GetComplexPersonViewList();
            var model = new DataGridModel(pList, "Sample dynamic data grid");

            return model;
        }

        private List<SimplePersonViewModel> GetSimplePersonViewList()
        {
            List<SimplePersonViewModel> pList = new List<SimplePersonViewModel>();

            SimplePersonViewModel p = new SimplePersonViewModel();

            for (int i = 0; i < 100; i++)
            {
                p = new SimplePersonViewModel()
                {
                    BirthDate = DateTime.Now.AddDays(-1000 + i),
                    ModifiedDate = DateTime.Now.AddDays(-2000 + i),
                    Salary = i + 10.5,
                    Gender = "E",
                    Id = i,
                    Name = "My name is " + (i + 1)
                };

                pList.Add(p);
            }
            return pList;
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