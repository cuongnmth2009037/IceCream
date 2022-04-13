using System.Web;
using System.Web.Optimization;

namespace IceCream
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                          "~/Scripts/bootstrap.bundle.min.js",
                          "~/Scripts/easing/easing.min.js",
                          "~/Scripts/waypoints/waypoints.min.js",
                          "~/Scripts/owlcarousel/owl.carousel.min.js",
                          "~/Scripts/isotope/isotope.pkgd.min.js",
                          "~/Scripts/lightbox/js/lightbox.min.js",
                          "~/Scripts/main.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/all.min.css",
                      "~/Content/owlcarousel/assets/owl.carousel.min.css",
                      "~/Content/lightbox/css/lightbox.min.css",
                      "~/Content/style.css"
                      ));
        }
    }
}
