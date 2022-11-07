using HelloWorldLibrary.BusinessLogic;

namespace UltimateHelloWorld;

public class App
{
    private readonly IMessages _messages;

    public App(IMessages messages)
    {
        _messages = messages;
    }


    // Using: UltimateHelloWorld.exe -lang=it arg2 arg3
    public void Run(string[] args)
    {
        var lang = "en";

        foreach (var arg in args)
        {
            if (arg.ToLower().StartsWith("-lang"))
            {
                lang = arg.Substring(6);
                break;
            }
        }

        var message = _messages.Greeting(lang);
        Console.WriteLine(message);
    }
}
