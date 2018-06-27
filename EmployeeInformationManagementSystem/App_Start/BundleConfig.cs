using System.Web;
using System.Web.Optimization;

namespace EmployeeInformationManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/css").Include(
                        "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                        "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                        "~/Content/dist/css/AdminLTE.min.css",
                        "~/Content/dist/css/skins/_all-skins.min.css"
                        
                        ));

            bundles.Add(new ScriptBundle("~/js").Include(
                        "~/Content/bower_components/jquery/dist/jquery.min.js",
                        "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                        "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Content/bower_components/fastclick/lib/fastclick.js",                    
                        "~/Content/bower_components/chart.js/Chart.js",
                        "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Content/dist/js/adminlte.min.js",
                        "~/Content/dist/js/demo.js"

                        ));

            bundles.Add(new ScriptBundle("~/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/jqueryval").Include(
                       "~/Scripts/jquery.validate.min.js",
                       "~/Scripts/jquery.validate.unobtrusive.min.js"

                       ));

            bundles.Add(new ScriptBundle("~/modernizr").Include(
                        "~/Scripts/modernizr-*"

                        ));

            bundles.Add(new ScriptBundle("~/respond").Include(
                      "~/Scripts/respond.js"

                        ));

            BundleTable.EnableOptimizations = true;

        }
    }
}
