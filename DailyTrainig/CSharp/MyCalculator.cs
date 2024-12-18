/*
 * Example for "params" keyword and "method chaining"
 * 
 * params:
 * 
 * - pass variable number of arguments (no other args are allowed)
 * - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters#params-modifier
 * 
 * method chaining:
 * 
 * - fluent interface, chain method by returning this instance
 * - for more convenient readability and usage (e.g. for configurations)
 * 
 */


namespace CSharp;
public class MyCalculator
{

    private int value;

    public MyCalculator(int value)
    {
        this.value = value;
    }
    public int Result => value;

    public MyCalculator Add(params int[] numbers)
    {
        foreach (int number in numbers)
        {
            value += number;
        }
        return this;
    }

    public MyCalculator Multiply(params int[] numbers)
    {
        foreach (int number in numbers)
        {
            value *= number;
        }
        return this;
    }

    public static void RunCalculatorExample(int myInt)
    {
        var calc = new MyCalculator(0);

        var result = calc.Add(1, 2, 3).Multiply(2, 3).Result;

        Console.WriteLine($"Calculator result:  {result}");
    }
}
