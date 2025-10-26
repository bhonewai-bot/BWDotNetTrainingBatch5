// See https://aka.ms/new-console-template for more information

using DotNetTrainingBatch5.Database.Models;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var blog = new BlogModel()
{
    Id = 1,
    Title = "Dutchie",
    Author = "Bhone Wai",
    Content = "Yogurt",
};

string jsonStr = blog.ToJson();
Console.WriteLine(jsonStr);

string jsonStr2 = """{"Id":1,"Title":"Dutchie","Author":"Bhone Wai","Content":"Yogurt"}""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);
Console.WriteLine(blog2.Title);

public class BlogModel
{
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Author { get; set; }
    
    public string? Content { get; set; }
}

public static class Extensions
{
    public static string ToJson(this object obj)
    {
        string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return jsonStr;
    }
}