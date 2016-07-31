using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.DataContract.HouseModel.DBModel;
using Duanzu.House.modelInterface.Interface;

namespace Duanzu.House.Responsitory.Responsitory
{
    public class UserCommentResponsitory : IResponsitory
    {
        #region IResponsitory 成员

        public int ResponsitoryAdd(IEntity entity)
        {
            var model = entity as UserComment;
            return MyBatis.SqlMyBatisHelper.Insert<UserComment>("AddUserComment", model);
        }

        public int ResponsitoryEdit(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public int ResponsitoryDelete(int identify)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetList<T>(IEntity queryentity)
        {
            throw new NotImplementedException();
        }

        public T GetEntity<T>(IEntity queryentity)
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
