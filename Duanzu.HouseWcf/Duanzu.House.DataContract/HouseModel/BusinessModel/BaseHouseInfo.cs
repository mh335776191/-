using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.BusinessModel
{
    [DataContract]
    /// <summary>
    /// 房源基本信息
    /// </summary>
    public class BaseHouseInfo
    {
        [DataMember]
        public int HouseID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int ProvinceID { get; set; }
        [DataMember]
        public int CityID { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [DataMember]
        public decimal Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        [DataMember]
        public decimal Lng { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        [DataMember]
        public int AreaID { get; set; }
        [DataMember]
        public int BusinessID { get; set; }
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// 出租类型(1：整套房子、公寓 ２独立房间 ３合租房间)
        /// </summary>
        [DataMember]
        public byte RentType { get; set; }
        /// <summary>
        /// 房源类型(1住宅 2四合院 3民宿 4别墅 5公寓 6酒店式公寓 7农家乐)
        /// </summary>
        [DataMember]
        public byte HouseType { get; set; }
        [DataMember]
        public byte Room { get; set; }
        [DataMember]
        public byte Hall { get; set; }
        [DataMember]
        public byte Toilet { get; set; }
        [DataMember]
        public byte Kitchen { get; set; }
        /// <summary>
        /// 阳台
        /// </summary>
        [DataMember]
        public byte Balcony { get; set; }
        /// <summary>
        /// 床位
        /// </summary>
        [DataMember]
        public byte Bed { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        [DataMember]
        public int Square { get; set; }
        /// <summary>
        /// 宜居人数
        /// </summary>
        [DataMember]
        public byte PeopleNumber { get; set; }
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 房源描述
        /// </summary>
        [DataMember]
        public string HouseRemark { get; set; }
        /// <summary>
        /// 房源照片
        /// </summary>
        [DataMember]
        public string HousePhoto { get; set; }
        /// <summary>
        /// 出租价格
        /// </summary>
        [DataMember]
        public int RentPrice { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        /// <summary>
        /// 房源状态(0下架，1上架)
        /// </summary>
        [DataMember]
        public byte Status { get; set; }
        /// <summary>
        /// 支付状态(0未支付  1已支付)
        /// </summary>
        [DataMember]
        public byte PayStatus { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        [DataMember]
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }
        [DataMember]
        /// <summary>
        /// 房源审核状态 
        /// </summary>
        public int AuditState { get; set; }
        [DataMember]
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AuditTime { get; set; }
        [DataMember]
        /// <summary>
        /// 审核人
        /// </summary>
        public string Auditor { get; set; }
        [DataMember]
        /// <summary>
        /// 出租时间
        /// </summary>
        public DateTime RentDate { get; set; }
        [DataMember]
        /// <summary>
        /// 出租状态
        /// </summary>
        public byte RentStatus { get; set; }
        [DataMember]
        /// <summary>
        /// 出租状态最后修改时间
        /// </summary>
        public DateTime RentLastUpDateTime { get; set; }
        [DataMember]
        /// <summary>
        /// 入住前天数
        /// </summary>
        public byte RentBeforeDays { get; set; }
        [DataMember]
        /// <summary>
        /// 违约后扣除天数
        /// </summary>
        public byte DeductDays { get; set; }
    }
}