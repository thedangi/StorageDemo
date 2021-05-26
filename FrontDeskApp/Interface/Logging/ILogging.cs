using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Interface.Logging
{
    public interface ILogging
    {
        public void ExceptionLogging(String Exception, String ExceptionMessage);

        public void InformationLogging(String Exception, String DetailedMessage);
    }
}
