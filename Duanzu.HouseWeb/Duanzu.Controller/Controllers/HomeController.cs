using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Duanzu.House.Contract.HouseInterface;
using Duanzu.House.DataContract;
using Duanzu.House.DataContract.HouseModel.BusinessModel;
using Duanzu.TXCommons.BasicsClass;
using Duanzu.TXCommons.InvokiServices;

namespace Duanzu.Controller.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            Duanzu.House.DataContract.HouseModel.DBModel.UserComment comment = new House.DataContract.HouseModel.DBModel.UserComment();
            var client = Duanzu.TXCommons.InvokiServices.HouseServiceInvoker<IHouseServicersContract>.GetClient();
            comment.AuditType = 1;
            comment.Comment = "121233333";
            comment.HouseID = 99;
            comment.HouseScore = 2;
            comment.IsDel = 0;
            comment.Remark = "测试";
            comment.RenterScore = 1;
            comment.SafetyScore = 3;
            comment.UserId = 123;
            var result = client.AddUserComment(comment);

            SeoModel seo = new SeoModel();
            seo.Title = "测试title";
            ViewBag.seo = seo;

            return View();
        }
    }
}
