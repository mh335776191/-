using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Duanzu.Controller.Controllers
{
    public class BaseController : System.Web.Mvc.Controller
    {
        protected bool IsLogin
        {
            get
            {
                HttpCookie privateAuthCookie = Request.Cookies[Duanzu.TXCommons.BasicsClass.PubConstant.PrivateCookie];

                if (privateAuthCookie != null)
                {
                    string userData = privateAuthCookie.Value;
                    string[] arr = Duanzu.TXCommons.BasicsClass.ForKuaiYouJiaCookie.ForKuaiYouJiaCookie.RC4Decrypt(userData).Split(';');

                    string userId = arr[0];
                    int uid = 0;
                    int.TryParse(userId, out uid);
                    if (uid == 0) return false;
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 获取当前用户的ID
        /// </summary>
        protected int GetUserId
        {
            get
            {
                HttpCookie cookies = Request.Cookies[TXCommons.BasicsClass.PubConstant.PrivateCookie];
                if (cookies == null)
                {
                    return 0;
                }
                string data = cookies.Value;
                string[] arr = TXCommons.BasicsClass.ForKuaiYouJiaCookie.ForKuaiYouJiaCookie.RC4Decrypt(data).Split(';');
                return Convert.ToInt32(arr[0]);
            }
        }
    }
}
