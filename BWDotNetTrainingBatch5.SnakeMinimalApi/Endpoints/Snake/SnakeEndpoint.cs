using Newtonsoft.Json;

namespace BWDotNetTrainingBatch5.SnakeMinimalApi.Endpoints.Snake;

/*
public static class SnakeEndpoint
{
    public static void UseSnakeEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/snakes", () =>
        {
            string folderPath = "Data/Snakes.json";
            string jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<List<SnakeModel>>(jsonStr);
            return Results.Ok(result);
        })
        .WithName("GetSnakes")
        .WithOpenApi();
    }
}

public class SnakeModel
{
    public int Id { get; set; }
    public string MMName { get; set; }
    public string EngName { get; set; }
    public string Detail { get; set; }
    public string IsPoison { get; set; }
    public string IsDanger { get; set; }
}
*/

public static class SnakeEndpoint
{
    public static void UseSnakeEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/snakes", () =>
        {
            string folderPath = "Data/Snakes.json";
            string jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<List<SnakeResponseModel>>(jsonStr);
            return Results.Ok(result);
        })
        .WithName("GetSnakes")
        .WithOpenApi();

        app.MapGet("/snakes/${id}", (int id) =>
        {
            string folderPath = "Data/Snakes.json";
            string jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<List<SnakeResponseModel>>(jsonStr);
            
            var snake = result?.FirstOrDefault(s => s.Id == id);
            if (snake is null)
            {
                return Results.BadRequest("Data not found");
            }
            
            return Results.Ok(snake);
        })
        .WithName("GetSnake")
        .WithOpenApi();
    }
}

public class SnakeResponseModel
{
    public int Id { get; set; }
    public string MMName { get; set; }
    public string EngName { get; set; }
    public string Detail { get; set; }
    public string IsPoison { get; set; }
    public string IsDanger { get; set; }
}