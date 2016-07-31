using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Duanzu.Api.Controllers
{
    public class BasicDataController : ApiController
    {
        /// <summary>
        /// /api/BasicData/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SelectListItem> GetCityByID(int id)
        {
            var cityList = GetCityList(id);
            return cityList;
        }

        #region 获取城市
        private List<SelectListItem> GetCityList(int id)
        {
            var areas = new List<SelectListItem>();
            areas.Add(new SelectListItem() { Text = "选择城市", Value = "0" });
            areas.Add(new SelectListItem() { Text = "北京", Value = "253" });
            areas.Add(new SelectListItem() { Text = "上海", Value = "239" });
            var list = areas.Where(it => it.Value == it.ToString()).ToList();
            return list;
        }
        #endregion
    }
}
