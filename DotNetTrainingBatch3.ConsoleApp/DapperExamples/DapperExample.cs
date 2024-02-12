using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetTrainingBatch3.ConsoleApp.Models;

namespace DotNetTrainingBatch3.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = @"DESKTOP-O796GIE\SQLEXPRESS",
            InitialCatalog = "TestDb1",
            UserID = "sa",
            Password = "qqq12",
        };

        public void Read()  // if we use "void", we don't need to return 
        {
            string query = @"SELECT [BlogId]
                    ,[BlogTitle]
                    ,[BlogAuthor]
                    ,[BlogContent]
                FROM [dbo].[Table_1]";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent );
            }

        }

        public void Edit(int id)
        {
            // Define the SQL query with the parameter placeholder @BlogId
            string query = @"SELECT [BlogId]
                 ,[BlogTitle]
                 ,[BlogAuthor]
                 ,[BlogContent]
               FROM [dbo].[Table_1] 
               Where BlogId = @BlogId"; // the difference between {id} and @BlogId
                                        // @BlogId is preferred over {id} for clarity and security

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            // var item = db.Query<BlogModel>(query, new {BlogId = id}).FirstOrDefault();
            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();
            // if(item === null) 
            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {

            // Define the SQL query with the parameter placeholder @BlogId
            string query = @"INSERT INTO[dbo].[Table_1]
           ([BlogTitle]
           , [BlogAuthor]
           , [BlogContent])
     VALUES
           (@BlogTitle
           , @BlogAuthor
           , @BlogContent)"; // the difference between {id} and @BlogId
                             // @BlogId is preferred over {id} for clarity and security

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
           
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
           

            // Define the SQL query with the parameter placeholder @BlogId
            string query = @"UPDATE [dbo].[Table_1]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId"; // the difference between {id} and @BlogId
                          // @BlogId is preferred over {id} for clarity and security

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
         
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {

            string query = @"Delete from [dbo].[Table_1] WHERE BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            Console.WriteLine(message);
        }
    }
}
