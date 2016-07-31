using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.Responsitory.Responsitory;
using Duanzu.TXCommons.InvokiServices;

namespace Duanzu.House.Responsitory.Responsitory
{
    public class HouseDicResponsitory : IResponsitory
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

        public IEnumerable<T> GetList<T>(modelInterface.Interface.IEntity entity)
        {

            return MyBatis.MyBatisHelper.QueryForList<T>("SelectHouseDicByWhere", entity);
        }

        public T GetEntity<T>(modelInterface.Interface.IEntity entity)
        {
            return MyBatis.MyBatisHelper.Get<T>("SelectHouseDicByWhere", entity);
        }

        public T GetEntity<T>(int identify)
        {
            return MyBatis.MyBatisHelper.Get<T>("SelectHouseDicById", identify);
        }

        #endregion
    }
}
