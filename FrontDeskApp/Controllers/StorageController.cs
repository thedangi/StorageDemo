using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDeskApp.Interface.APIResponse;
using FrontDeskApp.Interface.Logging;
using FrontDeskApp.Interface.Storage;
using FrontDeskApp.ViewModels.Storage.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly ILogging loggingService;

        private readonly IAPIResonse apiResponseService;

        private readonly IStorage storageService;

        public StorageController(IStorage storage, ILogging logging, IAPIResonse iAPIResponse)
        {
            storageService = storage;

            loggingService = logging;

            apiResponseService = iAPIResponse;
        }

        [HttpGet]
        [Route("GetStorageLocations")]
        public IActionResult GetStorageLocations(Guid SessionGuid)
        {
            //validate session

            var response = storageService.GetStorageLocations();

            if (response != null)
            {
                return StatusCode(200, apiResponseService.GetSuccessMessage(response));
            }

            return StatusCode(200, apiResponseService.GetFailedMessage("Failed to get data"));
        }

        [HttpGet]
        [Route("GetStorageList")]
        public IActionResult GetStorageList(int storageLocationID)
        {
            //validate session

            var response = storageService.GetStorageList(storageLocationID);

            if (response != null)
            {
                return StatusCode(200, apiResponseService.GetSuccessMessage(response));
            }

            return StatusCode(200, apiResponseService.GetFailedMessage("Failed to get data"));
        }

        [HttpGet]
        [Route("GetStorageType")]
        public IActionResult GetStorageType()
        {
            //validate session

            var response = storageService.GetStorageType();

            if (response != null)
            {
                return StatusCode(200, apiResponseService.GetSuccessMessage(response));
            }

            return StatusCode(200, apiResponseService.GetFailedMessage("Failed to get data"));
        }

        [HttpGet]
        [Route("GetStorageListByCustomer")]
        public IActionResult GetStorageListByCustomer(int customerInfoID)
        {
            //validate session

            var response = storageService.GetStorageListByCustomer(customerInfoID);

            if (response != null)
            {
                return StatusCode(200, apiResponseService.GetSuccessMessage(response));
            }

            return StatusCode(200, apiResponseService.GetFailedMessage("Failed to get data"));
        }

        [HttpPost]
        [Route("AssignStorageToCustomer")]
        public IActionResult AssignStorageToCustomer(CreateStorageToCustomerRequest request)
        {

            var response = storageService.AssignStorageToCustomer(request.CustomerInfoID, request.StorageID);

            if (response != string.Empty)
            {
                return StatusCode(200, apiResponseService.PostSuccessMessage());
            }

            return StatusCode(200, apiResponseService.PostFailedMessage("Failed"));
        }

        [HttpPost]
        [Route("AddStorageToStorageLocation")]
        public IActionResult AddStorageToStorageLocation(CreateNewStorageRequest request)
        {

            var response = storageService.AddStorageToStorageLocation(request);

            if (response != string.Empty)
            {
                return StatusCode(200, apiResponseService.PostSuccessMessage());
            }

            return StatusCode(200, apiResponseService.PostFailedMessage("Failed"));
        }

        [HttpPost]
        [Route("UnAssignAllCustomers")]
        public IActionResult UnAssignAllCustomers()
        {

            var response = storageService.UnAssignAllCustomers();

            if (response != string.Empty)
            {
                return StatusCode(200, apiResponseService.PostSuccessMessage());
            }

            return StatusCode(200, apiResponseService.PostFailedMessage("Failed"));
        }
    }
}
