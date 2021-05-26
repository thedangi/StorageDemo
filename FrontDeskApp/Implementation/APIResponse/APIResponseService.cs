using FrontDeskApp.Interface.APIResponse;
using FrontDeskApp.ViewModels.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Implementation.APIResponse
{
    public class APIResponseService : IAPIResonse
    {
        public object GetFailedMessage(object obj)
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 211,

                message = "Failed to get data",

                body = obj
            };

            return responseMessage;
        }

        public object GetFailedMessage()
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 211,

                message = "Failed to get data",

                body = null
            };

            return responseMessage;
        }

        public object GetSuccessMessage(object obj)
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 201,

                message = "success",

                body = obj
            };

            return responseMessage;
        }

        public object GetSuccessMessage()
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 201,

                message = "success",

                body = null
            };

            return responseMessage;
        }

        public object InvalidApiKeyMessage()
        {
            throw new NotImplementedException();
        }

        public object PostFailedMessage(object obj)
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 212,

                message = "failed to create new record",

                body = obj
            };

            return responseMessage;
        }

        public object PostFailedMessage()
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 212,

                message = "failed to create new record",

                body = null
            };

            return responseMessage;
        }

        public object PostInvalidDataMessage(object obj)
        {
            throw new NotImplementedException();
        }

        public object PostSuccessMessage(object obj)
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 202,

                message = "successfully created",

                body = obj
            };

            return responseMessage;
        }

        public object PostSuccessMessage()
        {
            APIResponseMessage responseMessage = new APIResponseMessage()
            {
                statuscode = 202,

                message = "success",

                body = null
            };

            return responseMessage;
        }

        public object UnauthorizedUserMessage()
        {
            throw new NotImplementedException();
        }
    }
}
