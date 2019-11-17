using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TEC.Core.DataAnnotations;

namespace ReactJS.Play.Frontend.Models.Request.API001Test
{
    public class HandleSomeDataRequest
    {
        /// <summary>
        /// 設定或取得姓名
        /// </summary>
        [Required(ErrorMessage = "1000")]
        public string Name { set; get; }
        /// <summary>
        /// 設定或取得感興趣的內容
        /// </summary>
        [ItemRequired(ErrorMessage = "1002")]
        public string[] InterestedIn { set; get; }
    }
}
