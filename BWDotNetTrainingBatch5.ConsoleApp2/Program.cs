// See https://aka.ms/new-console-template for more information

using DotNetTrainingBatch5.Database.Models;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
var lts = db.TblBlogs.ToList();
foreach (var item in lts)
{
    Console.WriteLine(item.BlogId);
    Console.WriteLine(item.BlogTitle);
    Console.WriteLine(item.BlogAuthor);
    Console.WriteLine(item.BlogContent);
}