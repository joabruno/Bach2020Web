using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BachelorsProjectWebApp.Models
{
    public class DBMapper
    {
        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = BachOfflineDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void AddOffice()
        {
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                var sql = "INSERT INTO Beacons(BeaconID, BuildingNumber) VALUES(@BeaconID, @BuildingNumber)";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@BeaconID", "FirstBeacon");
                    cmd.Parameters.AddWithValue("@BuildingNumber", 5);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}