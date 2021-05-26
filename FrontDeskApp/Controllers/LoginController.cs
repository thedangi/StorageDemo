using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDeskApp.Interface.APIResponse;
using FrontDeskApp.Interface.Logging;
using FrontDeskApp.Interface.Login;
using FrontDeskApp.ViewModels.Login.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogging loggingService;

        private readonly IAPIResonse apiResponseService;

        private readonly ILogin loginService;

        public LoginController(ILogin login, ILogging logging, IAPIResonse aPIResonse)
        {
            loggingService = logging;

            apiResponseService = aPIResonse;

            loginService = login;
        }

        [HttpPost]
        [Route("CreateLogin")]
        public IActionResult CreateLogin(CreateLoginRequest request)
        {

            var response = loginService.CreateLogin(request);

            if (response != string.Empty)
            {
                return StatusCode(200, apiResponseService.PostSuccessMessage("Login Success!"));
            }

            return StatusCode(200, apiResponseService.PostFailedMessage("Failed to LogIn"));
        }
    }
}
