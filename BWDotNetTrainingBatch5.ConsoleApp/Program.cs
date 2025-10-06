// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Data.SqlClient;
using BWDotNetTrainingBatch5.ConsoleApp;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Create();
// adoDotNetExample.Edit();
// adoDotNetExample.Update();
// adoDotNetExample.Delete();
// adoDotNetExample.SoftDelete();

DapperExample dapperExample = new DapperExample();
// dapperExample.Read();
// dapperExample.Create("Cursor", "Bhone Wai", "Hello World");
dapperExample.Edit(13);
// dapperExample.Update(1012, "VS Code", "Bhone Wai", "Hello World");
// dapperExample.Delete(19);