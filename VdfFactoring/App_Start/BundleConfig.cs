using System.Web;
using System.Web.Optimization;

namespace VdfFactoring
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region factoring main layout css

            bundles.Add(new StyleBundle("~/Content/metronicCss").Include(
                       "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",  //BEGIN GLOBAL MANDATORY STYLES 
                       "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                       "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                       "~/Content/assets/global/plugins/uniform/css/uniform.default.css",
                       "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css", //END GLOBAL MANDATORY STYLES
                       "~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css", //BEGIN PAGE LEVEL PLUGINS
                       "~/Content/assets/global/plugins/fullcalendar/fullcalendar.min.css",
                       "~/Content/assets/global/plugins/datatables/datatables.min.css",
                      "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css",//END PAGE LEVEL PLUGINS
                      "~/Content/assets/global/css/components-rounded.min.css",   // BEGIN THEME GLOBAL STYLES
                      "~/Content/assets/global/css/plugins.min.css",  // END THEME GLOBAL STYLES
                       "~/Content/assets/layouts/layout/css/layout.min.css", // BEGIN THEME LAYOUT STYLES
                       "~/Content/assets/layouts/layout/css/themes/light2.min.css",
                       "~/Content/assets/layouts/layout/css/custom.min.css" //END THEME LAYOUT STYLES                 
            ));
            //Content\assets\global\plugins\datatables
            #endregion factoring main layout css

            #region factoring main layout js

            bundles.Add(new ScriptBundle("~/bundles/metronicJs").Include(
                       "~/Content/assets/global/plugins/jquery.min.js", //BEGIN CORE PLUGINS
                       "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                       "~/Content/assets/global/plugins/js.cookie.min.js",
                       "~/Content/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                       "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                       "~/Content/assets/global/plugins/jquery.blockui.min.js",
                       "~/Content/assets/global/plugins/uniform/jquery.uniform.min.js",
                       "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js", //END CORE PLUGINS
                       "~/Content/assets/global/plugins/jquery.sparkline.min.js", // PAGE LEVEL PLUGINS
                       "~/Content/assets/global/plugins/jquery-history/jquery.history.js",
                        "~/Content/assets/global/plugins/jquery-pjax/jquery.pjax.js",
                       "~/Scripts/common/global.js",//BEGIN  FACTORING GLOBAL SCRIPTS             
                       "~/Scripts/common/ajaxHelper.js",
                       "~/Scripts/common/contentLoader.js",
                       "~/Scripts/common/userMessage.js",
                       "~/Scripts/common/layout.js",
                       "~/Scripts/common/pjaxHandler.js",
                //"~/Scripts/form/validator.js",
                //"~/Scripts/form/ajaxForm.js",  //END  FACTORING GLOBAL SCRIPTS           
                       "~/Content/assets/global/scripts/app.min.js", // THEME GLOBAL SCRIPTS
                       "~/Content/assets/layouts/layout/scripts/layout.min.js", //BEGIN THEME LAYOUT SCRIPTS
                       "~/Content/assets/layouts/layout/scripts/demo.min.js",
                       "~/Content/assets/layouts/global/scripts/quick-sidebar.min.js",
                       "~/Content/assets/global/plugins/datatables/datatables.min.js",
                       "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"//END THEME LAYOUT SCRIPTS
                       ));

            bundles.Add(new ScriptBundle("~/bundles/metronicJsForIE").Include(
                     "~/Content/assets/global/plugins/respond.min.js",
                     "~/Content/assets/global/plugins/excanvas.min.js"
                     ));

            #endregion factoring main layout js
        }
    }
}
