// See https://aka.ms/new-console-template for more information

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

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = @"DESKTOP-O796GIE\SQLEXPRESS";
sqlConnectionStringBuilder.InitialCatalog = "TestDb1";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "qqq12";

Console.WriteLine("Connection: " + sqlConnectionStringBuilder.ConnectionString);

SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
Console.WriteLine("Connection Opening........");
connection.Open();
Console.WriteLine("Connection Opend!");

Console.WriteLine("Connection Closing......");
connection.Close();
Console.WriteLine("Connection Closed!");



Console.ReadKey();