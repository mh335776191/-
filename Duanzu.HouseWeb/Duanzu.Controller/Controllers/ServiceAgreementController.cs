using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Duanzu.TXCommons.BasicsClass;

namespace Duanzu.Controller.Controllers
{
    public class ServiceAgreementController : System.Web.Mvc.Controller
    {
        /// <summary>
        /// 发布短租服务协议
        /// </summary>
        /// <returns></returns>
        public ActionResult ShortRentRule()
        {
            return View();
        }
    }
}
