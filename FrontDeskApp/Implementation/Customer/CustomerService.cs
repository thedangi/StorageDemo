using FrontDeskApp.EntityDataModel;
using FrontDeskApp.Interface.Customer;
using FrontDeskApp.Interface.Logging;
using FrontDeskApp.ViewModels.Customer.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Implementation.Customer
{
    public class CustomerService : ICustomer
    {
        private readonly StorageContext dbConn;

        private readonly ILogging loggingService;

        public CustomerService(StorageContext context, ILogging logging)
        {
            dbConn = context;

            loggingService = logging;
        }

        public string AddNewCustomer(CreateNewCustomerRequest createNewCustomerRequest)
        {
            try
            {
                var customer = dbConn.CustomerInfos.Where(x => x.Email == createNewCustomerRequest.Email).FirstOrDefault();

                if(customer == null)
                {
                    CustomerInfo customerInfo = new CustomerInfo
                    {
                        CustomerGuid = Guid.NewGuid(),

                        FirstName = createNewCustomerRequest.FirstName,

                        LastName = createNewCustomerRequest.LastName,

                        Email = createNewCustomerRequest.Email,

                        Phone = Int64.Parse(createNewCustomerRequest.Phone),

                        Address = createNewCustomerRequest.Address,

                        Deleted = false
                    };

                    dbConn.CustomerInfos.Add(customerInfo);

                    dbConn.SaveChanges();

                    return "Customer Added Successfully.";
                }
            }
            catch(Exception ex)
            {
                loggingService.ExceptionLogging(ex.ToString(), "Failed to add new customer");
            }

            return string.Empty;
        }

        public object GetCustomerList()
        {
            return dbConn.CustomerInfos.Where(x => x.Deleted == false).ToList();
        }
    }
}
