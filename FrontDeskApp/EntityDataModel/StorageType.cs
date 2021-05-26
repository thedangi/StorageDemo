using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDeskApp.EntityDataModel
{
    public partial class StorageType
    {
        public int StorageTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
