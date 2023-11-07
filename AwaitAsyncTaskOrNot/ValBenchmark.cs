using BenchmarkDotNet.Attributes;

namespace AwaitAsyncTaskOrNot;
[MemoryDiagnoser(false)]
public class ValBenchmark
{
    private readonly Task<int> DoSomething = Task.FromResult(1);

    [Benchmark]
    public async Task<int> AwaitTask()
    {
        return await Task_AwaitCore();
    }

    [Benchmark]
    public async Task<int> NoAwaitTask()
    {
        return await Task_NoAwaitCore();
    }

    private async Task<int> Task_AwaitCore()
    {
        return await DoSomething;
    }

    private Task<int> Task_NoAwaitCore()
    {
        return DoSomething;
    }
}
