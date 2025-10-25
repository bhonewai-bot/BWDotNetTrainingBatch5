using BWDotNetTrainingBatch5.ConsoleApp.Models;
using BWDotNetTrainingBatch5.Shared;

namespace BWDotNetTrainingBatch5.ConsoleApp;

public class DapperExample2
{
    private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=true;";
    private readonly DapperService _dapperService;

    public DapperExample2()
    {
        _dapperService = new DapperService(_connectionString);
    }

    public void Read()
    {
        string query = @"
        SELECT 
            BlogId,
            BlogTitle,
            BlogAuthor,
            BlogContent
        FROM Tbl_Blog
        WHERE DeleteFlag = 0";

        var lts = _dapperService.Query<BlogDapperDataModel>(query);

        foreach (var item in lts)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
    }

    public void Edit(int id)
    {
        string query = @"
        SELECT 
            BlogId,
            BlogTitle,
            BlogAuthor,
            BlogContent
        FROM Tbl_Blog
        WHERE BlogId = @BlogId";

        var item = _dapperService.QueryFirstOrDefault<BlogDapperDataModel>(query, new BlogDapperDataModel()
        {
            BlogId = id
        });

        if (item is null)
        {
            Console.WriteLine("No data found");
            return;
        }

        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }

    public void Create(string title, string author, string content)
    {
        string query = @"
        INSERT INTO Tbl_Blog (
            BlogTitle,
            BlogAuthor,
            BlogContent,
            DeleteFlag
        ) VALUES (
            @BlogTitle,
            @BlogAuthor,
            @BlogContent,
            0
        )";
        
        int result = _dapperService.Execute(query, new BlogDapperDataModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        });

        Console.WriteLine(result > 0 ? "Saving successful" : "Saving failed");
    }

    public void Update(int id, string title, string author, string content)
    {
        string query = @"
        UPDATE tbl_blog SET
            BlogTitle = @BlogTitle,
            BlogAuthor = @BlogAuthor,
            BlogContent = @BlogContent,
            DeleteFlag = 0
        WHERE BlogId = @BlogId";

        int result = _dapperService.Execute(query, new BlogDapperDataModel()
        {
            BlogId = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        });

        Console.WriteLine(result > 0 ? "Updating successful" : "Updating failed");
    }

    public void Delete(int id)
    {
        string query = @"DELETE FROM tbl_blog WHERE BlogId = @BlogId";

        int result = _dapperService.Execute(query, new BlogDapperDataModel()
        {
            BlogId = id
        });
        
        Console.WriteLine(result > 0 ? "Deleting successful" : "Deleting failed");
    }
}