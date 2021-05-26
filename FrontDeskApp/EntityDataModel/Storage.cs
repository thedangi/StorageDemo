using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDeskApp.EntityDataModel
{
    public partial class Storage
    {
        public int StorageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StorageLocationId { get; set; }
        public int CustomerInfoId { get; set; }
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Deleted { get; set; }
        public int StorageTypeId { get; set; }
        public decimal Price { get; set; }
        public int StoreIdentifier { get; set; }
    }
}
