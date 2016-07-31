using System.Web.Mvc;

namespace Duanzu.FD
{
    public class DuanzuFDAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "DuanzuFD"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DuanzuFD_default",
                "DuanzuFD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Duanzu.FD.Controller.Controllers" }
            );
        }
    }
}
