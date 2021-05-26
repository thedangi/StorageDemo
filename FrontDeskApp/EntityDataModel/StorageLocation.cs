using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDeskApp.EntityDataModel
{
    public partial class StorageLocation
    {
        public int StorageLocationId { get; set; }
        public string LocationName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Deleted { get; set; }
    }
}
