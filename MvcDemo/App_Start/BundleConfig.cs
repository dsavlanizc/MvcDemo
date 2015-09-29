using System.Web;
using System.Web.Optimization;

namespace MvcDemo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Scripts").Include("~/Content/jquery.js",
                                                                      "~/Content/myscript.js"));
        }
    }
}