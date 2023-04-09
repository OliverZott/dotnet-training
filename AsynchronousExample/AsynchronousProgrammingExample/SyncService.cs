namespace AsynchronousProgrammingExample;

public class SyncResult1
{
}

public class SyncResult2
{
}

public class SyncResult3
{
}

public class SyncResult4
{
}

public static class SyncService
{
    public static SyncResult1 Task1()
    {
        Console.WriteLine("Task 1");
        Task.Delay(5000).Wait();
        return new SyncResult1();
    }


    public static void Task2()
    {
        Console.WriteLine("Task 2");
        Task.Delay(5000).Wait();
    }


    public static void Task3()
    {
        Console.WriteLine("Task 3");
        Task.Delay(5000).Wait();
    }

    public static void Task4()
    {
        Console.WriteLine("Task 4");
        Task.Delay(5000).Wait();
    }
}