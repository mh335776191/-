using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Net;
using System.Text;
using System.Reflection;
using System.Web.Caching;
using System.Xml;
 

namespace TXHouseBid.Controllers
{
    public class AjaxController : System.Web.Mvc.Controller
    { 
        #region 下载文件并上传到指定页面
        public ActionResult UploadFile()
        {
            string urlstr = Duanzu.TXCommons.BasicsClass.PubConstant.ImgUploadBaseUrl;//"http://localhost:8959/TXImages/";
            var uploadurl = urlstr+"RentHouse/Upload.ashx";
            Dictionary<string, string> inputDic = new Dictionary<string, string>();
            inputDic.Add("para", Request["para"]);
            //inputDic.Add("password", "123456");
            var files = Request.Files;
            //var file = Request.Files["Filedata"];
            string result = PostFile(files[0].InputStream, uploadurl, files[0].FileName, "application/octet-stream", inputDic);
            return Content(result);
        }

        /**
         * 如果要在客户端向服务器上传文件，我们就必须模拟一个POST multipart/form-data类型的请求
         * Content-Type必须是multipart/form-data。
         * 以multipart/form-data编码的POST请求格式与application/x-www-form-urlencoded完全不同
         * multipart/form-data需要首先在HTTP请求头设置一个分隔符,例如7d4a6d158c9：
         * 我们模拟的提交要设定 content-type不同于非含附件的post时候的content-type
         * 这里需要： ("Content-Type", "multipart/form-data; boundary=ABCD");
         * 然后，将每个字段用“--7d4a6d158c9”分隔，最后一个“--7d4a6d158c9--”表示结束。
         * 例如，要上传一个title字段"Today"和一个文件C:\1.txt，HTTP正文如下：
         * 
         * --7d4a6d158c9
         * Content-Disposition: form-data; name="title"
         * \r\n\r\n
         * Today
         * --7d4a6d158c9
         * Content-Disposition: form-data; name="1.txt"; filename="C:\1.txt"
         * Content-Type: text/plain
         * 如果是图片Content-Type: application/octet-stream
         * \r\n\r\n
         * <这里是1.txt文件的内容>
         * --7d4a6d158c9
         * \r\n
         * 请注意，每一行都必须以\r\n结束value前面必须有2个\r\n，包括最后一行。
        */
        /// <summary>
        /// 下载文件上传到指定地址
        /// </summary>
        /// <param name="getUrl">文件下载地址</param>
        /// <param name="postUrl">文件上传地址</param>
        /// <param name="fileName">file控件名称</param>
        /// <param name="fileType">上传文件类型</param>
        /// <param name="inputParamter">其他表单元素</param>
        public string PostFile(Stream uploadMs, string postUrl, string fileName, string fileType, Dictionary<string, string> inputDic)
        {
            Stream fileStream = uploadMs;//下载文件返回内存流
            // cast the WebRequest to a HttpWebRequest since we're using HTTPS 
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");//元素分割标记
            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(postUrl);
            //httpWebRequest2.Credentials = cache;
            //httpWebRequest2.CookieContainer = cookies;
            httpWebRequest2.ContentType = "multipart/form-data; boundary=" + boundary;//其他地方的boundary要比这里多--
            httpWebRequest2.Method = "POST";//Post请求方式
            // Build up the post message 拼接创建表单内容 
            StringBuilder sb = new StringBuilder();
            //拼接非文件表单控件
            //遍历字典取出表单普通空间的健和值
            foreach (KeyValuePair<string, string> dicItem in inputDic)
            {
                sb.Append("--" + boundary);
                sb.Append("\r\n");
                sb.Append("Content-Disposition: form-data; name=\"" + dicItem.Key + "\"");
                sb.Append("\r\n");
                sb.Append("\r\n");
                sb.Append(dicItem.Value);//value前面必须有2个换行
                sb.Append("\r\n");
            }
            //拼接文件控件
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"Filedata\"; filename=\"C:\\upload" + Path.GetFileName(fileName) + "\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");//value前面必须有2个换行
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sb.ToString());
            // Build the trailing boundary string as a byte array 创建结束标记
            // ensuring the boundary appears on a line by itself 
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            //http请求总长度
            httpWebRequest2.ContentLength = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            Stream requestStream = httpWebRequest2.GetRequestStream(); //定义一个http请求流
            // Write out our post header 将开始标记写入流
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            // Write out the file contents 将附件写入流,最大4M
            byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);
            
            // Write out the trailing boundary 将结束标记写入流
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            fileStream.Dispose();
            //Send http request back WebResponse 发送http请求
            WebResponse webResponse2 = httpWebRequest2.GetResponse();
            //从WebResponse中解析出html代码开始
            Stream htmlStream = webResponse2.GetResponseStream();
            string HTML = GetHtml(htmlStream, "UTF-8");
            htmlStream.Dispose();
            //从WebResponse中解析出html代码结束
            return HTML;
        }

        /// <summary>
        /// 从html流中解析出html代码
        /// </summary>
        /// <param name="htmlStream">html流</param>
        /// <param name="Encoding">编码格式</param>
        /// <returns>html</returns>
        public string GetHtml(Stream htmlStream, string Encoding)
        {
            StreamReader objReader = new StreamReader(htmlStream, System.Text.Encoding.GetEncoding(Encoding));
            string HTML = "";
            string sLine = "";
            int i = 0;
            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    HTML += sLine;
            }
            HTML = HTML.Replace("<", "<");
            HTML = HTML.Replace(">", ">");
            objReader.Dispose();
            return HTML;
        }
        #endregion
    }

}
