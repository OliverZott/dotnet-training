#pragma warning disable CS1998

using System.Diagnostics;

namespace AsynchronousProgrammingExample;

public static class Program
{
    public static async Task Main()
    {
        await RunTask1Async();
        await RunTask2Async();
        await RunTask3Async();

        RunAndTimeAllSyncTasks();
        RunAndTimeAllTasks();
        await RunAndTimeAllAsyncTasks();
    }


    private static void RunAllTasks()
    {
        var res1 = AsyncService.Task1();
        Console.WriteLine("Task 1 started, status: " + res1.Status);

        var res2 = AsyncService.Task2();
        Console.WriteLine("Task 2 started, status: " + res2.Status);

        var res3 = AsyncService.Task3();
        Console.WriteLine("Task 3 started, status: " + res3.Status);

        var res4 = AsyncService.Task4();
        Console.WriteLine("Task 4 started, status: " + res4.Status);

        Task.WaitAll(res1, res2, res3, res4);
        Console.WriteLine("Task 1 started, status: " + res1.Status);
    }

    private static async Task RunAllTasksAsync()
    {
        var res1 = await AsyncService.Task1();
        Console.WriteLine("Task 1 started, status: " + res1);

        var res2 = await AsyncService.Task2();
        Console.WriteLine("Task 2 started, status: " + res2);

        var res3 = await AsyncService.Task3();
        Console.WriteLine("Task 3 started, status: " + res3);

        var res4 = await AsyncService.Task4();
        Console.WriteLine("Task 4 started, status: " + res4);
    }

    private static async Task RunTask1Async()
    {
        var res = await AsyncService.Task1();
        Console.WriteLine("Task 1 started, status: " + res);
    }

    private static async Task RunTask2Async()
    {
        var res = await AsyncService.Task2();
        Console.WriteLine("Task 1 started, status: " + res);
    }

    private static async Task RunTask3Async()
    {
        var res = await AsyncService.Task3();
        Console.WriteLine("Task 1 started, status: " + res);
    }

    private static async Task RunTask4Async()
    {
        var res = await AsyncService.Task4();
        Console.WriteLine("Task 1 started, status: " + res);
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

    private static async Task RunAndTimeAllAsyncTasks()
    {
        Console.WriteLine("\nRun All Tasks asynchronous.\n -------------------------------------------------");
        var sw = Stopwatch.StartNew();
        await RunAllTasksAsync();
        sw.Stop();
        Console.WriteLine($"RunAllTasks took {sw.ElapsedMilliseconds} ms");
    }
}