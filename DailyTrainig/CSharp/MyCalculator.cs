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
}
