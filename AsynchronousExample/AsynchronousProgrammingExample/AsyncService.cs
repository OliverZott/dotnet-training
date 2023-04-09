namespace AsynchronousProgrammingExample;

public class AsyncResult1
{
}

public class AsyncResult2
{
}

public class AsyncResult3
{
}

public class AsyncResult4
{
}

public static class AsyncService
{
    public static async Task<AsyncResult1> Task1()
    {
        Console.WriteLine("Task 1");
        await Task.Delay(5000);
        return new AsyncResult1();
    }


    public static async Task Task2()
    {
        Console.WriteLine("Task 2");
        await Task.Delay(5000);
    }

    public static async Task<AsyncResult3> Task3()
    {
        Console.WriteLine("Task 3");
        await Task.Delay(5000);
        return new AsyncResult3();
    }

    public static async Task Task4()
    {
        Console.WriteLine("Task 4");
        await Task.Delay(5000);
    }
}