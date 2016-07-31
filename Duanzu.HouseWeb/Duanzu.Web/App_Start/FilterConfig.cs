using System.Web;
using System.Web.Mvc;
using Duanzu.Web.ConfigClass.Attribute;

namespace Duanzu.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new GlobalErrorFiter());
        }
    }
}