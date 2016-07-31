using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;
using Duanzu.House.Responsitory.Responsitory;

namespace Duanzu.House.Responsitory.Moxing.Interface
{
    /// <summary>
    /// 领域模型
    /// </summary>  
    public interface IDomain
    {
        int CreateEntity(IEntity entity, IResponsitory responsitory);
        int UpdateEntity(IEntity entity, IResponsitory responsitory);
        int DeleteEntity(int identify, IResponsitory responsitory);
        T GetEntity<T>(modelInterface.Interface.IEntity entity, IResponsitory responsitory);
        IEnumerable<T> GetList<T>(IEntity queryentity, IResponsitory responsitory);

        T GetEntity<T>(int identify, IResponsitory responsitory);

    }
}
