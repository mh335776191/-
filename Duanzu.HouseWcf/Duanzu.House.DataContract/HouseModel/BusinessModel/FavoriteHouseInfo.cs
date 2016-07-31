using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.BusinessModel
{

    public class FavoriteHouseInfo : BaseHouseInfo
    {
        [DataMember]
        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime CollectTime { get; set; }

        [DataMember]
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }
    }
}
