using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactJS.Play.Core.Exceptions;
using ReactJS.Play.Frontend.Models.Request.API001Test;
using ReactJS.Play.Frontend.Models.Response.API001Test;

namespace ReactJS.Play.Frontend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class API001TestController : ControllerBase
    {
        /// <summary>
        /// 處理您的資料
        /// </summary>
        /// <param name="handleSomeDataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public HandleSomeDataResponse HandleSomeData(HandleSomeDataRequest handleSomeDataRequest)
        {
            //throw new Exception(); //return FFFF
            //throw new OperationFailedException(Utils.Enums.ResultCodeSettingEnum.InvalidRange); // return 1001
            return new HandleSomeDataResponse()
            {
                YourId = Guid.NewGuid().ToString()
            };
        }
    }
}