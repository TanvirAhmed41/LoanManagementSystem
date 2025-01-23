using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.Models
{
    public static class DatabaseTest
    {
        public static bool TestConnection()
        {
            string connectionString = @"Server=(LocalDb)\MSSQLLocalDB;Database=LoanManagementDB;Trusted_Connection=True;";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Database Connected successfully!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }




    }

}