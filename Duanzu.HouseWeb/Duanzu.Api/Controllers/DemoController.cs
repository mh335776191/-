using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Duanzu.Api.Controllers
{
    public class DemoController : ApiController
    {


        // GET: api/Product
        public IEnumerable<string> Get()
        {
            //     $.get("http://api.duanzu.com/api/Demo", {  }, function (data) {
            //    alert(data);
            //})
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            //    $.get("http://api.duanzu.com/api/Demo", { id: "11111" }, function (data) {
            //    alert(data);
            //})
            return "value" + id;
        }

        // POST: api/Product 前台请求的json串格式 {"":'11111'}
        public string Post([FromBody]string value)
        {
            //     $.post("http://api.duanzu.com/api/Demo", { "": "11111" }, function (data) {
            //    alert(data);
            //})
            ///Web API 要求请求传递的 [FromBody] 参数，肯定是有一个特定的格式，才能被正确的获取到。而这种特定的格式并不是我们常见的 key=value 的键值对形式。Web API 的模型绑定器希望找到 [FromBody] 里没有键名的值，也就是说， 不是 key=value ，而是 =value 
            return value;
        }

        // PUT: api/Product/5
        public string Put(int id, [FromBody]string value)
        {
            return "更新id：" + id + "更新实体：" + value;
        }

        // DELETE: api/Product/5
        public string Delete(int id)
        {
            return "删除id:" + id;
        }
        public string Options()
        {

            return null; // HTTP 200 response with empty body

        }

        //http://www.cnblogs.com/babycool/p/3922738.html
    }
}
