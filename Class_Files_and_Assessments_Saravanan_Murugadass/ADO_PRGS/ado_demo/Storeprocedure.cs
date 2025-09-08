using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.Pkcs;
using Microsoft.Data.SqlClient;

namespace storeprocedure
{

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WiproDB;TrustServerCertificate=True; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlCommand cmd = new SqlCommand("disempbyid", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@age", 25);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine($"RollNo: {reader["RollNo"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
                }
                else
                {
                    Console.WriteLine("No Records found for the given age.");
                }
            }
        }
    }

}