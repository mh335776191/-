using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;

namespace Duanzu.House.DataContract.HouseModel.DBModel
{
    [DataContract]
    /// <summary>
    /// 用户评论
    /// </summary>
    public class UserComment : IEntity
    {
          [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SourceType { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public byte IsDel { get; set; }
        [DataMember]
        public DateTime UpdateDate { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public int HouseScore { get; set; }
        [DataMember]
        public int RenterScore { get; set; }
        [DataMember]
        public int FacilitiesScore { get; set; }
        [DataMember]
        public int HouseID { get; set; }
        [DataMember]
        public byte AuditType { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public byte HealthScore { get; set; }
        [DataMember]
        public byte SafetyScore { get; set; }
        [DataMember]
        public byte DescribeScore { get; set; }
        [DataMember]
        public byte TrafficScore { get; set; }

    }
}
