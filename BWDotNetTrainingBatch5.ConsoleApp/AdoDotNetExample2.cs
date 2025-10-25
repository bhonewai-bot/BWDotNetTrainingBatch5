using System.Data;
using BWDotNetTrainingBatch5.Shared;

namespace BWDotNetTrainingBatch5.ConsoleApp;

public class AdoDotNetExample2
{
    private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
    private readonly AdoDotNetService _adoDotNetService;

    public AdoDotNetExample2()
    {
        _adoDotNetService = new AdoDotNetService(_connectionString);
    }

    public void Read()
    {
        string query = @"
        SELECT 
            BlogId,
            BlogTitle,
            BlogAuthor,
            BlogContent
        FROM TblBlogs
        WHERE DeleteFlag = 0";
        
        var dt = _adoDotNetService.Query(query);
        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }
    }

    public void Edit()
    {
        Console.Write("Blog Id:");
        string id = Console.ReadLine()!;
        
        string query = @"
        SELECT 
            BlogId, 
            BlogTitle, 
            BlogAuthor, 
            BlogContent
        FROM TblBlogs
        WHERE BlogId = @BlogId";

        /*SqlParameterModel[] sqlParameters = new SqlParameterModel[1];
        sqlParameters[0] = new SqlParameterModel()
        {
            Name = "@BlogId",
            Value = id,
        };*/

        var dt = _adoDotNetService.Query(query, 
            new SqlParameterModel("@BlogId", id)
        );

        DataRow dr = dt.Rows[0];
        Console.WriteLine(dr["BlogId"]);
        Console.WriteLine(dr["BlogTitle"]);
        Console.WriteLine(dr["BlogAuthor"]);
        Console.WriteLine(dr["BlogContent"]);
    }

    public void Create()
    {
        Console.Write("Blog Title:");
        string title = Console.ReadLine()!;
        
        Console.Write("Blog Author:");
        string author = Console.ReadLine()!;
        
        Console.Write("Blog Content:");
        string content = Console.ReadLine()!;
        
        string query = @"
        INSERT INTO TblBlogs (
            BlogTitle, 
            BlogAuthor, 
            BlogContent
        ) VALUES (
            @BlogTitle,
            @BlogAuthor,
            @BlogContent
        )";

        int result = _adoDotNetService.Execute(query, 
            new SqlParameterModel("@BlogTitle", title),
            new SqlParameterModel("@BlogAuthor", author),
            new SqlParameterModel("@BlogContent", content)
        );

        Console.WriteLine(result > 0 ? "Saving successful" : "Saving failed");
    }

    public void Update()
    {
        Console.Write("Blog Id:");
        string id = Console.ReadLine()!;
        
        Console.Write("Blog Title:");
        string title = Console.ReadLine()!;
        
        Console.Write("Blog Author:");
        string author = Console.ReadLine()!;
        
        Console.Write("Blog Content:");
        string content = Console.ReadLine()!;
        
        string query = @"
        UPDATE TblBlog SET
            BlogTitle = @BlogTitle,
            BlogAuthor = @BlogAuthor,
            BlogContent = @BlogContent
        WHERE BlogId = @BlogId";

        int result = _adoDotNetService.Execute(query, 
            new SqlParameterModel("@BlogId", id),
            new SqlParameterModel("BlogTitle", title),
            new SqlParameterModel("@BlogAuthor", author),
            new SqlParameterModel(@"BlogContent", content)
        );

        Console.WriteLine(result > 0 ? "Updating successful" : "Updating failed");
    }

    public void Delete()
    {
        Console.Write("Blog Id:");
        string id = Console.ReadLine()!;

        string query = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";
        
        int result = _adoDotNetService.Execute(query, new SqlParameterModel("@BlogId", id));

        Console.WriteLine(result > 0 ? "Deleting successful" : "Deleting failed");
    }
}