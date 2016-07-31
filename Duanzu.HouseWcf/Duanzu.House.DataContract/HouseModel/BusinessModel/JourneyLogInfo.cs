using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.BusinessModel
{
    /// <summary>
    /// 房客-旅程记录Model
    /// </summary>
    public class JourneyLogInfo
    {
        /// <summary>
        /// 订单自增id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 租客id
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 房源id
        /// </summary>
        public int HouseID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime RentStartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime RentEndDate { get; set; }

        /// <summary>
        /// 实际退房时间
        /// </summary>
        public DateTime CheckOutTime { get; set; }

        /// <summary>
        /// 房客
        /// </summary>
        public int PeopleNumber { get; set; }

        /// <summary>
        /// 房东电话
        /// </summary>
        public string LandlordMobile { get; set; }

        /// <summary>
        /// 支付租金
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 订单状态名称
        /// </summary>
        public string OrderStatusName { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        public int ServiceCharge { get; set; }

        /// <summary>
        /// 违约配置表-入住前天数
        /// </summary>
        public int RentBeforeDays { get; set; }

        /// <summary>
        /// 违约后扣除天数
        /// </summary>
        public int DeductDays { get; set; }

        /// <summary>
        /// 房源是否有投诉
        /// </summary>
        public int TouSuCount { get; set; }
    }
}
