// See https://aka.ms/new-console-template for more information

using BWDotNetTrainingBatch5.ConsoleApp3;

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample =  new HttpClientExample();
// await httpClientExample.Read();
// await httpClientExample.Edit(1);
// await httpClientExample.Edit(101);
// await httpClientExample.Create("POS", "I can't do Math", 1);
// await httpClientExample.Update(1, "POS", "I can't do Math", 1);
// await httpClientExample.Delete(104);

RestClientExample restClientExample = new RestClientExample();
await restClientExample.Read();
// await restClientExample.Edit(1);
// await restClientExample.Create("POS", "I can't do Math", 1);
// await restClientExample.Update(1, "POS", "I can do Math", 1);
await restClientExample.Delete(200);