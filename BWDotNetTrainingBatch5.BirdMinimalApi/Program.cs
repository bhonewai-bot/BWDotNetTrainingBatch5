using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/birds", () =>
{
    string folderPath = "Data/Birds.json";
    string jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);
    return Results.Ok(result?.Tbl_Bird); 
})
.WithName("GetBirds")
.WithOpenApi();

app.MapGet("/birds/${id}", (int id) =>
{
    string folderPath = "Data/Birds.json";
    string jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);
    var item = result?.Tbl_Bird.FirstOrDefault(b => b.Id == id);
    if (item is null)
    {
        return Results.BadRequest("No Bird found");
    }
    return Results.Ok(item); 
})
.WithName("GetBird")
.WithOpenApi();

app.Run();

public class BirdResponseModel
{
    public BirdModel[] Tbl_Bird { get; set; }
}

public class BirdModel
{
    public int Id { get; set; }
    public string BirdMyanmarName { get; set; }
    public string BirdEnglishName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}

