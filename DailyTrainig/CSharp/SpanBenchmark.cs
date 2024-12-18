/*
 * Example for "readOnlySpan" struct with benchmark comparison
 * 
 * - github repo: https://github.com/dotnet/BenchmarkDotNet
 * - configs: https://github.com/dotnet/BenchmarkDotNet/blob/master/docs/articles/configs/diagnosers.md
 * 
 * - run via console with: `dotnet run -c Release`
 * 
 */

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Running;

namespace CSharp;


#if !DEBUG
[HtmlExporter]
[ThreadingDiagnoser]
[MemoryDiagnoser]
[Config(typeof(CustomConfig))]  // Custom Config
#endif
public class SpanBenchmark
{

    private byte[] byteArray;

    public SpanBenchmark()
    {
        Setup();
    }

    [GlobalSetup]
    public void Setup()
    {
        byteArray = new byte[10000000];
        for (int i = 0; i < byteArray.Length; i++)
        {
            byteArray[i] = (byte)(i % 256);  // Initialize with some data
        }
    }


    // Benchmarks for accessing
    [Benchmark]
    public void CheckIfAllocationTestWorks()
    {
        byte[] newArray = new byte[byteArray.Length];  // Allocate memory
        for (int i = 0; i < byteArray.Length; i++)
        {
            newArray[i] = byteArray[i];
        }
    }

    [Benchmark]
    public void AccessUsingArray()
    {
        for (int i = 0; i < byteArray.Length; i += 1000)
        {
            byte[] newArray = new byte[1000];
            Array.Copy(byteArray, i, newArray, 0, 1000);  // Allocate memory
        }
    }

    [Benchmark]
    public void AccessUsingSpan()
    {
        for (int i = 0; i < byteArray.Length; i += 1000)
        {
            //Span<byte> span = new Span<byte>(byteArray);
            Span<byte> span = byteArray.AsSpan(i, 1000);  // No allocation
            for (int j = 0; j < span.Length; j++)
            {
                byte value = span[j];
            }
        }
    }

    [Benchmark]
    public void AccessUsingReadOnlySpan()
    {
        ReadOnlySpan<byte> readOnlySpan = new ReadOnlySpan<byte>(byteArray);
        for (int i = 0; i < readOnlySpan.Length; i++)
        {
            byte value = readOnlySpan[i];
        }
    }


    public static void RunSpanExample()
    {
#if DEBUG
        RunBenchmarks();
#else
        RunDebugExample();
#endif
    }


    public static void RunBenchmarks()
    {
        _ = BenchmarkRunner.Run<SpanBenchmark>();
    }

    public static void RunDebugExample()
    {
        var sb = new SpanBenchmark();
        sb.Setup();
        sb.AccessUsingArray();
        sb.AccessUsingSpan();
        sb.AccessUsingReadOnlySpan();
    }

}


public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        AddDiagnoser(MemoryDiagnoser.Default);
        AddColumn(StatisticColumn.OperationsPerSecond);
        AddExporter(HtmlExporter.Default);
        AddExporter(CsvExporter.Default);
        AddColumnProvider(DefaultColumnProviders.Instance); // Ensure default columns are included
        //AddColumn(MemoryDiagnoser.Default.Columns.AllocatedMemory); 
        //AddColumn(MemoryDiagnoser.Default.Columns.Gen0Collections);
        //AddColumn(BenchmarkDotNet.Columns.StatisticColumn.Min);
        //AddColumn(BenchmarkDotNet.Columns.StatisticColumn.Max);
        //AddColumn(BenchmarkDotNet.Columns.StatisticColumn.Mean);
        //AddColumn(BenchmarkDotNet.Columns.StatisticColumn.Median);
        //AddColumn(BenchmarkDotNet.Columns.StatisticColumn.StdDev);
    }
}