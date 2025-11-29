// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Data.SqlClient;
using BWDotNetTrainingBatch5.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

// Console.WriteLine("Hello, World!");

// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Create();
// adoDotNetExample.Edit();
// adoDotNetExample.Update();
// adoDotNetExample.Delete();
// adoDotNetExample.SoftDelete();

// DapperExample dapperExample = new DapperExample();
// dapperExample.Read();
// dapperExample.Create("Cursor", "Bhone Wai", "Hello World");
// dapperExample.Edit(13);
// dapperExample.Update(1012, "VS Code", "Bhone Wai", "Hello World");
// dapperExample.Delete(19);

// EFCoreExample efCoreExample = new EFCoreExample();
// efCoreExample.Read();
// efCoreExample.Create("Claude", "Bhone Wai", "Hello World");
// efCoreExample.Edit(13);
// efCoreExample.Update(16, "Hollow Knight", "Bhone Wai", "Hello World");
// efCoreExample.Delete(21);

// DapperExample2 dapperExample2 = new DapperExample2();
// dapperExample2.Read();
// dapperExample2.Edit(22);
// dapperExample2.Create("Console", "Bhone Wai", "Hello World");

// var services = new ServiceCollection().AddSingleton<AdoDotNetExample>().BuildServiceProvider();
var services = new ServiceCollection()
    .AddSingleton<AdoDotNetExample>()
    .AddSingleton<DapperExample>()
    .AddSingleton<EFCoreExample>()
    .BuildServiceProvider();

var adoDotNetExample = services.GetRequiredService<AdoDotNetExample>();
// adoDotNetExample.Read();
// adoDotNetExample.Create();
// adoDotNetExample.Edit();
// adoDotNetExample.Update();
// adoDotNetExample.SoftDelete();

var dapperExample = services.GetRequiredService<DapperExample>();
// dapperExample.Read();
/* dapperExample.Create(
        "Bleach",
        "Tite Kubo",
        "Bleach is a Japanese manga series written and illustrated by Tite Kubo. It follows the adventures of teenager Ichigo Kurosaki, who obtains the powers of a Soul Reaper—a death personification similar to a Grim Reaper—from another Soul Reaper, Rukia Kuchiki."
    ); */
// dapperExample.Edit(8);
/* dapperExample.Update(
        6,
        "Mid Kaisen",
        "Gege Akutami",
        "Jujutsu Kaisen is a Japanese manga series written and illustrated by Gege Akutami. It was serialized in Shueisha's shōnen manga magazine Weekly Shōnen Jump from March 2018 to September 2024, with its chapters collected in 30 tankōbon volumes."
    ); */
// dapperExample.Delete(9);

var efCoreExample = services.GetRequiredService<EFCoreExample>();
// efCoreExample.Read();
// efCoreExample.Create("test", "test", "test");
// efCoreExample.Edit(10);
/* efCoreExample.Update(
        10,
        "One-Punch Man",
        "ONE",
        "One-Punch Man is a Japanese manga series created by One, originally released as a webcomic in early 2009. It tells the story of Saitama, an independent superhero who, having trained to the point that he can defeat any opponent with a single punch, grows deeply bored from a lack of challenge."
    ); */
    efCoreExample.Delete(10);