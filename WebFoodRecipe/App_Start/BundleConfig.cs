using System.Web;
using System.Web.Optimization;

namespace WebFoodRecipe
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        { 
            // css all 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/style.css"
                      ));
            // css for login
            bundles.Add(new StyleBundle("~/Content/css/login").Include(
                        "~/Content/login/vendor/bootstrap/css/bootstrap.min.css",
                        "~/Content/login/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                        "~/Content/login/vendor/animate/animate.css",
                        "~/Content/login/vendor/css-hamburgers/hamburgers.min.css",
                        "~/Content/login/vendor/select2/select2.min.css",
                        "~/Content/login/css/util.css",
                        "~/Content/login/css/main.css"
                ));
            // css for admin
            bundles.Add(new StyleBundle("~/Content/css/admin").Include(
                    "~/Content/admin/assets/demo/demo.css"
                ));


            // js for all 
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                       "~/Scripts/Js/jquery/jquery-2.2.4.min.js",
                       "~/Scripts/Js/bootstrap/popper.min.js",
                       "~/Scripts/Js/bootstrap/bootstrap.min.js",
                       "~/Scripts/Js/plugins/plugins.js",
                       "~/Scripts/Js/active.js"
                   ));
            // js for login
            bundles.Add(new ScriptBundle("~/bundles/js/login").Include(
                        "~/Content/login/vendor/jquery/jquery-3.2.1.min.js",
                        "~/Content/login/vendor/bootstrap/js/popper.js",
                        "~/Content/login/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Content/login/vendor/select2/select2.min.js",
                        "~/Content/login/vendor/tilt/tilt.jquery.min.js",
                        "~/Content/login/js/main.js"
                ));
            // js for admin
            bundles.Add(new ScriptBundle("~/bundles/js/admin").Include(
                    "~/Content/admin/assets/js/core/jquery.min.js",
                    "~/Content/admin/assets/js/core/popper.min.js",
                    "~/Content/admin/assets/js/plugins/perfect-scrollbar.jquery.min.js",
                    "~/Content/admin/assets/js/plugins/moment.min.js",
                    "~/Content/admin/assets/js/plugins/sweetalert2.js",
                    "~/Content/admin/assets/js/plugins/jquery.validate.min.js",
                    "~/Content/admin/assets/js/plugins/jquery.bootstrap-wizard.js",
                    "~/Content/admin/assets/js/plugins/bootstrap-selectpicker.js",
                    "~/Content/admin/assets/js/plugins/bootstrap-datetimepicker.min.js",
                    "~/Content/admin/assets/js/plugins/jquery.dataTables.min.js",
                    "~/Content/admin/assets/js/plugins/bootstrap-tagsinput.js",
                    "~/Content/admin/assets/js/plugins/jasny-bootstrap.min.js",
                    "~/Content/admin/assets/js/plugins/fullcalendar.min.js",
                    "~/Content/admin/assets/js/plugins/jquery-jvectormap.js",
                    "~/Content/admin/assets/js/plugins/nouislider.min.js",
                    "~/Content/admin/assets/js/plugins/arrive.min.js",
                    "~/Content/admin/assets/js/plugins/chartist.min.js",
                    "~/Content/admin/assets/js/plugins/bootstrap-notify.js",
                    "~/Content/admin/assets/js/material-dashboard.js?v=2.1.2",
                    "~/Content/admin/assets/demo/demo.js"
                ) );
        }
    }
}
