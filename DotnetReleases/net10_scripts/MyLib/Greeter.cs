namespace MyLib;

public class Greeter
{
    public int MyNumber { get; set; } = 42;

    public static string Greet(string name)
    {
        return $"Hello, {name} :)";
    }
}