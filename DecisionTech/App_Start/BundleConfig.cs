using System.Web;
using System.Web.Optimization;

namespace DecisionTech
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                 "~/Scripts/jquery-{version}.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/respond.js",
                       "~/Scripts/angular.js",
                       "~/Scripts/app/home/dealCtrl.js",
                       "~/Scripts/app/home/dealService.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(
                      "~/Content/animations.css",
                      "~/Content/home.css"));
        }
    }
}
