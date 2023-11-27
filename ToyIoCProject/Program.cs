// See https://aka.ms/new-console-template for more information
using ToyIoCProject;
using ToyIoCProject.App;

Console.WriteLine("Toy IoC Project");

var container = new ToyIoC_SimpleCase();

container.AddSingleton<IClock>(new UTCClock());

container.AddSingleton<IMyService, MyService>();
container.AddSingleton<MyApplication>();

var app = container.Resolve<MyApplication>();

await app.RunAsync();
