using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duanzu.House.Responsitory.Responsitory
{
    public class FavoriteResponsitory : IResponsitory
    {
        #region IResponsitory 成员

        public int ResponsitoryAdd(modelInterface.Interface.IEntity entity)
        {
            throw new NotImplementedException();
        }

        public int ResponsitoryEdit(modelInterface.Interface.IEntity entity)
        {
            throw new NotImplementedException();
        }

        public int ResponsitoryDelete(int identify)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetList<T>(modelInterface.Interface.IEntity queryentity)
        {
            return MyBatis.MyBatisHelper.QueryForList<T>("SelectFavoriteHouseByWhere", queryentity);
        }

        public T GetEntity<T>(modelInterface.Interface.IEntity queryentity)
        {
            throw new NotImplementedException();
        }

        public T GetEntity<T>(int identify)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
