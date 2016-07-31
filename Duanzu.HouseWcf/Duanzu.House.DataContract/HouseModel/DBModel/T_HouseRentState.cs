using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.DBModel
{
    /// <summary>
    /// 房源出租状态信息
    /// </summary>
    [DataContract]
    public class T_HouseRentState
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int HouseID { get; set; }
        /// <summary>
        /// 出租日期
        /// </summary>
        [DataMember]
        public DateTime RentDate { get; set; }      
        /// <summary>
        /// 出租状态(0不出租 1可租 2已租)
        /// </summary>
        [DataMember]
        public byte RentStatus { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public DateTime UpdateTime { get; set; }
    }
}
