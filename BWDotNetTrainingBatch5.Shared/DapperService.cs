using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace BWDotNetTrainingBatch5.Shared;

public class DapperService
{
    private readonly string _connectionString;

    public DapperService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<T> Query<T>(string query, object? param = null)
    {
        Console.WriteLine("Query is: " + query);
        using IDbConnection db = new SqlConnection(_connectionString);
        var lts = db.Query<T>(query, param).ToList();
        return lts;
    }

    public T QueryFirstOrDefault<T>(string query, object? param = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        var item = db.QueryFirstOrDefault<T>(query, param);
        return item!;
    }

    public int Execute(string query, object? param = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        int result = db.Execute(query, param);
        return result;
    }
}