using System.Web;
using System.Web.Optimization;

namespace Web.HealthFoot
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //Pantilla de administardor
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                      "~/Content/Admin/bootstrap.min.css",
                      "~/Content/Admin/metismenu.min.css",
                      "~/Content/Admin/style.css"));

            bundles.Add(new StyleBundle("~/Content/styleadmin").Include(
                      "~/Content/Admin/style.css"));

            bundles.Add(new StyleBundle("~/Content/font").Include(
                "~/Content/Admin/icons.css"
                , new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/cssdatatable").Include(
                "~/Content/Admin/datatables/dataTables.bootstrap4.min.css",
                "~/Content/Admin/datatables/dataTables.responsive.bootstrap4.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                     "~/Scripts/Admin/jquery.slimscroll.js"));


            bundles.Add(new ScriptBundle("~/bundles/adminbootstrap").Include(
                      "~/Scripts/Admin/bootstrap.bundle.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/metismenu").Include(
                      "~/Scripts/Admin/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/waves").Include(
                      "~/Scripts/Admin/waves.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsdatatable").Include(
                      "~/Content/Admin/datatables/jquery.dataTables.min.js",
                      "~/Content/Admin/datatables/dataTables.bootstrap4.min.js",
                      "~/Content/Admin/datatables/dataTables.responsive.min.js",
                      "~/Content/Admin/datatables/responsive.bootstrap4.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/Admin/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/init").Include(
                      "~/Scripts/init.js"));
            /*Fin de plantilla para administrador*/

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                      "~/Scripts/bootbox.js"));

            /**
             * Estilos para la principal de ecommerce
             * */

            bundles.Add(new StyleBundle("~/Content/webcss").Include(
                      "~/Content/Web/plugins/jquery-ui/jquery-ui.css",
                      "~/Content/Web/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/Web/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/Web/plugins/selectbox/select_option1.css",
                      "~/Content/Web/plugins/fancybox/jquery.fancybox.min.css",
                      "~/Content/Web/plugins/iziToast/css/iziToast.css",
                      "~/Content/Web/plugins/prismjs/prism.css",
                      "~/Content/Web/plugins/rs-plugin/css/settings.css",
                      "~/Content/Web/plugins/slick/slick.css",
                      "~/Content/Web/plugins/slick/slick-theme.css",
                      "~/Content/Web/css/style.css",
                      "~/Content/Web/css/default.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/webjs").Include(
                      "~/Content/Web/plugins/jquery/jquery-migrate-3.0.0.min.js",
                      "~/Content/Web/plugins/jquery-ui/jquery-ui.js",
                      "~/Content/Web/plugins/bootstrap/js/popper.min.js",
                      "~/Content/Web/plugins/bootstrap/js/bootstrap.min.js",
                      "~/Content/Web/plugins/rs-plugin/js/jquery.themepunch.tools.min.js",
                      "~/Content/Web/plugins/rs-plugin/js/jquery.themepunch.revolution.min.js",
                      "~/Content/Web/plugins/slick/slick.js",
                      "~/Content/Web/plugins/fancybox/jquery.fancybox.min.js",
                      "~/Content/Web/plugins/iziToast/js/iziToast.js",
                      "~/Content/Web/plugins/prismjs/prism.js",
                      "~/Content/Web/plugins/selectbox/jquery.selectbox-0.1.3.min.js",
                      "~/Content/Web/plugins/countdown/jquery.syotimer.js",
                      "~/Content/Web/plugins/velocity/velocity.min.js",
                      "~/Content/Web/js/custom.js",
                      "~/Content/Web/js/rocket-loader.min.js"
                      ));
        }
    }
}
