using System.Web;
using System.Web.Optimization;

namespace MvcDemo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include("~/Content/jquery.js",
                                                                      "~/Content/myscript.js", "~/Content/bootstrap/js/bootstrap.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap/css/bootstrap.min.css", "~/Content/bootstrap/css/bootstrap-theme.min.css"));
        }
    }
}