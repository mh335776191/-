using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.HouseWeb.Model.House
{

    public class HouseDetail
    {
        public int HouseID { get; set; }  //房源id
        public int UserID { get; set; }  //发房人id
        public int CityID { get; set; }  //城市id
        public decimal Lat { get; set; }  //经度
        public decimal Lng { get; set; }  //纬度
        public string Title { get; set; }  //标题
        public int HouseType { get; set; }  //房源类型
        public int RentType { get; set; }  //出租类型
        public int PeopleNumber { get; set; }  //宜居人数
        public string Address { get; set; }  // 地址
        public int Room { get; set; }  //室
        public int Hall { get; set; }  //厅
        public int Toilet { get; set; }  //卫
        public int Kitchen { get; set; }  //厨
        public int Balcony { get; set; }  //阳台
        public int Bed { get; set; }  //床
        public int Square { get; set; }  //面积（平方）
        public string HouseRemark { get; set; }  //房源描述
        public string HousePhoto { get;set;}  //房源照片
        public int RentPrice { get; set; }  //出租价格
        public string Contact { get; set; }  //联系人
        public string Mobile { get; set; }  //联系电话
        public int Status { get; set; }  //房源上下架状态0、下架1、上架
        public int PayStatus { get; set; }  //支付状态0.未支付、1.已支付、2.已退
        public decimal PayAmount { get; set; }  //支付金额
        public DateTime CreateTime { get; set; }  //创建时间
        public DateTime UpdateTime { get; set; }  //更新时间 
    }
}
