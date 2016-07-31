using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net;

namespace Log4netService
{
    /// <summary>
    /// FileName: LogFactory.cs
    /// CLRVersion: 4.0.30319.17929
    /// Author: 黄继华
    /// Corporation:
    /// Description:
    /// DateTime: 2012/12/10 10:38:30
    /// </summary>
    public class LogFactory
    {
        static Dictionary<string, ILog> iloglist;
        static LogFactory()
        {
            FileInfo configFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"Log.config");
            iloglist = new Dictionary<string, ILog>();
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public static LogImplement GetLogger(Type type)
        {
            return new LogImplement(LogManager.GetLogger(type));
        }

        public static LogImplement GetLogger(string str)
        {
            ILog log = null;
            lock (iloglist)
            {
                if (iloglist.Keys.Contains(str))
                {
                    log = iloglist[str];
                    if (log == null)
                    {
                        log = LogManager.GetLogger(str);
                        iloglist[str] = log;
                    }
                }
                else
                {

                    log = LogManager.GetLogger(str);
                    iloglist.Add(str, log);
                }
                return new LogImplement(log);
            }

        }
    }
}
