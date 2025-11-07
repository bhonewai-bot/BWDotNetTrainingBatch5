using System.Net;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;

namespace BWDotNetTrainingBatch5.ConsoleApp3;

public class HttpClientExample
{
    private readonly HttpClient _client;
    private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/posts";

    public HttpClientExample( )
    {
        _client = new HttpClient();
    }
    
    public async Task Read()
    {
        var response = await _client.GetAsync(_postEndpoint);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonStr);
        }
    }

    public async Task Edit(int id)
    {
        var response = await _client.GetAsync($"{_postEndpoint}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            Console.WriteLine("No data found.");
            return;
        }
        
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonStr);
        }
    }

    public async Task Create(string title, string body, int userId)
    {
        PostModel requestModel = new PostModel()
        {
            title = title,
            body = body,
            userId = userId
        };
        
        string jsonRequest = JsonConvert.SerializeObject(requestModel);
        var content = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _client.PostAsync(_postEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }

    public async Task Update(int id, string title, string body, int userId)
    {
        var post = await _client.GetAsync($"{_postEndpoint}/{id}");
        if (post.StatusCode == HttpStatusCode.NotFound)
        {
            Console.WriteLine("No data found.");
            return;
        }

        PostModel requestModel = new PostModel()
        {
            id = id,
            title = title,
            body = body,
            userId = userId
        };

        string jsonRequest = JsonConvert.SerializeObject(requestModel);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"{_postEndpoint}/{id}", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }

    public async Task Delete(int id)
    {
        var response  = await _client.DeleteAsync($"{_postEndpoint}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            Console.WriteLine("No data found.");
            return;
        }

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Deleted successfully.");
        }
    }
}

public class PostModel
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}