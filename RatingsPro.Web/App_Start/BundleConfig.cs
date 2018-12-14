using System.Web;
using System.Web.Optimization;

namespace RatingsPro.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery-ui-1.10.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.min.css"));
            
            //Added for JQ grid
            bundles.Add(new ScriptBundle("~/Scripts/Js/jqGridjs").Include(
                      "~/Scripts/i18n/grid.locale-en.min.js",
                      "~/Scripts/jquery.jqGrid.min.js",
                      "~/Scripts/Js/jqgrid.min.js"));

            bundles.Add(new StyleBundle("~/Content/jqgrid/css").Include(
                      "~/Content/themes/base/minified/jquery-ui.min.css",
                      "~/Content/jquery.jqGrid/ui.jqgrid.min.css"));
        }
    }
}
