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
    public class HouseDicQuery : PageQuery,IEntity
    {
        [DataMember]
        public int DictID { get; set; }
        [DataMember]
        public byte Type { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
