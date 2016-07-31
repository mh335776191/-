using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.BusinessModel
{
    /// <summary>
    /// 房东-房源管理-查看房源订单Model
    /// </summary>
    public class DuanzuHouseOrderInfo
    {
        /// <summary>
        /// 租房订单id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 预定用户id
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 房源id
        /// </summary>
        public int HouseID { get; set; }

        /// <summary>
        /// 出租开始时间
        /// </summary>
        public DateTime RentStartDate { get; set; }

        /// <summary>
        /// 出租结束时间
        /// </summary>
        public DateTime RentEndDate { get; set; }

        /// <summary>
        /// 租金总额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 居住人数
        /// </summary>
        public int PeopleNumber { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 订单状态名
        /// </summary>
        public string OrderStatusName { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        public int ServiceCharge { get; set; }

        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 房客手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 租客提交投诉
        /// </summary>
        public int ToushuCount { get; set; }
    }
}
