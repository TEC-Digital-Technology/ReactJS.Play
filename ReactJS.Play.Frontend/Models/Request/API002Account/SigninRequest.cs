using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactJS.Play.Frontend.Models.Request.API002Account
{
    /// <summary>
    /// 處理登入的請求
    /// </summary>
    public class SigninRequest
    {
        /// <summary>
        /// 設定或取得帳號
        /// </summary>
        [Required(ErrorMessage = "1000")]
        public string Account { get; set; }
        /// <summary>
        /// 設定或取得密碼
        /// </summary>
        [Required(ErrorMessage = "1000")]
        public string Password { get; set; }
    }
}
