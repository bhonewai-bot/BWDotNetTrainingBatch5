using BWDotNetTrainingBatch5.Domain.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BWDotNetTrainingBatch5.MinimalApi.Endpoints.Blog;

public static class BlogServiceEndpoint
{
    public static void UseBlogServiceEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/blogs", ([FromServices] IBlogService service) =>
        {
            var lts = service.GetBlogs();
            return Results.Ok(lts);
        })
        .WithName("GetBlogs")
        .WithOpenApi();
        
        app.MapGet("/blogs/{id}", ([FromServices] IBlogService service, int id) =>
        {
            var item = service.GetBlog(id);
            if (item is null)
            {
                return Results.BadRequest("No data found"); 
            }

            return Results.Ok(item);
        })
        .WithName("GetBlog")
        .WithOpenApi();
        
        app.MapPost("/blogs", ([FromServices] IBlogService service, TblBlog blog) =>
        {
            var model = service.CreateBlog(blog);

            return Results.Ok(model);
        })
        .WithName("CreateBlog")
        .WithOpenApi();

        app.MapPut("/blogs/{id}", ([FromServices] IBlogService service, int id, TblBlog blog) =>
        {
            var item = service.UpdateBlog(id, blog);
            if (item is null)
            {
                return Results.BadRequest("No data found"); 
            }

            return Results.Ok(item);
        })
        .WithName("UpdateBlog")
        .WithOpenApi();

        app.MapPatch("/blogs/{id}", ([FromServices] IBlogService service, int id, TblBlog blog) =>
        {
            var item = service.PatchBlog(id, blog);
            if (item is null)
            {
                return Results.BadRequest("No data found");
            }

            return Results.Ok(item);
        })
        .WithName("PatchBlog")
        .WithOpenApi();
        
        app.MapDelete("/blogs/{id}", ([FromServices] IBlogService service, int id) =>
        {
            var item = service.DeleteBlog(id);
            if (item is null)
            {
                return Results.BadRequest("No data found");
            }

            return Results.Ok();
        })
        .WithName("DeleteBlog")
        .WithOpenApi();
    }
}