// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";

Console.WriteLine("Connection opening...");
SqlConnection connection = new SqlConnection(connectionString);
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