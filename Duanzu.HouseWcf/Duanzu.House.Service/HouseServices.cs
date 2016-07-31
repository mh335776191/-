using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.Contract.HouseInterface;
using Duanzu.House.DataContract.HouseModel;
using Duanzu.House.DataContract.HouseModel.BusinessModel;
using Duanzu.House.DataContract.HouseModel.DBModel;
using Duanzu.House.DataContract.QueryModel;
using Duanzu.House.Responsitory;
using Duanzu.House.Responsitory.Moxing;
using Duanzu.House.Responsitory.Moxing.Interface;
using Duanzu.House.Responsitory.Responsitory;

namespace Duanzu.House.Service
{
    public class HouseServices : IHouseServicersContract
    {
        #region 房源

        public int AddHouse(HouseInfo houseentity)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.HouseResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            return resonsitory.Add<HouseInfo>(houseentity);
        }
        public int UpdateHouse(HouseInfo houseentity)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.HouseResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            return resonsitory.Update<HouseInfo>(houseentity);
        }

        public int DeleteHouse(int identity)
        {
            throw new NotImplementedException();
        }
        public BaseHouseInfo GetHouseInfoById(int identify)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.HouseResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            var model = resonsitory.GetModel<BaseHouseInfo>(identify);
            return model;
        }
        public BaseHouseInfo GetHouseInfo(HouseQuery entity)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.HouseResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            var model = resonsitory.GetModel<BaseHouseInfo>(entity);
            return model;
        }

        public IEnumerable<BaseHouseInfo> GetHouseList(HouseQuery entity)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.HouseResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            var model = resonsitory.GetEntityList<BaseHouseInfo>(entity);
            return model;
        }

        #endregion
        #region 组员词典
        public IEnumerable<T_HouseDic> GetHouseDicList(HouseDicQuery entity)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.HouseDicResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            var model = resonsitory.GetEntityList<T_HouseDic>(entity);
            return model;
        }
        #endregion

        #region 用户收藏房源
        public IEnumerable<FavoriteHouseInfo> GetUserFavoriteHouse(FavoriteQuery query)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.FavoriteResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            var model = resonsitory.GetEntityList<FavoriteHouseInfo>(query);
            return model;
        }

        #endregion

        #region  用户评论
        /// <summary>
        /// 添加用户评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public int AddUserComment(UserComment comment)
        {
            IDomain domain = new Domain();
            IResponsitory istroy = new House.Responsitory.Responsitory.UserCommentResponsitory();
            Resonsitory resonsitory = new Resonsitory(domain, istroy);
            return resonsitory.Add<UserComment>(comment);
        }

        #endregion
    }
}
