using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duanzu.House.DataContract.HouseModel.BusinessModel;
using Duanzu.User.DataContract.UserModel;

namespace Duanzu.FK.Controller.Controllers
{
    public class TenantController :  Duanzu.Controller.Controllers.BaseController
    {
        /// <summary>
        /// 默认未登录返回登录页
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsLogin)
            {
                //请登录 
                // filterContext.Result = new RedirectResult(TXCommons.BasicsClass.PubConstant.KyjBaseUrl + "register/newlogin?url=" + TXCommons.BasicsClass.ForKuaiYouJiaCookie.BaseRC4.RC4Encrypt(TXCommons.BasicsClass.PubConstant.DuanzuBaseUrl + "DuanzuFD/LandLord/MyDuanzuHouseList"));
                ContentResult js = new ContentResult();
                js.Content = "<script type=\"text/javascript\">alert('你还未登录！');window.location.href='" + Duanzu.TXCommons.BasicsClass.PubConstant.KyjBaseUrl + "register/newlogin'</script>";
                filterContext.Result = js;
                base.OnActionExecuting(filterContext);
            }
        }

        #region 房客-我的现金租房券
        /// <summary>
        /// 我的现金租房券
        /// </summary>
        /// <returns></returns>
        public ActionResult MyCouponList()
        {
            //当前登录用户
            int uid = GetUserId;

            MyCouponInfo couponModel=null;

            ViewBag.couponModel = couponModel;
            return View();
        }

        /// <summary>
        ///  租房券使用详情页
        /// </summary>
        /// <param name="id">租房券id</param>
        /// <returns></returns>
        public ActionResult ShowCouponUsedInfo(int id)
        {
            MyCouponInfo couponModel = new MyCouponInfo();

            ViewBag.couponModel = couponModel;
            return View();
        }
        #endregion

        #region 房客-我收藏的房源
        /// <summary>
        /// 我收藏的房源
        /// </summary>
        /// <returns></returns>
        public ActionResult MyCollectHouseList()
        {
            List<FavoriteHouseInfo> list = new List<FavoriteHouseInfo>();
            FavoriteHouseInfo model = new FavoriteHouseInfo();

            model.HouseID = 1;
            model.HousePhoto = "";
            model.Balcony = 1;
            model.Hall = 1;
            model.HouseType = 1;
            model.RentPrice = 300;
            model.Room = 1;
            model.Status = 1;
            model.Title = "sdfsdf";
            model.Toilet = 1;
            model.UserID = 405;
            model.PeopleNumber = 3;
            model.CreateTime = DateTime.Now;
            model.CityID = 253;
            model.Balcony = 1;
            model.RentType = 1;
            model.CollectTime = DateTime.Now;

            list.Add(model);

            ViewBag.CollectHouselist = list;
            return View();
        }
        #endregion

        #region 房客-我的投诉
        /// <summary>
        /// 房客-我的投诉
        /// </summary>
        /// <returns></returns>
        public ActionResult MyComplaintList()
        {
            List<HouseComplaintInfo> List = new List<HouseComplaintInfo>();
            HouseComplaintInfo Model = new HouseComplaintInfo();

            Model.Id = 11;
            Model.HouseId = 111;
            Model.Day = 1;
            Model.TotalDay = 1;
            Model.Amount = Model.Amount*Model.Day;
            Model.Desc = "ddd";
            Model.CreateTime = DateTime.Now;
            Model.State = 0;

            List.Add(Model);

            ViewBag.HouseComplaint = List;
            return View();
        }

        /// <summary>
        ///   房客-我的投诉-查看投诉明细
        /// </summary>
        /// <param name="Id">投诉id</param>
        /// <returns></returns>
        public ActionResult ShowComplaintInfo(int Id)
        {
            HouseComplaintInfo model = new HouseComplaintInfo();

            model.Amount = 300;
            model.Day = 1;
            model.TotalDay = 3;
            model.HouseId = 111;
            model.Amount = 100;
            model.Desc = "ddd";
            model.Id = 222;

            ViewBag.ComplaintInfo = model;

            return View();
        }

        /// <summary>
        /// 房客-我的投诉-修改房费展示页
        /// </summary>
        /// <param name="Id">投诉id</param>
        /// <returns></returns>
        public ActionResult EditComplaintInfo(int Id)
        {
            HouseComplaintInfo model = new HouseComplaintInfo();

            model.Amount = 300;
            model.Day = 2;
            model.TotalDay = 3;
            model.HouseId = 111;
            model.Amount = 100;
            model.Desc = "ddd";
            model.Id = 222;

            ViewBag.ComplaintInfo = model;

            return View();
        }
        #endregion

        #region 房客-旅程记录
        /// <summary>
        /// 房客-旅程记录
        /// </summary>
        /// <returns></returns>
        public ActionResult MyJourneyList()
        {
            int uid = GetUserId;
            //每页10条
            int pageIndex = 1, pageSize = 10;
            int.TryParse(Request.QueryString["pn"], out pageIndex);
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            //总记录数，总页数
            int totalCount = 0;
            int TotalPage = 0;

            //订单状态筛选
            int orderState = -1;

            if (!string.IsNullOrEmpty(Request["orderState"])) {
                orderState = Convert.ToInt32(Request["orderState"].ToString());
            }

            //获取列表数据
            List<JourneyLogInfo> List = new List<JourneyLogInfo>();
            JourneyLogInfo Model = new JourneyLogInfo();
            Model.Id = 1;
            Model.HouseID = 11;
            Model.UserID = 1;
            Model.OrderNum = "11";
            Model.CreateTime = DateTime.Now;
            Model.UpdateTime = DateTime.Now;
            Model.RentStartDate = DateTime.Now;
            Model.RentEndDate = DateTime.Now.AddDays(3);
            Model.CheckOutTime = DateTime.Now;
            Model.PeopleNumber = 3;
            Model.LandlordMobile = "18612595027";
            Model.Amount = 100;
            Model.OrderStatus = 2;
            Model.OrderStatusName = GetOrderStateName(Model.OrderStatus);
            Model.ServiceCharge = 100;
            Model.RentBeforeDays = 1;

            List.Add(Model);
            ViewBag.JourneryLog = List;

            ViewBag.TotalCount = totalCount;
            ViewBag.TotalPage = TotalPage;
            //是否是短租会员
            ViewBag.DuanzuMember = 1;
            return View();
        }

        /// <summary>
        /// 房客-旅程记录-申请投诉弹窗页
        /// </summary>
        /// <returns></returns>
        public ActionResult ApplyComplaint(int OrderId)
        {
            //查询订单信息
            HouseComplaintInfo Model = new HouseComplaintInfo();
            Model.Day = 3;
            Model.HouseId = 11;
            Model.Id = 22;

            ViewBag.TotalDay = Model.Day;
            ViewBag.HouseId = Model.HouseId;
            ViewBag.Id = Model.Id;
            return View();
        }
        #endregion

        /// <summary>
        /// 获取订单状态名
        /// </summary>
        /// <param name="orderStatus">订单状态标识</param>
        /// <returns></returns>
        public static string GetOrderStateName(int orderStatus)
        {
            string orderStateName = "";
            switch (orderStatus)
            {
                case 0:
                    orderStateName = "待支付";
                    break;
                case 1:
                    orderStateName = "已支付";
                    break;
                case 2:
                    orderStateName = "待入住";
                    break;
                case 3:
                    orderStateName = "入住中";
                    break;
                case 4:
                    orderStateName = "待评价";
                    break;
                case 5:
                    orderStateName = "已完成";
                    break;
                case 6:
                    orderStateName = "已取消";
                    break;
                case 7:
                    orderStateName = "入住中";
                    break;
                case 8:
                    orderStateName = "投诉待处理";
                    break;
                case 9:
                    orderStateName = "已取消";
                    break;
            }
            return orderStateName;
        }
    }
}
