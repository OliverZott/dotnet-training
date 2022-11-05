using HelloWorldLibrary.BusinessLogic;
using Microsoft.Extensions.Logging;

public static class MainProgram
{
    public static void Main()
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);
        });
        ILogger<Messages> logger = loggerFactory.CreateLogger<Messages>();

        var messages = new Messages(logger);
        var message = messages.Greeting("it");

        Console.WriteLine(message);
    }
}