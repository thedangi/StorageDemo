using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.ViewModels.APIResponse
{
    public class APIResponseMessage
    {
        public int statuscode { get; set; }

        public string message { get; set; }

        public object body { get; set; }
    }
}
