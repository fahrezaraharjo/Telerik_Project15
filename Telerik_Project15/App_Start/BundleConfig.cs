using System.Web;
using System.Web.Optimization;

namespace Telerik_Project15
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Example BundleConfig.cs
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/kendo/kendo.common-bootstrap.min.css", // Kendo UI CSS
                "~/Content/kendo/kendo.bootstrap.min.css" // Kendo UI CSS
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/kendo/kendo.all.min.js" // Kendo UI JavaScript
            ));
        }
    }
}
