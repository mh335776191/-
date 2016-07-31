using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.DataContract;
using Duanzu.House.DataContract.HouseModel.BusinessModel;
using Duanzu.House.DataContract.HouseModel.DBModel;
using Duanzu.House.DataContract.QueryModel;

namespace Duanzu.House.Contract.HouseInterface
{
    [ServiceContract(Name = "HouseServicers", Namespace = "http://www.kuaiyoujia.com/")]
    public interface IHouseServicersContract
    {
        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="houseentity"></param>
        /// <returns>添加的实体</returns>
        [OperationContract]
        int AddHouse(HouseInfo houseentity);
        /// <summary>
        /// 更新房源
        /// </summary>
        /// <param name="houseentity">更新的房源实体</param>
        /// <returns></returns>
        [OperationContract]
        int UpdateHouse(HouseInfo houseentity);
        /// <summary>
        /// 删除房源信息
        /// </summary>
        /// <param name="identity">房源标识</param>
        /// <returns></returns>
        [OperationContract]
        int DeleteHouse(int identity);
        /// <summary>
        /// 获取房源信息
        /// </summary>
        /// <param name="identify">id标识</param>
        /// <returns></returns>
        [OperationContract]
        BaseHouseInfo GetHouseInfoById(int identify);
        /// <summary>
        /// 获取房源信息
        /// </summary>      
        /// <returns></returns>
        [OperationContract]
        BaseHouseInfo GetHouseInfo(HouseQuery query);
        /// <summary>
        /// 获取房源列表
        /// </summary>        
        /// <returns></returns>
        [OperationContract]
        IEnumerable<BaseHouseInfo> GetHouseList(HouseQuery query);

        /// <summary>
        /// 获取房源字典
        /// </summary>       
        /// <returns></returns>
        [OperationContract]
        IEnumerable<T_HouseDic> GetHouseDicList(HouseDicQuery entity);
        #region 用户收藏房源
        [OperationContract]
        /// <summary>
        /// 用户收藏房源列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<FavoriteHouseInfo> GetUserFavoriteHouse(FavoriteQuery query);
        #endregion

        #region  用户评论
        /// <summary>
        /// 新增用户评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [OperationContract]
        int AddUserComment(UserComment comment);
        #endregion
    }
}
