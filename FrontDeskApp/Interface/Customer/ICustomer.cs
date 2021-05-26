using FrontDeskApp.ViewModels.Customer.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Interface.Customer
{
    public interface ICustomer
    {
        public object GetCustomerList();

        public string AddNewCustomer(CreateNewCustomerRequest createNewCustomerRequest);
    }
}
