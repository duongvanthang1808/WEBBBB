using System.Web;
using System.Web.Optimization;

namespace WebThoiTrang
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/script.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/home").Include("~/Content/site.css", "~/Content/style-content.css","~/Content/style_shop.css"));
            bundles.Add(new StyleBundle("~/Content/others").Include("~/Content/style-signup.css", "~/Content/style_login.css"));
        }
    }
}