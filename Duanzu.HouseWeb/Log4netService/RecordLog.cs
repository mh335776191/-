using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Log4netService
{
    /// <summary>
    /// FileName: RecordLog.cs
    /// CLRVersion: 4.0.30319.17929
    /// Author: 黄继华
    /// Corporation:
    /// Description:
    /// DateTime: 2012/12/10 10:38:30
    /// </summary>
    public  class RecordLog
    {
       private static string Ip = System.Web.HttpContext.Current.Request.UserHostAddress;
       private static string rawUrl = System.Web.HttpContext.Current.Request.RawUrl +"</br>当前请求的Url:"+System.Web.HttpContext.Current.Request.Url.ToString();

       #region 搜索日志
       /// <summary>
       /// 
       /// </summary>
       /// <param name="keyword">关键词</param>
 
       public static void SearchLogs(string value )
       {
           LogImplement log = LogFactory.GetLogger("searchlogs");
           log.Info(value);
       }

       #endregion

       #region 支付日志
       /// <summary>
       /// 
       /// </summary>
       /// <param name="type">类型</param>
       /// <param name="keyword">关键词</param>
       /// <param name="adminId"></param>
       /// <param name="adminName"></param>
       public static void PayPalLogs(string type, string keyword, string adminId, string adminName)
       {
           LogImplement log = LogFactory.GetLogger("paypallogs");
           log.Info(type + ":" + keyword + "," + adminId + "," + adminName);
       }

       #endregion

       #region  关键词访问日志

       /// <summary>
       /// 关键词访问日志
       /// </summary>
       /// <param name="pth">平台号</param>
       /// <param name="hid">房源Id</param>
       /// <param name="hType">房源type</param>
       /// <param name="keyword">关键词</param>
       public static void KeywordsLogs(string pth, string hid, string hType, string keyword)
       {
           LogImplement log = LogFactory.GetLogger("keywordlogs");
           log.Info(pth +","+ hid + "," + hType + "," + keyword);
       }
       #endregion

       #region 记录日志
       /// <summary>
       /// 记录访问日志
       /// </summary>
       /// <param name="hid">房源Id</param>
       /// <param name="uType">房主类别</param>
       /// <param name="area">区域</param>
       /// <param name="sq">商圈</param>
       /// <param name="xq">小区</param>
       /// <param name="uid">房主Id</param>
       /// <param name="browseUid">访问人Id</param>
       /// <param name="browseTime">访问时间</param>
       public static void Logging(string hid, string uType, string area, string sq, string xq, string uid, string browseUid, string browseTime)
       { 
           LogImplement log = LogFactory.GetLogger("loginfo");
           log.Info(hid + "," + uType + "," + area + "," + sq + "," + xq + "," + uid + "," + browseUid + "," + browseTime);
       }
       #endregion

       #region 经纪人操作日志
       /// <summary>
       /// 关键词访问日志
       /// </summary>
       /// <param name="pth">平台号</param>
       /// <param name="hid">房源Id</param>
       /// <param name="hType">房源type</param>
       /// <param name="keyword">关键词</param>
       public static void AgentsLogs(int agentId,int type,int houseId)
       {
           LogImplement log = LogFactory.GetLogger("agentslogs");
           log.Info(agentId + "," + type + "," + houseId);
       }
       #endregion

       #region 无异常情况下 记录log
       /// <summary>
        ///  无异常情况下 记录log
        /// </summary>
        /// <param name="realname">真实姓名</param>
        /// <param name="message">消息说明</param>
        public static void RecordException(string realname,string message)
        {
            LogImplement log = LogFactory.GetLogger("logerror");
            log.Error("处理人:" + realname + "</br>未出异常情况：" + message + "</br>请求客户端IP:" + Ip + "</br>请求原始Url:" + rawUrl);
        }
        #endregion

       #region 记录异常2
        /// <summary>
        ///  记录异常2
        /// </summary>
        /// <param name="realName">处理人姓名 (各自的写的代码异常处理调用该方法)</param>
        /// <param name="param"> 传入参数[多个参数 按照传入顺序一次拼接格式如下(a,b,c,d) ] 无参数传null</param>
        /// ///  <param name="e">Exception</param>
        public static void RecordException(string realName,string param,Exception e)
        {
            LogImplement log = LogFactory.GetLogger("logerror");
            string str =String.IsNullOrEmpty(param)? "" : "传入参数:" + param + "<br/>";
            log.Error("处理人" + ":" + realName + "<br/>" + str + e.Message + e.StackTrace + "</br>请求客户端IP:" + Ip + "</br>请求原始Url:" + rawUrl); 
        }
        #endregion

       #region 记录异常 多参数传参数实体
         /// <summary>
        ///  记录异常2
        /// </summary>
        /// <param name="realName">处理人姓名 (各自的写的代码异常处理调用该方法)</param>
        /// <param name="param">实体</param>
        /// ///  <param name="e">Exception</param>
        public static void RecordException<T>(string realName,T mode,Exception e)
        {
             LogImplement log = LogFactory.GetLogger("logerror");
             StringBuilder sb = new StringBuilder();
             object value=null;
            if(mode!=null){               
                foreach (PropertyInfo pi in typeof(T).GetProperties())
                {
                    value = pi.GetValue(mode, null);
                    sb.Append(pi.Name + ":" + (value == null?"":value.ToString()));
                }
            }
            log.Error("处理人" + ":" + realName + "<br/>" + sb.ToString() + e.Message + e.StackTrace + "</br>请求客户端IP:" + Ip + "</br>请求原始Url:" + rawUrl);
        }
        #endregion

        #region
        /// <summary>
        /// 记录异常日志 
        /// </summary>
        /// <param name="loger">需要加载的loger节点，需要确认配置文件中有该节点 <logger name=**></param>
        /// <param name="logcontent">日志的内容</param>
        public static void RecordCustomErrorLogs(string loger, string logcontent)
        {
            LogImplement log = LogFactory.GetLogger(loger);
            log.Error(logcontent);
        }

        /// <summary>
        /// 记录日志 
        /// </summary>
        /// <param name="loger">需要加载的loger节点，需要确认配置文件中有该节点 <logger name=**></param>
        /// <param name="logcontent">日志的内容</param>
        public static void RecordCustomInfoLogs(string loger, string logcontent)
        {
            LogImplement log = LogFactory.GetLogger(loger);
            log.Info(logcontent);
        }
        #endregion
    }
}
