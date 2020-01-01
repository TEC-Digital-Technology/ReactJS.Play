using Microsoft.Extensions.Logging;
using ReactJS.Play.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactJS.Play.Core.Extensions
{
    /// <summary>
    /// 處理紀錄檔的靜態擴充類別
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// 紀錄偵錯資料
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="logState"></param>
        public static void Log(this ILoggerFactory loggerFactory, LogState logState)
        {
            loggerFactory.CreateLogger(logState.SystemScope.ToString()).Log(logState.LogLevel,
                new EventId(0, logState.MessageType.ToString()), logState, logState.Exception, (state, exception) => state.Message);
        }
    }
}
