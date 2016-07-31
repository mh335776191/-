using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;
using Duanzu.House.Responsitory.Moxing.Interface;
using Duanzu.House.Responsitory.Responsitory;

namespace Duanzu.House.Responsitory.Moxing
{
    /// <summary>
    /// 领域模型类
    /// </summary>   
    public class Domain : IDomain
    {
        //private Dictionary<IEntity, IResponsitory> addEntity;
        //private Dictionary<IEntity, IResponsitory> updateEntity;       
        public Domain()
        {
            //addEntity = new Dictionary<IEntity, IResponsitory>();
            //updateEntity = new Dictionary<IEntity, IResponsitory>();            
        }

        #region IDomain 成员

        public int CreateEntity(IEntity entity, IResponsitory responsitory)
        {
            //addEntity.Add(entity, responsitory);
            return responsitory.ResponsitoryAdd(entity);
        }

        public int UpdateEntity(IEntity entity, IResponsitory responsitory)
        {
            //updateEntity.Add(entity, responsitory);
            return responsitory.ResponsitoryEdit(entity);
        }

        public int DeleteEntity(int identify, IResponsitory responsitory)
        {
            return responsitory.ResponsitoryDelete(identify);
        }

        public T GetEntity<T>(IEntity queryentity, IResponsitory responsitory)
        {
            return responsitory.GetEntity<T>(queryentity);
        }

        public IEnumerable<T> GetList<T>(IEntity queryentity, IResponsitory responsitory)
        {
            return responsitory.GetList<T>(queryentity);
        }
        public T GetEntity<T>(int identify, IResponsitory responsitory)
        {
            return responsitory.GetEntity<T>(identify);
        }
        #endregion
    }
}
