using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=wipro training;TrustServerCertificate=True; Integrated Security=True";

    using (SqlConnection connection = new SqlConnection(connectionString)) {
        connection.Open();

        SqlCommand cmd = new SqlCommand("select * from employee where age=21", connection);
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Name: {reader["Name"]}, Age: {reader["Age"]}");
    }
        Console.WriteLine("Connection Opend successfully.");

        connection.Close();
        Console.WriteLine("connection Closed");
        }