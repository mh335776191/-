using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.DataContract.HouseModel.DBModel
{
    /// <summary>
    /// 房客-我收藏的房源Model
    /// </summary>
    public class MyCollectHouseInfo
    {
        /// <summary>
        /// 房源id
        /// </summary>
        public int HouseID { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 城市id
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// 出租类型
        /// </summary>
        public int RentType { get; set; }

        /// <summary>
        /// 房源类型
        /// </summary>
        public int HouseType { get; set; }

        /// <summary>
        /// 房源地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 室
        /// </summary>
        public int Room { get; set; }

        /// <summary>
        /// 厅
        /// </summary>
        public int Hall { get; set; }

        /// <summary>
        /// 卫
        /// </summary>
        public int Toilet { get; set; }

        /// <summary>
        /// 厨
        /// </summary>
        public int Kitchen { get; set; }

        /// <summary>
        /// 阳台
        /// </summary>
        public int Balcony { get; set; }

        /// <summary>
        /// 出租价格
        /// </summary>
        public int RentPrice { get; set; }

        /// <summary>
        /// 房源标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 房源图片
        /// </summary>
        public string HousePhoto { get; set; }

        /// <summary>
        /// 宜居人数
        /// </summary>
        public int PeopleNumber { get; set; }

        /// <summary>
        /// 房源状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime CollectTime { get; set; }
    }
}