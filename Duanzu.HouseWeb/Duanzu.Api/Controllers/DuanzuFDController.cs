using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Duanzu.Api.Controllers
{
    /// <summary>
    /// 短租房东需要调用的api
    /// </summary>
    public class DuanzuFDController : ApiController
    {
        #region 房源上下架
        /// <summary>
        /// 房源上下架
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="city">城市id</param>
        /// <param name="state">上下架状态</param>
        /// <returns></returns>
        public bool UpdateHouseState(int hid, int city, int state)
        {
            try
            {
                //房源上下架接口调用

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 房源管理-退保真金
        /// <summary>
        /// 退保真金
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="city">城市id</param>
        /// <returns></returns>
        public bool TuiBaoZhen(int hid, int city)
        {
            try
            {
                 //房源管理-退保真金

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 房东-房源管理-查看订单，处理投诉
        /// <summary>
        ///  房东-房源管理-查看订单，处理投诉
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="orderNum">订单号</param>
        /// <param name="orderState">订单状态</param>
        /// <returns></returns>
        public bool HandleComplaint(int hid, string orderNum, int orderState)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 房东-房源管理-查看订单，同意接单
        /// <summary>
        ///  房东-房源管理-查看订单，同意接单
         /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="orderNum">订单号</param>
        /// <param name="orderState">订单状态</param>
        /// <returns></returns>
        public bool HandleJieDan(int hid, string orderNum, int orderState)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 房东-房源管理-查看订单，拒绝接单
        /// <summary>
        ///  房东-房源管理-查看订单，拒绝接单
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="orderNum">订单号</param>
        /// <param name="orderState">订单状态</param>
        /// <returns></returns>
        public bool HandleJuDan(int hid, string orderNum, int orderState)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 房东-房源管理-查看订单，同意退房
        /// <summary>
        ///  房东-房源管理-查看订单，同意退房
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="orderNum">订单号</param>
        /// <param name="orderState">订单状态</param>
        /// <returns></returns>
        public bool HandleTuiFang(int hid, string orderNum, int orderState)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 房东-房源管理-查看订单，拒绝退房
        /// <summary>
        ///  房东-房源管理-查看订单，拒绝退房
        /// </summary>
        /// <param name="hid">房源id</param>
        /// <param name="orderNum">订单号</param>
        /// <param name="orderState">订单状态</param>
        /// <returns></returns>
        public bool HandleRefuseTuiFang(int hid, string orderNum, int orderState)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 房东-权威认证-提交认证申请
        /// <summary>
        ///  房东-权威认证-提交认证申请
        /// </summary>
        /// <param name="guid">图片guid</param>
        /// <returns></returns>
        public bool SubmitAuthentication(string guid)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
