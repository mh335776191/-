using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Duanzu.House.Contract.HouseInterface;
using Duanzu.House.DataContract;
using Duanzu.TXCommons.BasicsClass;
using Duanzu.TXCommons.InvokiServices;

namespace Duanzu.Controller.Controllers
{
    public class ShortRentController : System.Web.Mvc.Controller
    {
        #region 发布短租房源
        /// <summary>
        /// 发布短租房源
        /// </summary>
        /// <returns></returns>
        public ActionResult ShortRent()
        {
            var houseDict = new Duanzu.House.DataContract.QueryModel.HouseDicQuery();
            var client = HouseServiceInvoker<IHouseServicersContract>.GetBasicClient();
            houseDict.Type = 1;
            var tsList = client.GetHouseDicList(houseDict);
            houseDict.Type = 2;
            var roomList = client.GetHouseDicList(houseDict);

            SeoModel seo = new SeoModel();
            seo.Title = "短租发布房源";
            seo.Keywords = "";
            seo.Description = "";
            ViewBag.seo = seo;
            ViewBag.Ts = tsList;//GetList(1);  //获取房源特色
            ViewBag.Room = roomList;// GetList(2);//获取配套设施
            ViewBag.Provinces = GetProvinceList(); //获取省份
            ViewBag.Citys = GetCityList(); //获取城市
            ViewBag.Districts = GetDistrictList(); //获取区域
            return View();
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadPiture()
        {
            var info = new ImageInfo()
            {
                _Guid = Guid.NewGuid().ToString(),
                FullPath = true,
                PictureType = "OTHER",
                ShowPictureType = string.Empty,
                Maxnum = 24,
                CityID = 0,
                IsEdit = false,
                ImgId = 0,
                FilePath = string.Empty,
                Desc = string.Empty,
                IsCover = false,
                Index = 2
            };
            ViewData["ImgModel"] = info;
            return PartialView("PartialUploadPicture");
        }

        /// <summary>
        /// 提交表单数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitData()
        {
            var IsLogin = true;
            if (!IsLogin)
            {
                return Json(new { result = 0, message = "请先登录" });
            }
            var model = new Duanzu.House.DataContract.HouseModel.BusinessModel.HouseInfo();
            InitPosition(model);
            var client = HouseServiceInvoker<IHouseServicersContract>.GetBasicClient();
            var result = client.AddHouse(model); //调用接口，房源数据入库           

            if (result > 0)
            {
                //发送图片消息
                //SendMQ.SendTreadTreeMQ(model.InnerCode, model.HouseID.ToString(), model.CityID, model.LongType, model.LongId, "update");   //修改房源信息后发送消息                 
                //var client = new TXCommons.managerservice.SolrServicePortTypeClient();
                //client.updateHouse(houseID.ToString());
                //var UrlLink = string.Format("/OnlinePay/Prepay?houseid={0}&type=62", houseID);
                var UrlLink = "/shortrent/shortrent";
                return Json(new { result = true, UrlLink });
            }
            else
            {
                return Json(new { result = false, message = "发布过程出现错误，请稍后再试！" });
            }

        }
        #endregion

        #region  房源实体始化
        /// <summary>
        /// 房源实体始化
        /// </summary>
        /// <param name="model">实体</param>
        [ValidateInput(false)] 
        private void InitPosition(Duanzu.House.DataContract.HouseModel.BusinessModel.HouseInfo model)
        {
            model.UserID = string.IsNullOrWhiteSpace(Request.Form["UserID"]) ? 0 : int.Parse(Request.Form["UserID"]);
            model.ProvinceID = string.IsNullOrWhiteSpace(Request.Form["ProvinceID"]) ? 0 : int.Parse(Request.Form["ProvinceID"]);
            model.CityID = string.IsNullOrWhiteSpace(Request.Form["CityID"]) ? 0 : int.Parse(Request.Form["CityID"]);
            model.Lat = string.IsNullOrWhiteSpace(Request.Form["Lat"]) ? 0 : decimal.Parse(Request.Form["Lat"]);
            model.Lng = string.IsNullOrWhiteSpace(Request.Form["Lng"]) ? 0 : decimal.Parse(Request.Form["Lng"]);
            model.AreaID = string.IsNullOrWhiteSpace(Request.Form["AreaID"]) ? 0 : int.Parse(Request.Form["AreaID"]);
            model.BusinessID = string.IsNullOrWhiteSpace(Request.Form["BusinessID"]) ? 0 : int.Parse(Request.Form["BusinessID"]);
            model.Address = string.IsNullOrWhiteSpace(Request.Form["Address"]) ? string.Empty : Request.Form["Address"].ToString();
            model.RentType = string.IsNullOrWhiteSpace(Request.Form["RentType"]) ? byte.Parse("0") : byte.Parse(Request.Form["RentType"].ToString());
            model.HouseType = string.IsNullOrWhiteSpace(Request.Form["HouseType"]) ? byte.Parse("0") : byte.Parse(Request.Form["HouseType"]);
            model.Room = string.IsNullOrWhiteSpace(Request.Form["Room"]) ? byte.Parse("0") : byte.Parse(Request.Form["Room"]);
            model.Hall = string.IsNullOrWhiteSpace(Request.Form["Hall"]) ? byte.Parse("0") : byte.Parse(Request.Form["Hall"]);
            model.Toilet = string.IsNullOrWhiteSpace(Request.Form["Toilet"]) ? byte.Parse("0") : byte.Parse(Request.Form["Toilet"]);
            model.Kitchen = string.IsNullOrWhiteSpace(Request.Form["Kitchen"]) ? byte.Parse("0") : byte.Parse(Request.Form["Kitchen"]);
            model.Balcony = string.IsNullOrWhiteSpace(Request.Form["Balcony"]) ? byte.Parse("0") : byte.Parse(Request.Form["Balcony"]);
            model.Bed = string.IsNullOrWhiteSpace(Request.Form["Bed"]) ? byte.Parse("0") : byte.Parse(Request.Form["Bed"]);
            model.Square = string.IsNullOrWhiteSpace(Request.Form["Square"]) ? 0 : int.Parse(Request.Form["Square"]);
            model.PeopleNumber = string.IsNullOrWhiteSpace(Request.Form["PeopleNumber"]) ? byte.Parse("0") : byte.Parse(Request.Form["PeopleNumber"]);
            model.Title = string.IsNullOrWhiteSpace(Request.Form["Title"]) ? string.Empty : Request.Form["Title"].ToString();
            model.HouseRemark = string.Empty;//string.IsNullOrWhiteSpace(Request.QueryString["HouseRemark"]) ? string.Empty : Request.QueryString["HouseRemark"].ToString();
            model.HousePhoto = string.IsNullOrWhiteSpace(Request.Form["HousePhoto"]) ? Guid.NewGuid().ToString() : Request.Form["HousePhoto"].ToString();
            model.RentPrice = string.IsNullOrWhiteSpace(Request.Form["RentPrice"]) ? 0 : int.Parse(Request.Form["RentPrice"]);
            model.Contact = string.IsNullOrWhiteSpace(Request.Form["Contact"]) ? string.Empty : Request.Form["Contact"].ToString();
            model.Mobile = string.IsNullOrWhiteSpace(Request.Form["Mobile"]) ? string.Empty : Request.Form["Mobile"].ToString();
            model.Status = byte.Parse("0");
            model.PayStatus = byte.Parse("0");
            model.PayAmount = 0;
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            model.TsString = string.IsNullOrWhiteSpace(Request.Form["Ts"]) ? string.Empty : Request.Form["Ts"].ToString();
            model.FacilitieString = string.IsNullOrWhiteSpace(Request.Form["SupportingFacilities"]) ? string.Empty : Request.Form["SupportingFacilities"].ToString();
            model.RentDateString = string.IsNullOrWhiteSpace(Request.Form["mydate"]) ? string.Empty : Request.Form["mydate"].ToString();
            model.RentStatus = 1;
            model.AuditState = 0;
            model.AuditorID = 0;
            model.Auditor = string.Empty;
            model.RentBeforeDays = string.IsNullOrWhiteSpace(Request.Form["RentBeforeDays"]) ? byte.Parse("0") : byte.Parse(Request.Form["RentBeforeDays"].ToString());
            model.DeductDays = string.IsNullOrWhiteSpace(Request.Form["DeductDays"]) ? byte.Parse("0") : byte.Parse(Request.Form["DeductDays"].ToString());

        }


        #endregion

        #region 获取特色信息
        private List<SelectListItem> GetList(int type)
        {
            var logTypes = new List<SelectListItem>();
            if (type == 1)
            {
                logTypes.Add(new SelectListItem() { Text = "城市中心", Value = "2" });
                logTypes.Add(new SelectListItem() { Text = "名校附近", Value = "3" });
                logTypes.Add(new SelectListItem() { Text = "景区游玩", Value = "4" });
                logTypes.Add(new SelectListItem() { Text = "修身养性", Value = "5" });
            }
            else
            {
                logTypes.Add(new SelectListItem() { Text = "无线网络", Value = "6" });
                logTypes.Add(new SelectListItem() { Text = "厨房", Value = "7" });
                logTypes.Add(new SelectListItem() { Text = "游泳池", Value = "19" });
                logTypes.Add(new SelectListItem() { Text = "允许携带宠物", Value = "21" });
            }

            return logTypes;
        }

        private List<SelectListItem> GetProvinceList()
        {
            var areas = new List<SelectListItem>();
            //areas.Add(new SelectListItem() { Text = "选择省份", Value = "0" });
            areas.Add(new SelectListItem() { Text = "北京", Value = "57" });
            areas.Add(new SelectListItem() { Text = "上海", Value = "54" });
            areas.Add(new SelectListItem() { Text = "天津", Value = "57" });
            areas.Add(new SelectListItem() { Text = "重庆", Value = "54" });
            areas.Add(new SelectListItem() { Text = "安徽", Value = "57" });
            areas.Add(new SelectListItem() { Text = "福建", Value = "54" });
            areas.Add(new SelectListItem() { Text = "广东", Value = "57" });
            areas.Add(new SelectListItem() { Text = "广西", Value = "54" });
            areas.Add(new SelectListItem() { Text = "海南", Value = "57" });
            areas.Add(new SelectListItem() { Text = "河北", Value = "54" });
            areas.Add(new SelectListItem() { Text = "河南", Value = "57" });
            areas.Add(new SelectListItem() { Text = "湖北", Value = "54" });
            areas.Add(new SelectListItem() { Text = "湖南", Value = "54" });
            areas.Add(new SelectListItem() { Text = "江苏", Value = "54" });
            areas.Add(new SelectListItem() { Text = "江西", Value = "54" });
            areas.Add(new SelectListItem() { Text = "辽宁", Value = "54" });
            areas.Add(new SelectListItem() { Text = "山东", Value = "54" });
            areas.Add(new SelectListItem() { Text = "陕西", Value = "54" });
            areas.Add(new SelectListItem() { Text = "四川", Value = "54" });
            areas.Add(new SelectListItem() { Text = "云南", Value = "54" });
            areas.Add(new SelectListItem() { Text = "浙江", Value = "54" });
            return areas;
        }

        private List<SelectListItem> GetCityList()
        {
            var areas = new List<SelectListItem>();
            areas.Add(new SelectListItem() { Text = "选择城市", Value = "0" });
            areas.Add(new SelectListItem() { Text = "北京", Value = "253" });
            areas.Add(new SelectListItem() { Text = "上海", Value = "239" });
            return areas;
        }

        public JsonResult Cities(int ProvinceId)
        {
            try
            {
                var cities = ProvinceId == 57 ? GetCityList()[1] : GetCityList()[2];
                return Json(new { success = true, data = cities }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        private List<SelectListItem> GetDistrictList()
        {
            var areas = new List<SelectListItem>();
            areas.Add(new SelectListItem() { Text = "选择区域", Value = "0" });
            areas.Add(new SelectListItem() { Text = "海淀", Value = "36" });
            areas.Add(new SelectListItem() { Text = "东城", Value = "35" });
            return areas;
        }
        public JsonResult Districts(int cityId)
        {
            try
            {
                var areas = new List<SelectListItem>();
                areas.Add(new SelectListItem() { Text = "浦东", Value = "54" });
                areas.Add(new SelectListItem() { Text = "徐汇", Value = "55" });
                var channels = cityId == 253 ? GetDistrictList() : areas.ToList();
                return Json(new { success = true, data = channels }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
