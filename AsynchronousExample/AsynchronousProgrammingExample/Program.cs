#pragma warning disable CS1998

using System.Diagnostics;

namespace AsynchronousProgrammingExample;

public static class Program
{
    public static async Task Main(string[] args)
    {
        // SyncService.Task1();
        // SyncService.Task2();
        // SyncService.Task3();
        // SyncService.Task4();

        // await AsyncService.Task1();
        // await AsyncService.Task2();
        // await AsyncService.Task3();
        // await AsyncService.Task4();

        // var res1 = AsyncService.Task1();
        // var res2 = AsyncService.Task2();
        // var res3 = AsyncService.Task3();
        // var res4 = AsyncService.Task4();
        //
        // await Task.WhenAll(res1, res2, res3, res4);

        RunAndTimeAllSyncTasks();
        RunAndTimeAllTasks();
    }


    private static void RunAllTasks()
    {
        var res1 = AsyncService.Task1();
        Console.WriteLine("Task 1 started, status: " + res1.Status);

        var res2 = AsyncService.Task2();
        Console.WriteLine("Task 2 started, status: " + res2.Status);

        var res3 = AsyncService.Task3();
        var res4 = AsyncService.Task4();

        Task.WaitAll(res1, res2, res3, res4);
        Console.WriteLine("Task 1 started, status: " + res1.Status);
    }

    private static void RunAllSyncTasks()
    {
        SyncService.Task1();
        SyncService.Task2();
        SyncService.Task3();
        SyncService.Task4();
    }


    private static void RunAndTimeAllSyncTasks()
    {
        Console.WriteLine("\nRun All Tasks synchronous.\n -------------------------------------------------");
        var sw = Stopwatch.StartNew();
        RunAllSyncTasks();
        sw.Stop();
        Console.WriteLine($"RunAllSyncTasks took {sw.ElapsedMilliseconds} ms");
    }

    private static void RunAndTimeAllTasks()
    {
        Console.WriteLine("\nRun All Tasks asynchronous.\n -------------------------------------------------");
        var sw = Stopwatch.StartNew();
        RunAllTasks();
        sw.Stop();
        Console.WriteLine($"RunAllTasks took {sw.ElapsedMilliseconds} ms");
    }

}