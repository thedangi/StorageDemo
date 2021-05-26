using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDeskApp.Interface.APIResponse;
using FrontDeskApp.Interface.Customer;
using FrontDeskApp.Interface.Logging;
using FrontDeskApp.ViewModels.Customer.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer customerService;

        private readonly ILogging loggingService;

        private readonly IAPIResonse apiResponseService;

        public CustomerController(ICustomer customer, ILogging logging, IAPIResonse iAPIResponse)
        {
            customerService = customer;

            loggingService = logging;

            apiResponseService = iAPIResponse;
        }

        [HttpGet]
        [Route("GetCustomerList")]
        public IActionResult GetCustomerList(Guid SessionGuid)
        {
            //validate session

            var response = customerService.GetCustomerList();

            if(response != null)
            {
                return StatusCode(200, apiResponseService.GetSuccessMessage(response));
            }

            return StatusCode(200, apiResponseService.GetFailedMessage("Failed to get data"));
        }

        [HttpPost]
        [Route("AddNewCustomer")]
        public IActionResult AddNewCustomer(CreateNewCustomerRequest request)
        {

            var response = customerService.AddNewCustomer(request);

            if(response != string.Empty)
            {
                return StatusCode(200, apiResponseService.PostSuccessMessage());
            }

            return StatusCode(200, apiResponseService.PostFailedMessage("Failed"));
        }
    }
}
