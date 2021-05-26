using FrontDeskApp.ViewModels.Login.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Interface.Login
{
    public interface ILogin
    {
        public string CreateLogin(CreateLoginRequest createLoginRequest);
    }
}
