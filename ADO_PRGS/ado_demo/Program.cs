// using System;
// using System.Data;
// using System.Data.SqlClient;
// using Microsoft.Data.SqlClient;


// string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WiproDB;TrustServerCertificate=True; Integrated Security=True";

// using (SqlConnection connection = new SqlConnection(connectionString))
// {
//     connection.Open();

//     DataTable T1 = new DataTable("customer");
//     T1.Columns.Add("custid", typeof(int));
//     T1.Columns.Add("custname", typeof(string));
//     T1.Columns.Add("custsalary", typeof(int));
//     T1.Rows.Add(101, "John", 5000);
//     T1.Rows.Add(102, "Jane", 6000);
//     T1.Rows.Add(103, "Doe", 7000);

//     DataTable T2 = new DataTable("orders");
//     T2.Columns.Add("orderid", typeof(int));
//     T2.Columns.Add("custid", typeof(int));
//     T2.Columns.Add("orderdate", typeof(DateTime));
//     T2.Rows.Add(1, 101, DateTime.Now);
//     T2.Rows.Add(2, 102, DateTime.Now.AddDays(-1));
//     T2.Rows.Add(3, 103, DateTime.Now.AddDays(-2));
//     T2.Rows.Add(4, 104, DateTime.Now.AddDays(-3));
//     T2.Rows.Add(5, 105, DateTime.Now.AddDays(-4));
//     T2.Rows.Add(6, 106, DateTime.Now.AddDays(-5));
//     T2.Rows.Add(7, 107, DateTime.Now.AddDays(-6));

//     DataSet ds = new DataSet();

//     ds.Tables.Add(T1);
//     ds.Tables.Add(T2);


//     foreach (DataTable t in ds.Tables)
//     {

//         Console.WriteLine($"--- Table : {t.TableName} ---");

//         foreach (DataColumn column in t.Columns)
//         {

//             Console.Write($"{column.ColumnName}\t");

//         }
//         Console.WriteLine();

//         foreach (DataRow row in t.Rows)
//         {
//             foreach (var item in row.ItemArray)
//             {
//                 Console.Write($"{item}\t");
//             }
//             Console.WriteLine();
//         }

//     } 
// }
    