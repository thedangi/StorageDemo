using FrontDeskApp.ViewModels.Storage.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Interface.Storage
{
    public interface IStorage
    {
        public object GetStorageLocations();

        public object GetStorageList(int StorageLocationID);

        public object GetStorageType();

        public object GetStorageListByCustomer(int CustomerInfoID);

        public string AssignStorageToCustomer(int CustomerInfoID, int StorageID);

        public string AddStorageToStorageLocation(CreateNewStorageRequest createNewStorageRequest);

        public string UnAssignAllCustomers();
    }
}
