using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Log4netService
{
    /// <summary>
    /// FileName: LogImplement.cs
    /// CLRVersion: 4.0.30319.17929
    /// Author: 黄继华
    /// Corporation:
    /// Description:
    /// DateTime: 2012/12/10 10:38:30
    /// </summary>
    public class LogImplement
    {
        private ILog logger;

        public LogImplement(ILog log)
        {
            this.logger = log;
        }

        public void Debug(object message)
        {
            this.logger.Debug(message);
        }

        public void Debug(object message, Exception e)
        {
            this.logger.Debug(message, e);
        }

        public void Warming(object message)
        {
            this.logger.Warn(message);
        }

        public void Warming(object message,Exception e)
        {
            this.logger.Warn(message, e);
        }

        public void Error(object message)
        {
            this.logger.Error(message);
        }

        public void Error(object message, Exception e)
        {
            this.logger.Error(message, e);
        }

        public void Info(object message)
        {
            this.logger.Info(message);
        }

        public void Info(object message, Exception e)
        {
            this.logger.Info(message, e);
        }
    }
}
