using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Duanzu.Api.Controllers
{
    //短租房客需要调用的api
    public class DuanzuFKController : ApiController
    {
        #region 删除我收藏的房源
        /// <summary>
        /// 删除我收藏的房源
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="city">城市id</param>
        /// <returns></returns>
        public bool DelHouse(int hid, int city)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 房客-我的投诉-修改房费
        /// <summary>
        /// 房客-我的投诉-修改房费
        /// </summary>
        /// <param name="Id">投诉id</param>
        /// <param name="cday">修改天数</param>
        /// <returns></returns>
        public bool HandleComplaintPrice(int Id, int cday)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 房客-旅程记录-取消订单
        /// <summary>
        /// 房客-旅程记录-取消订单
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="OrderNum">租客订单id</param>
        /// <param name="cutPrice">违约金</param>
        /// <returns></returns>
        public bool HandleCancleOrder(int hid, string OrderNum, decimal cutPrice)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 房客-旅程记录-申请退房
        /// <summary>
        /// 房客-旅程记录-申请退房
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="OrderNum">租客订单id</param>
        /// <param name="tuiPrice">退还金额</param>
        /// <returns></returns>
        public bool ApplyTuiFang(int hid, string OrderNum, decimal tuiPrice)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 房客-旅程记录-提交投诉
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="OrderId">订单id</param>
        /// <param name="Days">选择退款天数</param>
        /// <param name="content">投诉内容</param>
        /// <returns></returns>
        public bool HandleApplyComplaint(int hid, int OrderId, int Days, string content)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
