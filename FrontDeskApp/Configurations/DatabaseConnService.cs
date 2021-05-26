using FrontDeskApp.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Configurations
{
    public class DatabaseConnService : IDatabaseConn
    {
        public string GetStorageDBConnString()
        {
            string connectionString = @"Server=tcp:storagedemo.c8dnwyshrrsm.us-east-2.rds.amazonaws.com,1433;Initial Catalog=Storage;User ID=Admin;Password=StorageDemo;Trusted_Connection=false;";

            return connectionString;
        }
    }
}
