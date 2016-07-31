using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.modelInterface.Interface;
namespace Duanzu.House.Responsitory.Responsitory
{
    /// <summary>
    /// 持久化接口
    /// </summary>
    public interface IResponsitory
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int ResponsitoryAdd(IEntity entity);
        /// <summary>
        /// 编辑实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int ResponsitoryEdit(IEntity entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        int ResponsitoryDelete(int identify);
        /// <summary>
        /// 获取集合
        /// </summary>       
        /// <param name="param"></param>
        /// <returns></returns>
        IEnumerable<T> GetList<T>(IEntity queryentity);
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        T GetEntity<T>(IEntity queryentity);
        T GetEntity<T>(int identify);
    }
}
