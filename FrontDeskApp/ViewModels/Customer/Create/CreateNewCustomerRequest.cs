using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.ViewModels.Customer.Create
{
    public class CreateNewCustomerRequest
    {
        public Guid SessionGuid { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "FirstName cannot be longer than 25 characters"), MinLength(6, ErrorMessage = "FirstName cannot be less than 6 characters")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
