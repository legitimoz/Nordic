using System.Web.Mvc;
using System.Web.Routing;

namespace PRESENTACION
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           routes.MapRoute(
           name: "Viaticos",
           url: "Index/Programas/viaticos",
           defaults: new { controller = "Viaticos", action = "GerenteLinea" }
       );
          
            routes.MapRoute(
          name: "SOP",
          url: "Index/Programas/sop",
          defaults: new { controller = "SOP", action = "Index" }
      );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
            );


           
        }
    }
}
