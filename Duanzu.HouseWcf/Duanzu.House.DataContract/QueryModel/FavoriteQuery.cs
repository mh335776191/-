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
    /// <summary>
    /// 用户收藏查询
    /// </summary>
    public class FavoriteQuery : PageQuery, IEntity
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public byte IsDel { get; set; }      

    }
}
