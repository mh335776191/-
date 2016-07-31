using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Duanzu.House.modelInterface.Interface;

namespace Duanzu.House.DataContract.HouseModel.DBModel
{
    [DataContract]
    public class T_HouseDic : IEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int DictID { get; set; }
        [DataMember]
        public byte Type { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
