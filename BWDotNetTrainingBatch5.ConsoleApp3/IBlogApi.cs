using Refit;

namespace BWDotNetTrainingBatch5.ConsoleApp3;

public interface IBlogApi
{
    [Get("/api/blogs")]
    Task<List<BlogModel>> GetBlogs();

    [Get("/api/blogs/{id}")]
    Task<BlogModel> GetBlog(int id);

    [Post("/api/blogs")]
    Task<BlogModel> CreateBlog(BlogModel blogModel);
    
    [Put("/api/blogs/{id}")]
    Task<BlogModel> UpdateBlog(int id, BlogModel blogModel);

    [Delete("/api/blogs/{id}")]
    Task<ApiResponse<string>> DeleteBlog(int id);
}

public class BlogModel
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool? DeleteFlag { get; set; }
}