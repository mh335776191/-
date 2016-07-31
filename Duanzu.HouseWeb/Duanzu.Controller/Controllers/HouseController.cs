using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Duanzu.Controller.Controllers
{
    public class HouseController : System.Web.Mvc.Controller
    {
        /// <summary>
        /// 短租详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult HouseDetail(string id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
