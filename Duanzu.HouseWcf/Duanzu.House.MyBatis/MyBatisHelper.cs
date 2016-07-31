using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataMapper;

namespace Duanzu.House.MyBatis
{
    public class MyBatisHelper
    {
        static MyBatisHelper()
        {
            string filepath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "mybatislog4Net.config";
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(filepath));
        }
        static ISqlMapper mapper;
        private static ISqlMapper iSqlMapper
        {
            get
            {
                try
                {
                    if (mapper == null)
                        mapper = Mapper.Instance();
                    return mapper;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static int Insert<T>(string statementName, T t)
        {
            if (iSqlMapper != null)
            {
                var result = iSqlMapper.Insert(statementName, t);
                return (int)result;
            }
            return 0;
        }
        public static int Update<T>(string statementName, T t)
        {

            if (iSqlMapper != null)
            {
                return iSqlMapper.Update(statementName, t);
            }
            return 0;
        }
        public static int Delete(string statementName, int primaryKeyId)
        {

            if (iSqlMapper != null)
            {
                return iSqlMapper.Delete(statementName, primaryKeyId);
            }
            return 0;
        }
        public static T Get<T>(string statementName, int primaryKeyId)
        {

            if (iSqlMapper != null)
            {
                return iSqlMapper.QueryForObject<T>(statementName, primaryKeyId);
            }
            return default(T);
        }
        public static T Get<T>(string statementName, object parameterObject = null)
        {
            if (iSqlMapper != null)
            {
                return iSqlMapper.QueryForObject<T>(statementName, parameterObject);
            }
            return default(T);
        }
        public static IList<T> QueryForList<T>(string statementName, object parameterObject = null)
        {

            if (iSqlMapper != null)
            {
                return iSqlMapper.QueryForList<T>(statementName, parameterObject);
            }
            return null;
        }
    }
}
