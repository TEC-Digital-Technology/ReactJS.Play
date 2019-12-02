using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactJS.Play.Core.Exceptions;
using ReactJS.Play.Frontend.Models.Request.API002Account;
using ReactJS.Play.Frontend.Models.Response.API002Account;

namespace ReactJS.Play.Frontend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class API002AccountController : ControllerBase
    {
        [HttpPost]
        public SigninResponse Signin(SigninRequest signinRequest)
        {
            System.Threading.Thread.Sleep(1500);
            if (signinRequest.Account != "admin" || signinRequest.Password != "admin")
            {
                throw new OperationFailedException(Utils.Enums.ResultCodeSettingEnum.InvalidAccountOrPassword);
            }
            return new SigninResponse()
            {
                AccessToken = Guid.NewGuid().ToString()
            };
        }
    }
}