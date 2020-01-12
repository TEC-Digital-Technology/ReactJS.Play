using System;
using System.Collections.Generic;
using System.Text;
using TEC.Core.ComponentModel;

namespace ReactJS.Play.Utils.Enums
{
    /// <summary>
    /// 紀錄的訊息類型
    /// </summary>
    [DescriptiveEnumEnforcement(EnforcementType = DescriptiveEnumEnforcementAttribute.EnforcementTypeEnum.ThrowException)]
    public enum LoggingMessageType : short
    {
        /// <summary>
        /// 一般訊息
        /// </summary>
        [EnumDescription("一般訊息")]
        General = 0x0000,

        #region 第三方 HTTP (0x01XX)

        /// <summary>
        /// 第三方HTTP請求
        /// </summary>
        [EnumDescription("第三方HTTP請求")]
        ThirdPartyHttpRequest = 0x0100,
        /// <summary>
        /// 第三方HTTP回應
        /// </summary>
        [EnumDescription("第三方HTTP回應")]
        ThirdPartyHttpResponse = 0x0101,
        /// <summary>
        /// 第三方HTTP錯誤
        /// </summary>
        [EnumDescription("第三方HTTP錯誤")]
        ThirdPartyHttpError = 0x0102,

        #endregion

        #region 第三方 SOAP (0x020X)

        /// <summary>
        /// 第三方SOAP請求
        /// </summary>
        [EnumDescription("第三方SOAP請求")]
        ThirdPartySoapRequest = 0x0200,
        /// <summary>
        /// 第三方SOAP回應
        /// </summary>
        [EnumDescription("第三方SOAP回應")]
        ThirdPartySoapResponse = 0x0201,
        /// <summary>
        /// 第三方SOAP錯誤
        /// </summary>
        [EnumDescription("第三方SOAP錯誤")]
        ThirdPartySoapError = 0x0202,

        #endregion


        #region Web API (0x030X)

        /// <summary>
        /// Web API 請求
        /// </summary>
        [EnumDescription("WebAPI 請求")]
        WebApiRequest = 0x0300,
        /// <summary>
        /// Web API 回應
        /// </summary>
        [EnumDescription("WebAPI 回應")]
        WebApiResponse = 0x0301,
        /// <summary>
        /// Web API 錯誤
        /// </summary>
        [EnumDescription("WebAPI 錯誤")]
        WebApiError = 0x0302,

        #endregion

        #region 資料 (0x040X)

        /// <summary>
        /// 使用 UIData 新增資料
        /// </summary>
        [EnumDescription("UIData新增資料")]
        UIDataAddData = 0x0400,
        /// <summary>
        /// 使用 UIData 修改資料
        /// </summary>
        [EnumDescription("UIData修改資料")]
        UIDataModifyData = 0x0401,
        /// <summary>
        /// 使用 UIData 刪除資料
        /// </summary>
        [EnumDescription("UIData刪除資料")]
        UIDataDeleteData = 0x0402,

        #endregion
    }
}
