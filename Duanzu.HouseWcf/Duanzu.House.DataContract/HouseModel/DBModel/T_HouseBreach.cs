using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.DBModel
{
    [DataContract]
    public class T_HouseBreach
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int HouseID { get; set; }
        /// <summary>
        /// 入住前天数
        /// </summary>
        [DataMember]
        public byte RentBeforeDays { get; set; }
        /// <summary>
        /// 违约后扣除天数
        /// </summary>
        [DataMember]
        public byte DeductDays { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public DateTime UpdateTime { get; set; }
    }
}
