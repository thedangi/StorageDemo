using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDeskApp.EntityDataModel
{
    public partial class CustomerInfo
    {
        public int CustomerInfoId { get; set; }
        public Guid CustomerGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
