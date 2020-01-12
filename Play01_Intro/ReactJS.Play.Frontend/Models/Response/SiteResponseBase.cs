using Microsoft.AspNetCore.Http;
using ReactJS.Play.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEC.Core.Web.WebApi.Response;
using ReactJS.Play.Frontend.Messaging;

namespace ReactJS.Play.Frontend.Models.Response
{
    /// <summary>
    /// Web Api使用的回應基底型別
    /// </summary>
    public abstract class SiteResponseBase : ResponseBase<ResultCodeSettingEnum>
    {
        /// <summary>
        /// 使用ResponseConfig.ResultCodeDefinition所設定的預設訊息初始化回應物件(目前UI語系)
        /// </summary>
        public SiteResponseBase()
        {
            
        }
    }
}
