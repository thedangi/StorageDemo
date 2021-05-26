using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.ViewModels.Storage.Create
{
    public class CreateNewStorageRequest
    {
        public Guid SessionGuid { get; set; }

        public int StorageTypeID { get; set; }

        public int StoreIdentifier { get; set; }

        public decimal Price { get; set; }

    }
}
