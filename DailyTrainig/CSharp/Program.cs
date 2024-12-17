// See https://aka.ms/new-console-template for more information

var calc = new CSharp.MyCalculator(0);

var result = calc.Add(1, 2, 3).Multiply(2, 3).Result;

Console.WriteLine($"Calculator result:  {result}");
