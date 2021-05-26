using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Interface.Configurations
{
    public interface IDatabaseConn
    {
        public string GetStorageDBConnString();
    }
}
