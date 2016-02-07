using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Common.UIElements;
using Common.Helpers;

namespace VdfFactoring.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.Breadcrumbs = GetPageBreadcrumbs();
            //  var user = SessionHelper.GetValue<PCWebUser>(Session.CurrentUser);
       //     ViewBag.UserLayoutCredentials = SessionHelper.GetValue<PCUserLayoutCredentials>(StaticVariables.Session.CURRENT_USER_LAYOUT_CREDENTIALS);
        }

        // GET: /Base/
  //      [FsisAuthentication]
        public ActionResult index()
        {
            return View();
        }

        /// <summary>
        /// gets the list for breadcrumbs section
        /// </summary>
        /// <returns></returns>
        private List<Breadcrumb> GetPageBreadcrumbs()
        {
            bool isBcListInSession = false;
            List<Breadcrumb> bcList;
            Breadcrumb bc = new Breadcrumb();

            if (SessionHelper.GetValue<List<Breadcrumb>>(StaticVariables.Session.BREADCRUMBS) == null)
                bcList = StaticVariables.Breadcrumbs;
            else
            {
                bcList = SessionHelper.GetValue<List<Breadcrumb>>(StaticVariables.Session.BREADCRUMBS);
                isBcListInSession = true;
            }

            string action = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action").ToLower().Replace('ı', 'i');
            string controller = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller").ToLower();

            if (!isBcListInSession)
                SessionHelper.SetValue(StaticVariables.Session.BREADCRUMBS, bcList); // breadcrumb listesini session a kaydet

            List<Breadcrumb> currentBcList = new List<Breadcrumb>();

            var breadcrumb = bcList.Where(p => p.ActionName == action && p.ControllerName == controller).FirstOrDefault();
            if (breadcrumb == null)
                return null; // bu statik bir sayfa breadcrumb içermiyor

            currentBcList.Add(breadcrumb);

            var currentBreadcrumb = breadcrumb;
            while (currentBreadcrumb.ParentId >= 0 && currentBreadcrumb.Id > 0)
            {
                var parent = StaticVariables.Breadcrumbs.Single(p => p.Id == currentBreadcrumb.ParentId);
                currentBcList.Add(parent);
                currentBreadcrumb = parent;
            }

            return currentBcList.OrderBy(p => p.ParentId).ThenBy(t => t.Id).ToList();
        }
        /*
        [HttpPost]
        [FsisAuthentication]
        [ValidateAntiForgeryToken]
        public ActionResult ExportToExcel(DataExportModel model)
        {
            BLDocument blDocument = new BLDocument();
            var document = blDocument.GetCSVDocument(model.ExportType);
            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.csv
                FileName = document.FileName,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = document.IsInline,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(document.Data, document.ContentType);
        }

        /// <summary>
        /// son açılan pop up daki  data table i session a atar. excel export esnasında bu nesneyi session dan cekmek için kullanacagız | Sets a session variable for the latest dataTable object. We will use it in excel export actions
        /// </summary>
        /// <param name="dtModel"></param>
        protected void SetCurrentPopUpTableModelToExport(DataTableModel dtModel)
        {
            PCCurrentPopUpTableModelToExport pcModel = new PCCurrentPopUpTableModelToExport();
            pcModel.HiddenColumnsList = dtModel.HiddenColumnsList;
            pcModel.ModelTable = dtModel.DataTable;
            pcModel.ShowHiddenColumnsInFiles = dtModel.ShowHiddenColumnsInFiles;
            pcModel.ColumnList = dtModel.ColumnList;
            SessionHelper.SetValue(StaticVariables.Session.CURRENT_POPUP_TABLE_MODEL_TO_EXPORT, pcModel);
            dtModel.DataExportModel = new DataExportModel { ExportType = DataExportType.FromPopUp };
        }

        /// <summary>
        /// son açılan pop up daki  data table i session a atar. excel export esnasında bu nesneyi session dan cekmek için kullanacagız | Sets a session variable for the latest dataTable object. We will use it in excel export actions
        /// </summary>
        /// <param name="dtModel"></param>
        protected void SetCurrentPageTableModelToExport(DataTableModel dtModel)
        {
            PCCurrentPageTableModelToExport pcModel = new PCCurrentPageTableModelToExport();
            pcModel.HiddenColumnsList = dtModel.HiddenColumnsList;
            pcModel.ModelTable = dtModel.DataTable;
            pcModel.ShowHiddenColumnsInFiles = dtModel.ShowHiddenColumnsInFiles;
            pcModel.ColumnList = dtModel.ColumnList;
            SessionHelper.SetValue(StaticVariables.Session.CURRENT_PAGE_TABLE_MODEL_TO_EXPORT, pcModel);
            dtModel.DataExportModel = new DataExportModel { ExportType = DataExportType.FromPage };
        }
        */
 
        #region ERROR_HANDLING
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            //    return;
            //}

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                //filterContext.Result = new JsonResult() 
                //{
                //    Data = filterContext.Exception.Message+"ei,şrşlsiolslrsşlrseşrleislr",
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};
                filterContext.Result = Json(new { type = StaticVariables.UserMessageType.SERVER_ERROR, messageArray = filterContext.Exception.Message }, JsonRequestBehavior.AllowGet);
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);

            }

            // Write error logging code here if you wish.
           // ExceptionHandler.Publish(filterContext.Exception);
            //if want to get different of the request
            //var currentController = (string)filterContext.RouteData.Values["controller"];
            //var currentActionName = (string)filterContext.RouteData.Values["action"];
        }
        #endregion ERROR_HANDLING

        #region client-side user messages
        /// <summary>
        /// returns a server side message to client with Json format
        /// </summary>
        /// <param name="code"></param>
        /// <param name="messageList"></param>
        /// <returns></returns>
        protected JsonResult GetUserMessageFromResponse(ResponseCode code, IEnumerable<string> messageList)
        {
            //Json(new {type=UserMessageType.ErrorMessage,message=filterContext.Exception.Message},JsonRequestBehavior.AllowGet);
            var type = StaticVariables.UserMessageType.NONE;
            switch (code)
            {
                case ResponseCode.Fail:
                    type = StaticVariables.UserMessageType.ERROR;
                    break;
                case ResponseCode.Success:
                    type = StaticVariables.UserMessageType.SUCCESS;
                    break;
                case ResponseCode.Warning:
                    type = StaticVariables.UserMessageType.WARNING;
                    break;
                case ResponseCode.Info:
                    type = StaticVariables.UserMessageType.INFO;
                    break;
                default:
                    break;
            }
            return Json(new { type = type, messageArray = Newtonsoft.Json.JsonConvert.SerializeObject(messageList) }, JsonRequestBehavior.AllowGet);
        }
        #endregion client-side user messages

        #region Model State Validation Controls
        protected IEnumerable<string> GetModelStateErrors()
        {
            var modelStateErrorList = this.ModelState.Values.SelectMany(p => p.Errors).Select(t => t.ErrorMessage);
            return modelStateErrorList;
        }
        #endregion Model State Validation Controls
    }
}
