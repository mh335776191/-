using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.DBModel
{
     [DataContract]
    /// <summary>
    /// 短租房源审核表
    /// </summary>
    public class T_HouseAudit
    {
         [DataMember]
         public int Id { get; set; }
        [DataMember]
        public int HouseID { get; set; }
        [DataMember]
        public byte AuditState { get; set; }
        [DataMember]
        public int AuditorID { get; set; }
        [DataMember]
        public string Auditor { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public DateTime UpdateTime { get; set; }
    }
}
