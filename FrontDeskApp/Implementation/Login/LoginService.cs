using FrontDeskApp.Interface.Login;
using FrontDeskApp.ViewModels.Login.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Implementation.Login
{
    public class LoginService : ILogin
    {
        public string CreateLogin(CreateLoginRequest createLoginRequest)
        {
            if(createLoginRequest.Username == "admin@gmail.com" && createLoginRequest.Password == "admin")
            {
                return "Login Success";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
