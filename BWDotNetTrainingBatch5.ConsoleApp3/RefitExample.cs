using System.Net;
using Refit;

namespace BWDotNetTrainingBatch5.ConsoleApp3;

public class RefitExample
{
    public async Task Run()
    {
        var blogApi = RestService.For<IBlogApi>("http://localhost:5000");
        var lts = await blogApi.GetBlogs();
        foreach (var item in lts)
        {
            Console.WriteLine(item.BlogTitle);
        }

        var item1 = await blogApi.GetBlog(1);

        try
        {
            var item2 = await blogApi.GetBlog(100);
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found.");
            }
        }

        /*var item3 = await blogApi.CreateBlog(new BlogModel()
        {
            BlogTitle = "Jujutsu Kaisen",
            BlogAuthor = "Gege Akutami",
            BlogContent =
                "Jujutsu Kaisen is a Japanese manga series written and illustrated by Gege Akutami. It was serialized in Shueisha's shōnen manga magazine Weekly Shōnen Jump from March 2018 to September 2024, with its chapters collected in 30 tankōbon volumes.",
            DeleteFlag = false
        });*/

        /*var item4 = await blogApi.UpdateBlog(6, new BlogModel()
        {
            BlogTitle = "Mid Kaisen",
            BlogAuthor = "Gege Akutami",
            BlogContent =
                "Jujutsu Kaisen is a Japanese manga series written and illustrated by Gege Akutami. It was serialized in Shueisha's shōnen manga magazine Weekly Shōnen Jump from March 2018 to September 2024, with its chapters collected in 30 tankōbon volumes.",
            DeleteFlag = true
        });*/

        var item5 = await blogApi.DeleteBlog(6);
    }
}