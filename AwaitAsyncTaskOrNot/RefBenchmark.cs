//using BenchmarkDotNet.Attributes;

//namespace AwaitAsyncTaskOrNot;
//[MemoryDiagnoser(false)]
//public static class RefBenchmark
//{


//    private static readonly Task<RefInt> DoSomething = Task.FromResult(RefInt.One);

//    [Benchmark]
//    public static async Task<int> AwaitTask()
//    {
//        return await Task_AwaitCore();
//    }

//    [Benchmark]
//    public static async Task<int> NoAwaitTask()
//    {
//        return await Task_NoAwaitCore();
//    }

//    private static async Task<int> Task_AwaitCore()
//    {
//        return await DoSomething;
//    }

//    private static Task<int> Task_NoAwaitCore()
//    {
//        return DoSomething;
//    }
//}

//public class RefInt
//{
//    public static int One => 1;
//}
