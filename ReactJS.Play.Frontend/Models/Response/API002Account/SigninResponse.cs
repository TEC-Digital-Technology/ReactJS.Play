using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactJS.Play.Frontend.Models.Response.API002Account
{
    public class SigninResponse : SiteResponseBase
    {
        /// <summary>
        /// 設定或取得 AccessToken
        /// </summary>
        public string AccessToken { get; set; }
    }
}
