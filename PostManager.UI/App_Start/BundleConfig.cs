using System.Web;
using System.Web.Optimization;

namespace UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new Bundle("~/bundles/clientapp").Include(
                "~/Content/runtime.*",
                "~/Content/polyfills.*",
                "~/Content/main.*"));

            bundles.Add(new StyleBundle("~/Content/clientapp").Include(
                "~/Content/styles.*"));

            //Enable bundling
            BundleTable.EnableOptimizations = true;
        }
    }
}
