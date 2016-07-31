using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;
using Duanzu.House.Responsitory.BusinessInterface;
using Duanzu.House.Responsitory.Moxing.Interface;
using Duanzu.House.Responsitory.Responsitory;

namespace Duanzu.House.Responsitory
{
    /// <summary>
    /// 实现了业务，并操作了持久化，形成了一个单独的领域
    /// </summary>
    public class Resonsitory : IOperate
    {
        #region IResponsitory 成员
        IDomain _domain;
        IResponsitory _resoponsitory;
        public Resonsitory(IDomain domainmodel, IResponsitory responsitory)
        {
            this._domain = domainmodel;
            this._resoponsitory = responsitory;
        }

        #endregion

        #region IOperate 业务操作

        public int Add<T>(T entity) where T : IEntity
        {
            return _domain.CreateEntity(entity, _resoponsitory);
        }
        public int Update<T>(T entity) where T : IEntity
        {
            return _domain.UpdateEntity(entity, _resoponsitory);
        }

        public int Delete(int identify)
        {
            return _domain.DeleteEntity(identify, _resoponsitory);
        }
        public IEnumerable<T> GetEntityList<T>(modelInterface.Interface.IEntity entity)
        {
            return _domain.GetList<T>(entity, _resoponsitory);
        }
        public T GetModel<T>(modelInterface.Interface.IEntity entity)
        {
            return _domain.GetEntity<T>(entity, _resoponsitory);
        }

        public T GetModel<T>(int identify)
        {
            return _domain.GetEntity<T>(identify, _resoponsitory);
        }
        #endregion

    }
}
