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

// app.MapControllers();

app.MapGet("/pick-a-pile/questions", () =>
{
    string folderPath = "Data/PickAPile.json";
    string jsonStr = File.ReadAllText(folderPath);

    var result = JsonConvert.DeserializeObject<PickAPileResponseModel>(jsonStr);
    return Results.Ok(result?.Questions); 
});

app.MapGet("/pick-a-pile/questions/{id}", (int id) =>
{
    string folderPath = "Data/PickAPile.json";
    string jsonStr = File.ReadAllText(folderPath);

    var result = JsonConvert.DeserializeObject<PickAPileResponseModel>(jsonStr);
    var question = result?.Questions.FirstOrDefault(x => x.QuestionId == id);
    if (question is null)
    {
        return Results.BadRequest("Question not found");
    }
    return Results.Ok(question); 
});

app.MapGet("/pick-a-pile/answers", () =>
{
    string folderPath = "Data/PickAPile.json";
    string jsonStr = File.ReadAllText(folderPath);

    var result = JsonConvert.DeserializeObject<PickAPileResponseModel>(jsonStr);
    return Results.Ok(result?.Answers);
});

app.MapGet("/pick-a-pile/answers/{id}", (int id) =>
{
    string folderPath = "Data/PickAPile.json";
    string jsonStr = File.ReadAllText(folderPath);

    var result = JsonConvert.DeserializeObject<PickAPileResponseModel>(jsonStr);
    var answer = result?.Answers.FirstOrDefault(x => x.AnswerId == id);
    if (answer is null)
    {
        return Results.BadRequest("Answer not found");
    }
    return Results.Ok(answer); 
});

app.Run();

public class PickAPileResponseModel
{
    public QuestionModel[] Questions { get; set; }
    public AnswerModel[] Answers { get; set; }
}

public class QuestionModel
{
    public int QuestionId { get; set; }
    public string QuestionName { get; set; }
    public string QuestionDesp { get; set; }
}

public class AnswerModel
{
    public int AnswerId { get; set; }
    public string AnswerImageUrl { get; set; }
    public string AnswerName { get; set; }
    public string AnswerDesp { get; set; }
    public int QuestionId { get; set; }
}