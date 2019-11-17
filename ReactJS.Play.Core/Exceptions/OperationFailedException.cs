using ReactJS.Play.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TEC.Core.Web.WebApi.Exceptions;

namespace ReactJS.Play.Core.Exceptions
{
    /// <summary>
    /// 當系統操作發生錯誤時所擲出的例外
    /// </summary>
    public class OperationFailedException : ResultCodeException<ResultCodeSettingEnum>
    {
        /// <summary>
        /// 使用指定的錯誤代碼和造成這個例外狀況原因的內部例外參考，初始化 <see cref="OperationFailedException"/> 類別的新執行個體
        /// </summary>
        /// <param name="resultCodeSettingEnum">解釋例外狀況原因的錯誤代碼列舉</param>
        /// <param name="innerException">造成目前例外狀況的例外狀況，若未指定內部例外狀況，則為 <c>null</c> 參考 (Visual Basic 中為 Nothing)</param>
        /// <param name="data">關於此例外的相關參數</param>
        /// <param name="cultureInfo">與此例外相關的文化特性，若輸入<c>null</c>時則會使用<see cref="System.Threading.Thread.CurrentThread"/>的<see cref="System.Threading.Thread.CurrentUICulture"/></param>
        public OperationFailedException(ResultCodeSettingEnum resultCodeSettingEnum, Exception innerException, Dictionary<string, object> data = null, CultureInfo cultureInfo = null)
            : base(resultCodeSettingEnum, innerException, data, cultureInfo)
        {
        }

        /// <summary>
        /// 使用指定的錯誤代碼，初始化 <see cref="OperationFailedException"/> 類別的新執行個體
        /// </summary>
        /// <param name="resultCodeSettingEnum">解釋例外狀況原因的錯誤代碼列舉</param>
        /// <param name="data">關於此例外的相關參數</param>
        /// <param name="cultureInfo">與此例外相關的文化特性，若輸入<c>null</c>時則會使用[Thread.CurrentThread]的[Thread.CurrentUICulture]</param>
        public OperationFailedException(ResultCodeSettingEnum resultCodeSettingEnum, Dictionary<string, object> data = null, CultureInfo cultureInfo = null) :
            base(resultCodeSettingEnum, null, data, cultureInfo)
        {
        }
    }
}
