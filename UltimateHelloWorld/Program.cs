using HelloWorldLibrary.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimateHelloWorld;

// for proper disposing of host variable (releasing resources)
using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;


try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IMessages, Messages>();
            services.AddSingleton<App>();
        });
}







//public static class MainProgram
//{
//    public static void Main()
//    {
//        using var loggerFactory = LoggerFactory.Create(builder =>
//        {
//            builder
//                .AddFilter("Microsoft", LogLevel.Warning)
//                .AddFilter("System", LogLevel.Warning)
//                .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);
//        });
//        ILogger<Messages> logger = loggerFactory.CreateLogger<Messages>();

//        var messages = new Messages(logger);
//        var message = messages.Greeting("it");

//        Console.WriteLine(message);
//    }
//}