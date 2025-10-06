using System.Reflection;
using BWDotNetTrainingBatch5.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BWDotNetTrainingBatch5.ConsoleApp;

public class EFCoreExample
{
    public void Read()
    {
        AppDbContext db = new AppDbContext();
        var lts = db.Blogs.Where(x => x.DeleteFlag == false ).ToList();

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
        BlogDataModel blog = new BlogDataModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        
        AppDbContext db = new AppDbContext();
        db.Blogs.Add(blog);

        var result = db.SaveChanges();

        Console.WriteLine(result == 1 ? "Saving successfully." : "Saving failed.");
    }

    public void Edit(int id)
    {
        AppDbContext db = new AppDbContext();
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

        if (item == null)
        {
            Console.WriteLine("Data not found.");
            return;
        }

        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }

    public void Update(int id, string title, string author, string content)
    {
        AppDbContext db = new AppDbContext();
        var item = db.Blogs
            .AsNoTracking()
            .FirstOrDefault(x => x.BlogId == id);

        if (item == null)
        {
            Console.WriteLine("Data not found.");
            return;
        }

        if (!string.IsNullOrEmpty(title))
        {
            item.BlogTitle = title;
        }

        if (!string.IsNullOrEmpty(author))
        {
            item.BlogAuthor = author;
        }

        if (!string.IsNullOrEmpty(content))
        {
            item.BlogContent = content;
        }

        db.Entry(item).State = EntityState.Modified;

        var result = db.SaveChanges();
        Console.WriteLine(result == 1 ? "Updating successfully." : "Updating failed.");
    }

    public void Delete(int id)
    {
        AppDbContext db = new AppDbContext();
        var item = db.Blogs
            .AsNoTracking()
            .FirstOrDefault(x => x.BlogId == id);

        if (item == null)
        {
            Console.WriteLine("Data not found.");
            return;
        }
        
        db.Entry(item).State = EntityState.Deleted;

        var result = db.SaveChanges();

        Console.WriteLine(result == 1 ? "Deleting successfully." : "Deleting failed.");
    }
}