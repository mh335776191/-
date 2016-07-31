using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;

namespace Duanzu.House.DataContract.HouseModel.BusinessModel
{
    /// <summary>
    /// 房源信息实体,更新，新增
    /// </summary>
    [DataContract]
    public class HouseInfo : IEntity
    {

        #region t_HouseInfo短租房源信息
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
        #endregion

        #region t_HouseRentState 房租出租状态表
        /// <summary>
        /// 出租日期
        /// </summary>
        [DataMember]
        public DateTime RentDate { get; set; }
        /// <summary>
        /// 出租日期(N天)
        /// </summary>
        [DataMember]
        public string RentDateString { get; set; }
        /// <summary>
        /// 出租状态(0不出租 1可租 2已租)
        /// </summary>
        [DataMember]
        public byte RentStatus { get; set; }
        #endregion

        #region t_HouseAroundInfo房源特色表
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
        /// <summary>
        /// 房源特色
        /// </summary>
        [DataMember]
        public string TsString { get; set; }
        /// <summary>
        /// 房源配套
        /// </summary>
        [DataMember]
        public string FacilitieString { get; set; }
        #endregion

        #region t_HouseAudit短租房源审核表
        /// <summary>
        /// 审核状态(0未审核 1审核通过 2审核不通过)
        /// </summary>
        [DataMember]
        public byte AuditState { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>
        [DataMember]
        public int AuditorID { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]
        public string Auditor { get; set; }
        #endregion

        #region t_HouseBreach　房屋违约配制表
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
        #endregion
    }
}
