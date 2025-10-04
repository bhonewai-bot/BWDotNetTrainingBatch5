using System.Data;
using System.Data.SqlClient;

namespace BWDotNetTrainingBatch5.ConsoleApp;

public class AdoDotNetExample
{
    private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
    
    public void Read()
    {
        Console.WriteLine("Connection opening...");
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        Console.WriteLine("Connection opened");

        string query = @"SELECT
            BlogId,
            BlogTitle,
            BlogAuthor,
            BlogContent,
            DeleteFlag
        FROM Tbl_Blog WHERE DeleteFlag = 0";

        SqlCommand cmd = new SqlCommand(query, connection);
        // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        // DataTable dt = new DataTable();
        // adapter.Fill(dt);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader["BlogId"]);
            Console.WriteLine(reader["BlogTitle"]);
            Console.WriteLine(reader["BlogAuthor"]);
            Console.WriteLine(reader["BlogContent"]);
            // Console.WriteLine(reader["DeleteFlag"]);
        }

        /*foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
            Console.WriteLine(dr["DeleteFlag"]);
        }*/

        connection.Close();
        Console.WriteLine("Connection Closed");
        
        /*foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
            Console.WriteLine(dr["DeleteFlag"]);
        }*/
    }

    public void Create()
    {
        Console.Write("Blog Title:");
        string title = Console.ReadLine();

        Console.Write("Blog Author:");
        string author = Console.ReadLine();

        Console.Write("Blog Content:");
        string content = Console.ReadLine();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        /*string queryString2 = $@"INSERT INTO Tbl_Blog (
                BlogTitle,
                BlogAuthor,
                BlogContent,
                DeleteFlag
            ) VALUES (
                '{title}',
                '{author}',
                '{content}',
                0
            )";*/

                string queryString2 = @"INSERT INTO Tbl_Blog (
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

        SqlCommand cmd = new SqlCommand(queryString2, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        Console.WriteLine(result == 1 ? "Saving successfully." : "Saving failed");
    }

    public void Edit()
    {
        Console.Write("Blog Id:");
        string id = Console.ReadLine();
        
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = @"SELECT 
            BlogId,
            BlogTitle,
            BlogAuthor,
            BlogContent,
            DeleteFlag
        FROM Tbl_Blog WHERE BlogId = @BlogId";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No data found");
        }

        DataRow dr = dt.Rows[0];
        Console.WriteLine(dr["BlogId"]);
        Console.WriteLine(dr["BlogTitle"]);
        Console.WriteLine(dr["BlogAuthor"]);
        Console.WriteLine(dr["BlogContent"]);
        
        connection.Close();
    }

    public void Update()
    {
        Console.Write("Blog Id:");
        string id = Console.ReadLine();
        
        Console.Write("Blog Title:");
        string title = Console.ReadLine();
        
        Console.Write("Blog Author:");
        string author = Console.ReadLine();
        
        Console.Write("Blog Content:");
        string content = Console.ReadLine();
        
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();


        string query = @"UPDATE Tbl_Blog SET 
            BlogTitle = @BlogTitle,
            BlogAuthor = @BlogAuthor,
            BlogContent = @BlogContent,
            DeleteFlag = 0
        WHERE BlogId = @BlogId";
        
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);
        
        int result = cmd.ExecuteNonQuery();
        
        connection.Close();

        Console.WriteLine(result == 1 ? "Updating successfully." : "Updating failed.");
    }

    public void Delete()
    {
        Console.Write("Blog Id:");
        string id = Console.ReadLine();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);

        int result = cmd.ExecuteNonQuery();
        
        connection.Close();

        Console.WriteLine(result == 1 ? "Deleting successfully." : "Deleting failed.");
    }

    public void SoftDelete()
    {
        Console.Write("Blog Id:");
        string id = Console.ReadLine();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = @"UPDATE Tbl_Blog SET
            DeleteFlag = 1
            WHERE BlogId = @BlogId";
        
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        
        int result = cmd.ExecuteNonQuery();
        
        connection.Close();

        Console.WriteLine(result == 1 ? "Soft delete successfully." : "Soft delete failed.");
    }
}