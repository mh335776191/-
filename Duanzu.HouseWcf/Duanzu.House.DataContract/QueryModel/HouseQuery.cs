using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;

namespace Duanzu.House.DataContract.QueryModel
{
    [DataContract]
    public class HouseQuery : PageQuery, IEntity
    {
        /// <summary>
        /// 发房人id
        /// </summary>
        [DataMember]
        public int UserID { get; set; }
        /// <summary>
        /// 房源id
        /// </summary>
        [DataMember]
        public int HouseID { get; set; }
        /// <summary>
        /// 出租类型
        /// </summary>
        [DataMember]
        public byte RentType { get; set; }
        /// <summary>
        /// 房源类型
        /// </summary>
        [DataMember]
        public byte HouseType { get; set; }
    }
}
