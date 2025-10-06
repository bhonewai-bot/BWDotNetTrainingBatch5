using System.Data;
using System.Data.SqlClient;
using BWDotNetTrainingBatch5.ConsoleApp.Models;
using Dapper;

namespace BWDotNetTrainingBatch5.ConsoleApp;

public class DapperExample
{
    private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123";
    
    /*public void Read()
    {
        IDbConnection db = new SqlConnection(_connectionString);

        string query = "SELECT * FROM Tbl_Blog WHERE DeleteFlag = 0";
        var lts = db.Query(query).ToList();

        foreach (var item in lts)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
    }*/
    
    public void Read()
    {
        IDbConnection db = new SqlConnection(_connectionString);

        string query = "SELECT * FROM Tbl_Blog WHERE DeleteFlag = 0";
        var lts = db.Query<BlogDataModel>(query).ToList();

        foreach (var item in lts)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
    }

    public void Create(string title, string author, string content)
    {
        string query = @"INSERT INTO tbl_blog (
                BlogTitle,
                BlogAuthor,
                BlogContent
            ) VALUES (
                @BlogTitle,
                @BlogAuthor,
                @BlogContent
            )";
        
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            int result = db.Execute(query, new BlogDataModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            });

            Console.WriteLine(result == 1 ? "Saving successfully." : "Saving failed.");
        }
    }

    public void Edit(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            string query = @"SELECT * FROM tbl_blog WHERE DeleteFlag = 0 AND BlogId = @BlogId";
            
            var item = db.Query<BlogDataModel>(query, new BlogDataModel()
            {
                BlogId = id
            }).FirstOrDefault();

            if (item == null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
    }

    public void Update(int id, string title, string author, string content)
    {
        string query = @"UPDATE tbl_blog SET
            BlogTitle = @BlogTitle,
            BlogAuthor = @BlogAuthor,
            BlogContent = @BlogContent,
            DeleteFlag = 0
        WHERE BlogId = @BlogId";

        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            int result = db.Execute(query, new BlogDataModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            });

            Console.WriteLine(result == 1 ? "Updating successfully." : "Updating failed.");
        }
    }

    public void Delete(int id)
    {
        string query = @"DELETE FROM tbl_blog WHERE BlogId = @BlogId";

        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            int result = db.Execute(query, new BlogDataModel()
            {
                BlogId = id
            });

            Console.WriteLine(result == 1 ? "Deleting successfully." : "Deleting failed.");
        }
    }
}