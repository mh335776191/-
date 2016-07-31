using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.QueryModel
{
    [DataContract]
    public class PageQuery
    {
        /// <summary>
        /// 开始位置
        /// </summary>
        [DataMember]
        public int BeginNum { get; set; }
        /// <summary>
        /// 结束条数
        /// </summary>
        [DataMember]
        public int TakeNum { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        [DataMember]
        public string OrderColumn { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        [DataMember]
        public string SortType { get; set; }
    }
    
}
