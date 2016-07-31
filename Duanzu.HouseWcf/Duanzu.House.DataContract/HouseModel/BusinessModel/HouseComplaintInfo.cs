using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.BusinessModel
{
    /// <summary>
    /// 房东-房源管理-查看订单-投诉处理Model
    /// </summary>
    public class HouseComplaintInfo
    {
        /// <summary>
        /// 投诉id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 房源id
        /// </summary>
        public int HouseId { get; set; }

        /// <summary>
        /// 租客要求退几天房租
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// 租客预定总天数
        /// </summary>
        public int TotalDay { get; set; }

        /// <summary>
        /// 房租
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 投诉内容
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 投诉时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 投诉状态
        /// </summary>
        public int State { get; set; }
    }
}
