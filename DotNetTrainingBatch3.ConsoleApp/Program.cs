// See https://aka.ms/new-console-template for more information
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
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.InitialCatalog = "TestDb1";

string query = "select * from tb_blog";
SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString); // build a connection
sqlConnection.Open();

SqlCommand cmd = new SqlCommand(query,sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);

DataTable dt = new DataTable();
adapter.Fill(dt);
sqlConnection.Close();

// dataset
// datatable
// Datarow
// DataColumn

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}


Console.ReadKey();