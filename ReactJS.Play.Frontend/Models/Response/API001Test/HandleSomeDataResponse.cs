using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactJS.Play.Frontend.Models.Response.API001Test
{
    public class HandleSomeDataResponse: SiteResponseBase
    {
        /// <summary>
        /// 設定或取得要回傳的 ID
        /// </summary>
        public string YourId { set; get; }
    }
}
