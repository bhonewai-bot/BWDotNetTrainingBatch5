using DotNetTrainingBatch5.Database.Models;

namespace BWDotNetTrainingBatch5.Domain.Features;

public interface IBlogService
{
    List<TblBlog> GetBlogs();
    TblBlog GetBlog(int id);
    TblBlog CreateBlog(TblBlog blog);
    TblBlog UpdateBlog(int id, TblBlog blog);
    TblBlog PatchBlog(int id, TblBlog blog);
    bool? DeleteBlog(int id);
}