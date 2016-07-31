using System.Web.Mvc;

namespace Duanzu.FK
{
    public class DuanzuFKAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DuanzuFK";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DuanzuFK_default",
                "DuanzuFK/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Duanzu.FK.Controller.Controllers" }
            );
        }
    }
}
