using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.ViewModels.Storage.Create
{
    public class CreateStorageToCustomerRequest
    {
        public int CustomerInfoID { get; set; }
        
        public int StorageID { get; set; }

    }
}
