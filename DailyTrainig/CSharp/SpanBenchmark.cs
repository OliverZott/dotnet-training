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

[HtmlExporter]
[ThreadingDiagnoser]
[MemoryDiagnoser]
[Config(typeof(CustomConfig))]  // Custom Config
public class SpanBenchmark
{

    private byte[] byteArray;

    [GlobalSetup]
    public void Setup()
    {
        byteArray = new byte[10000000];
        for (int i = 0; i < byteArray.Length; i++)
        {
            byteArray[i] = (byte)i;
        }
    }

    [Benchmark]
    public void CheckIfAllocationTestWorks()
    {
        byte[] newArray = new byte[byteArray.Length]; // Allocate memory
        for (int i = 0; i < byteArray.Length; i++)
        {
            newArray[i] = byteArray[i];
        }
    }

    [Benchmark]
    public void AccessUsingArray()
    {
        for (int i = 0; i < byteArray.Length; i++)
        {
            byte value = byteArray[i];
        }
    }

    [Benchmark]
    public void AccessUsingSpan()
    {
        Span<byte> span = new Span<byte>(byteArray);
        for (int i = 0; i < byteArray.Length; i++)
        {
            byte value = span[i];
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


    public static void RunBenchmarks()
    {
        var summary = BenchmarkRunner.Run<SpanBenchmark>();
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