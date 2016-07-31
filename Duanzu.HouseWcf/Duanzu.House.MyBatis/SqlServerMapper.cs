using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace Duanzu.House.MyBatis
{
    sealed class SqlServerMapper
    {

        #region Fields
        private static volatile ISqlMapper _mapper = null;
        #endregion

        /// <summary>    
        ///     
        /// </summary>    
        /// <param name="obj"></param>    
        private static void Configure(object obj)
        {
            _mapper = null;
        }

        /// <summary>    
        /// Init the 'default' SqlMapper defined by the SqlMap.Config file.    
        /// </summary>    
        private static void InitMapper()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            _mapper = builder.ConfigureAndWatch("SqlServerSqlMap.config", handler);//自定义的配置文件
        }

        /// <summary>    
        /// Get the instance of the SqlMapper defined by the SqlMap.Config file.    
        /// </summary>    
        /// <returns>A SqlMapper initalized via the SqlMap.Config file.</returns>    
        public static ISqlMapper Instance()
        {
            if (_mapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (_mapper == null) // double-check    
                    {
                        InitMapper();
                    }
                }
            }
            return _mapper;
        }

        /// <summary>    
        /// Get the instance of the SqlMapper defined by the SqlMap.Config file. (Convenience form of Instance method.)    
        /// </summary>    
        /// <returns>A SqlMapper initalized via the SqlMap.Config file.</returns>    
        public static ISqlMapper Get()
        {
            return Instance();
        }
    }
}

