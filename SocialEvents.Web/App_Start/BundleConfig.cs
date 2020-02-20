using System.Web.Optimization;

namespace SocialEvents.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.4.1.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/dataTable/moment-with-locales.js",
                "~/Scripts/dataTable/jquery.dataTables.min.js",
                // "~/Scripts/dataTable/dataTables.bootstrap.min.js",
                "~/Theme/js/dataTables.bootstrap4.min.js",
                "~/Theme/js/scripts.js",
                "~/Scripts/dataTable/datetime-moment.js",
                "~/Scripts/dataTable/dataTables.rowGroup.min.js",
                "~/Scripts/dataTable/dataTables.buttons.min.js",
                "~/Scripts/dataTable/dataTables.select.min.js",
                "~/Scripts/dataTable/buttons.flash.min.js",
                "~/Scripts/dataTable/jszip.min.js",
                "~/Scripts/dataTable/pdfmake.min.js",
                "~/Scripts/dataTable/vfs_fonts.js",
                "~/Scripts/dataTable/buttons.html5.min.js",
                "~/Scripts/dataTable/buttons.print.min.js",
                "~/Scripts/dataTable/buttons.colVis.min.js",
                "~/Scripts/Chart.js",
                "~/Scripts/select2.js"));


            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                //   "~/js/bootstrap.js",
                "~/Theme/js/bootstrap.bundle.min.js",
                "~/Theme/js/font-awesome/all.min.js",
                "~/Scripts/select2.js",
                //"~/Theme/assets/demo/chart-area-demo.js",
               // "~/Theme/assets/demo/chart-bar-demo.js",
                //"~/Theme/assets/demo/chart-pie-demo.js",
               // "~/Theme/assets/demo/datatables-demo.js",
                "~/js/site.js"));
            //------------color pickup-----------
            //bundles.Add(new ScriptBundle("~/spectrum/js").Include("~/Scripts/spectrum.js"));


            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                //"~/css/bootstrap.css",
                //"~/Content/dataTable/dataTables.bootstrap.min.css",
                "~/Theme/css/dataTables.bootstrap4.min.css",
                "~/Content/dataTable/responsive.bootstrap.min.css",
                "~/Content/dataTable/buttons.dataTables.min.css",
                "~/Content/dataTable/select.dataTables.min.css",
                "~/Content/dataTable/rowGroup.dataTables.min.css",
                "~/Content/css/select2.css",
                "~/Content/Chart.css",
                "~/Theme/css/styles.css",
                "~/css/site.css"));


            //------------color pickup-----------
            //bundles.Add(new StyleBundle("~/spectrum/css").Include("~/Content/spectrum.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}