using FrontDeskApp.EntityDataModel;
using FrontDeskApp.Interface.Configurations;
using FrontDeskApp.Interface.Logging;
using FrontDeskApp.Interface.Storage;
using FrontDeskApp.ViewModels.Storage.Create;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Implementation.Storage
{
    public class StorageService : IStorage
    {
        private readonly StorageContext dbConn;

        private readonly ILogging loggingService;

        private readonly IDatabaseConn databaseConnService;

        public StorageService(StorageContext context, ILogging logging, IDatabaseConn databaseConn)
        {
            dbConn = context;

            loggingService = logging;

            databaseConnService = databaseConn;
        }

        public string AddStorageToStorageLocation(CreateNewStorageRequest createNewStorageRequest)
        {
            try
            {
                var store = dbConn.Storages.Where(x => x.StoreIdentifier == createNewStorageRequest.StoreIdentifier && x.StorageLocationId == 1).FirstOrDefault();

                var storagetype = dbConn.StorageTypes.Where(x => x.StorageTypeId == createNewStorageRequest.StorageTypeID).FirstOrDefault();

                if(store == null)
                {
                    FrontDeskApp.EntityDataModel.Storage storage = new EntityDataModel.Storage
                    {
                        Name = storagetype.Name,

                        Description = storagetype.Description,

                        StorageLocationId = 1,

                        CustomerInfoId = 0,

                        StorageTypeId = createNewStorageRequest.StorageTypeID,

                        Price = createNewStorageRequest.Price,

                        StoreIdentifier = createNewStorageRequest.StoreIdentifier
                    };

                    dbConn.Add(storage);

                    dbConn.SaveChanges();

                    return "Added Successfully";
                }
            }
            catch (Exception ex)
            {
                loggingService.ExceptionLogging(ex.ToString(), "Exception");
            }

            return string.Empty;
        }

        public string AssignStorageToCustomer(int CustomerInfoID, int StorageID)
        {
            try
            {
                var storage = dbConn.Storages.Where(x => x.StorageId == StorageID).FirstOrDefault();

                if(storage != null)
                {
                    storage.CustomerInfoId = CustomerInfoID;

                    storage.Status = "UnAvailable";

                    dbConn.Update(storage);

                    dbConn.SaveChanges();

                    return "Successfully Assigned";
                }
            }
            catch (Exception ex)
            {
                loggingService.ExceptionLogging(ex.ToString(), "Exception");
            }

            return string.Empty;
        }

        public object GetStorageList(int StorageLocationID)
        {
            return dbConn.Storages.Where(x => x.Deleted == false && x.StorageLocationId == StorageLocationID).ToList();
        }

        public object GetStorageListByCustomer(int CustomerInfoID)
        {
            return dbConn.Storages.Where(x => x.CustomerInfoId == CustomerInfoID && x.Deleted == false).ToList();
        }

        public object GetStorageLocations()
        {
            return dbConn.StorageLocations.Where(x => x.Deleted == false).ToList();
        }

        public object GetStorageType()
        {
            return dbConn.StorageTypes.ToList();
        }

        public string UnAssignAllCustomers()
        {
            //use database conn for this service

            try
            {
                using (SqlConnection conn = new SqlConnection(databaseConnService.GetStorageDBConnString()))
                {
                    string ProcName = @"dbo.[Update_UnAssignAllCustomers]";

                    SqlCommand cmd = new SqlCommand(ProcName, conn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                }

                return "Success";
            }
            catch (Exception ex)
            {

            }

            return string.Empty;
        }
    }
}
