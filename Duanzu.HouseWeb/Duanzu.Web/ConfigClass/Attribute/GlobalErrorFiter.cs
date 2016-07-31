using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Duanzu.Web.ConfigClass.Attribute
{
    /// <summary>
    /// 应用程序异常记录处理
    /// </summary>
    public class GlobalErrorFiter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            StringBuilder errorsb = new StringBuilder();
            Exception ex = filterContext.Exception;
            errorsb.AppendFormat("异常是否处理:{0}<br/>", filterContext.ExceptionHandled);
            //filterContext.ExceptionHandled = true;
            if (ex != null)
            {
                errorsb.AppendFormat("异常信息:{0}<br/>{1}", ex.Message, ex.StackTrace);
            }
            var httpcontext = filterContext.HttpContext;
            if (httpcontext != null)
            {
                var request = httpcontext.Request;
                if (request != null)
                {
                    errorsb.AppendFormat("请求URL:{0}<br/>", request.Url);
                    errorsb.AppendFormat("请求参数: <br/>");
                    var requestparam = request.Params;
                    if (requestparam != null)
                    {
                        foreach (string paramkey in requestparam.AllKeys)
                        {
                            errorsb.AppendFormat("{0}=\"{1}\" *** ", paramkey, requestparam[paramkey]);
                        }
                    }
                }
            }
            Log4netService.RecordLog.RecordCustomErrorLogs("globallogerror", errorsb.ToString());
            base.OnException(filterContext);
        }
    }
}