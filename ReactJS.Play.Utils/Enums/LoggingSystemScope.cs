using System;
using System.Collections.Generic;
using System.Text;
using TEC.Core.ComponentModel;

namespace ReactJS.Play.Utils.Enums
{
    /// <summary>
    /// 記錄檔所發生的系統，預設為 <see cref="LoggingSystemScope.Local"/>
    /// </summary>
    [DescriptiveEnumEnforcement(EnforcementType = DescriptiveEnumEnforcementAttribute.EnforcementTypeEnum.ThrowException)]
    public enum LoggingSystemScope : byte
    {
        /// <summary>
        /// 本地系統，非第三方系統都屬於此種系統
        /// </summary>
        [EnumDescription("本地")]
        Local = 1,
        /// <summary>
        /// 雲騰
        /// </summary>
        [EnumDescription("TEC")]
        TEC = 2
    }
}
