using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.DBModel
{
    /// <summary>
    /// 房源特色表
    /// </summary>
    [DataContract]
    public class T_HouseAroundInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int HouseID { get; set; }
        /// <summary>
        /// 字典ID
        /// </summary>
        [DataMember]
        public int DictID { get; set; }
        /// <summary>
        /// 类型(1特色 2配套设施)
        /// </summary>
        [DataMember]
        public byte Type { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public DateTime UpdateTime { get; set; }

    }
}
