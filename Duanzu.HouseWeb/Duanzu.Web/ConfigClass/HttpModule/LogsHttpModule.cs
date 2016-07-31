using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Duanzu.Web.ConfigClass.HttpModule
{
    public class LogsHttpModule : IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            StringBuilder visitsb = new StringBuilder();
            if (application != null)
            {
                var request = application.Request;
                if (request != null)
                {
                    visitsb.AppendFormat("开始请求 IP:{0}{1}", request.UserHostName + " " + request.UserHostAddress, Environment.NewLine);
                    visitsb.AppendFormat("请求URL:{0}{1}", request.Url, System.Environment.NewLine);
                    visitsb.AppendFormat("请求参数:{0}", System.Environment.NewLine);
                    var requestparam = request.Params;
                    if (requestparam != null)
                    {
                        foreach (string paramkey in requestparam.AllKeys)
                        {
                            visitsb.AppendFormat("{0}=\"{1}\" {2} ", paramkey, requestparam[paramkey], System.Environment.NewLine);
                        }
                    }
                }
            }
            Log4netService.RecordLog.RecordCustomInfoLogs("websitlogs", visitsb.ToString());
        }
        private void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            StringBuilder visitsb = new StringBuilder();
            if (application != null)
            {

                var request = application.Request;
                if (request != null)
                {
                    visitsb.AppendFormat("结束请求 IP:{0}{1}", request.UserHostName + " " + request.UserHostAddress, Environment.NewLine);
                }
                Log4netService.RecordLog.RecordCustomInfoLogs("websitlogs", visitsb.ToString());
            }
        }
        #endregion
    }
}