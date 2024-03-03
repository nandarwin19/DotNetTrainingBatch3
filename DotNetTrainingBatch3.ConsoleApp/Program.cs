// See https://aka.ms/new-console-template for more information

using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EfCoreExamples;
using DotNetTrainingBatch3.ConsoleApp.HttpClientExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

// F5 => run

// Ctrl + K, C => Disable
// Ctrl + K, C => Enable

// Console.WriteLine();
// F9 => break point
// Shift + F5 => Stop

// Ctrl + .
// checking line by line => f11

// UI, BL, DA

// CRUD

// ntier three tier

// In BL (Business Logic)
// Kpay
// Transfer
// from mobile no
// to mobile no
// amount
// passcode

// In DA (Data Access)
// mobile no (-1000)
// mobile no (+1000)
// from to +1000 date


// We will start to learn how to communiate DA and SQL 

// SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
// sqlConnectionStringBuilder.DataSource = @"DESKTOP-O796GIE\SQLEXPRESS";
// sqlConnectionStringBuilder.InitialCatalog = "TestDb1";
// sqlConnectionStringBuilder.UserID = "sa";
// sqlConnectionStringBuilder.Password = "qqq12";

// Console.WriteLine("Connection: " + sqlConnectionStringBuilder.ConnectionString);

// SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
// Console.WriteLine("Connection Opening........");
// connection.Open();
// Console.WriteLine("Connection Opend!");

// data set => can store more than one table
// data table
// data row
// data column

// string query = @"SELECT [BlogId]
//       ,[BlogTitle]
//       ,[BlogAuthor]
//       ,[BlogContent]
//   FROM [dbo].[Table_1]";
// SqlCommand cmd = new SqlCommand(query, connection); //add to the command
// SqlDataAdapter adapter = new SqlDataAdapter(cmd); 
// DataTable dt = new DataTable();
// adapter.Fill(dt);

// Console.WriteLine("Connection Closing......");
// connection.Close();
// Console.WriteLine("Connection Closed!");

// foreach (DataRow dr in dt.Rows)
// {
//     Console.WriteLine("Title..." + dr["BlogTitle"]);
//     Console.WriteLine("Author..." + dr["BlogAuthor"]);
//     Console.WriteLine("Content.." + dr["BlogContent"]);
// }

// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Edit(id: 2);
// adoDotNetExample.Edit(id: 91);
// adoDotNetExample.Create("test title", "test author", "test content");
// adoDotNetExample.Update(id: 1002, title: "test title 2", author: "test author 2", content: "test content 2");
// adoDotNetExample.Delete(2);

// DapperExample dapperExample = new DapperExample();
// dapperExample.Read();

// dapperExample.Edit(id: 2);
// dapperExample.Edit(id: 91);

//dapperExample.Create("test title", "test author", "test content");
// dapperExample.Update(id: 11, title: "test title 3", author: "test author 3", content: "test content 3");

// EfCoreExample efCoreExample = new EfCoreExample();
// efCoreExample.Read();

// efCoreExample.Edit(id: 3);
// efCoreExample.Edit(11);
// efCoreExample.Create("test title", "test author", "test content");
// efCoreExample.Update(14, "test title 2", "test author 2", "test");
// efCoreExample.Delete(14);

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.Run();
Console.ReadKey();