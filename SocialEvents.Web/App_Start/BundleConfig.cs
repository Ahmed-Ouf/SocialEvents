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
                "~/Scripts/jquery.unobtrusive-ajax.js"));

         
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include("~/js/bootstrap.js", "~/js/site.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include("~/css/bootstrap.css", "~/css/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}