using System.Diagnostics;
using System.Runtime.CompilerServices;

#pragma warning disable CS8321 // Local function is declared but never used

const int iterations = 1_000_000;
int[] values = Enumerable.Range(0, 100).ToArray();
var sw = Stopwatch.StartNew();

Console.WriteLine("Running...");
while (true)
{
    long mem = GC.GetAllocatedBytesForCurrentThread();
    sw.Restart();

    for (int i = 0; i < iterations; i++)
    {
        // Test();
        // Test2("a", "b");
        Test4(values);
    }
    
    sw.Stop();
    mem = GC.GetAllocatedBytesForCurrentThread() - mem;
    Console.WriteLine($"{sw.Elapsed.TotalNanoseconds /iterations:N0} ns, {mem /iterations:N0} bytes allocated");
}

[MethodImpl(MethodImplOptions.NoInlining)]
static TimeSpan Test()
{
    // net10 is better with escape-analysis: checks if sw instance is stashed away in field...
    // JIT proves  object does not escape and can stack allocate it.
    // The part of the memory that is stored on the stackframe for this method call is little bigger and used that extra memory to hold the stopwatch instance.
    Stopwatch sw = Stopwatch.StartNew();
    sw.Stop();
    return sw.Elapsed;
}


[MethodImpl(MethodImplOptions.NoInlining)]
static int Test2(string a, string b)
{
    // Again escape analysis for this string array allocation
    var sum = 0;
    foreach (var value in new string[] { a, b })
    {
        sum += value.Length;
    }

    return sum;
    // return new string[] { a, b }.Sum(value => value.Length);
}


[MethodImpl(MethodImplOptions.NoInlining)]
static int Test3(int[] values)
{
    // Already optimized... no Enumerable or foreach
    var sum = 0;
    foreach (int value in values)
    {
        sum += value;
    }
    return sum;
    // return values.Sum();
}

[MethodImpl(MethodImplOptions.NoInlining)]
static int Test4(IEnumerable<int> values)
{
    var sum = 0;
    foreach (int value in values)
    {
        sum += value;
    }
    return sum;
}


/*
 * dotnet run -c Release -f net10.0
 * https://www.youtube.com/watch?v=YDhJ953D6-U&t=9675s  at 2:41:00
 * https://sharplab.io
 *
 * 
 * using System.Linq;
using System.Collections.Generic;

static int Test1(int[] values)
{
    var sum = 0;
    foreach (int value in values)
    {
        sum += value;
    }
    return sum;
}

static int Test2(int[] values)
{
    var sum = 0;
    for (int i = 0; i <= values.Length; i++) 
    {
        sum = sum + values[i];
    }
    return sum;
}

static int Test3(int[] values)
{
    return values.Sum();
}

static int Test4(IEnumerable<int> values)
{
    // Already optimized... no Enumerable or foreach
    var sum = 0;
    foreach (int value in values)
    {
        sum += value;
    }
    return sum;
    // return values.Sum();
}
 */