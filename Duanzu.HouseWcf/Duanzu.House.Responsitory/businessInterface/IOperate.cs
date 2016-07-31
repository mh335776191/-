using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;

namespace Duanzu.House.Responsitory.BusinessInterface
{
    /// <summary>
    /// 添加业务接口
    /// </summary>
    public interface IOperate
    {
        int Add<T>(T entity) where T : IEntity;
        int Update<T>(T entity) where T : IEntity;
        int Delete(int identify);
        IEnumerable<T> GetEntityList<T>(modelInterface.Interface.IEntity entity);
        T GetModel<T>(modelInterface.Interface.IEntity entity);
        T GetModel<T>(int identify);

    }
}
