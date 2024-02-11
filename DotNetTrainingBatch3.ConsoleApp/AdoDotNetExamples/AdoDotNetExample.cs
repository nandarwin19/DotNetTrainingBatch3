using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()  // if we use "void", we don't need to return 
        {
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

            // data set => can store more than one table
            // data table
            // data row
            // data column

            string query = @"SELECT [BlogId]
                    ,[BlogTitle]
                    ,[BlogAuthor]
                    ,[BlogContent]
                FROM [dbo].[Table_1]";
            SqlCommand cmd = new SqlCommand(query, connection); //add to the command
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("Connection Closing......");
            connection.Close();
            Console.WriteLine("Connection Closed!");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Title..." + dr["BlogTitle"]);
                Console.WriteLine("Author..." + dr["BlogAuthor"]);
                Console.WriteLine("Content.." + dr["BlogContent"]);
            }

        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"DESKTOP-O796GIE\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb1";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "qqq12";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            // Define the SQL query with the parameter placeholder @BlogId
            string query = @"SELECT [BlogId]
                 ,[BlogTitle]
                 ,[BlogAuthor]
                 ,[BlogContent]
               FROM [dbo].[Table_1] 
               Where BlogId = @BlogId"; // the difference between {id} and @BlogId
                                        // @BlogId is preferred over {id} for clarity and security

            // Create a new SqlCommand object with the query and connection
            SqlCommand cmd = new SqlCommand(query, connection); //add to the command

            cmd.Parameters.AddWithValue("@BlogId", id);

            // Create a new SqlDataAdapter to execute the command and fill a DataTable
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // Create a new DataTable to store the retrieved data
            DataTable dt = new DataTable();

            // Fill the DataTable with data from the database using the data adapter
            adapter.Fill(dt);



            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found."); return; // Adding 'return' prevents the execution of subsequent code
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine("Title..." + dr["BlogTitle"]);
            Console.WriteLine("Author..." + dr["BlogAuthor"]);
            Console.WriteLine("Content.." + dr["BlogContent"]);
        }

        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"DESKTOP-O796GIE\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb1";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "qqq12";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            // Define the SQL query with the parameter placeholder @BlogId
            string query = @"INSERT INTO[dbo].[Table_1]
           ([BlogTitle]
           , [BlogAuthor]
           , [BlogContent])
     VALUES
           (@BlogTitle
           , @BlogAuthour
           , @BlogContent)"; // the difference between {id} and @BlogId
                                        // @BlogId is preferred over {id} for clarity and security

            // Create a new SqlCommand object with the query and connection
            SqlCommand cmd = new SqlCommand(query, connection); //add to the command

            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthour", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();


            connection.Close();

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            string message2 = "";
            if(result > 0)
            {
                message2 = "Saving Successful.";
            } else
            {
                message2 = "Saving Failed";
            }
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"DESKTOP-O796GIE\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb1";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "qqq12";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            // Define the SQL query with the parameter placeholder @BlogId
            string query = @"UPDATE [dbo].[Table_1]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId"; // the difference between {id} and @BlogId
                             // @BlogId is preferred over {id} for clarity and security

            // Create a new SqlCommand object with the query and connection
            SqlCommand cmd = new SqlCommand(query, connection); //add to the command
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();


            connection.Close();

             string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            // string message2 = "";
            // if (result > 0)
            // {
            // message2 = "Saving Successful.";
            // }
            // else
            // {
            // message2 = "Saving Failed";
            // }
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"DESKTOP-O796GIE\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb1";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "qqq12";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

         
            string query = @"Delete from [dbo].[Table_1] WHERE BlogId = @BlogId"; 
            SqlCommand cmd = new SqlCommand(query, connection); 
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();


            connection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            // string message2 = "";
            // if (result > 0)
            // {
            // message2 = "Saving Successful.";
            // }
            // else
            // {
            // message2 = "Saving Failed";
            // }
            Console.WriteLine(message);
        }
    }
}
