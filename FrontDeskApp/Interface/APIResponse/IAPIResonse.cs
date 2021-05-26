using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Interface.APIResponse
{
    public interface IAPIResonse
    {
        public object GetSuccessMessage(object obj);

        public object GetFailedMessage(object obj);

        public object GetSuccessMessage();

        public object GetFailedMessage();

        public object PostSuccessMessage(object obj);

        public object PostFailedMessage(object obj);

        public object PostInvalidDataMessage(object obj);

        public object PostSuccessMessage();

        public object PostFailedMessage();

        public object InvalidApiKeyMessage();

        public object UnauthorizedUserMessage();
    }
}
