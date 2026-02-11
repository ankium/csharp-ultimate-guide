using System.Diagnostics.Metrics;

namespace TaskExample;

class UpCounter
{
    public void CountUp(int count)
    {
        System.Console.WriteLine("\nCount-Up Start.");
        for (int i = 1; i < count; i++)
        {
            System.Console.Write($"i={i}, ");
        }
        System.Console.WriteLine("\nCount-Down Finished.");
    }
}
class DownCounter
{
    public void CountDown(int count)
    {
        System.Console.WriteLine("\nCount-Down Start.");
        for (int j = count; j >= 1; j--)
        {
            System.Console.Write($"j={j}, ");
        }
        System.Console.WriteLine("\nCount-Down Finisied.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        WithTask();
        stopwatch.Stop();
        long timeTakenForTasks = stopwatch.ElapsedMilliseconds;
        System.Console.WriteLine($"\nTasks - Time Taken: {timeTakenForTasks} ms");
    }

    static void WithTask()
    {
        UpCounter upCounter = new UpCounter();
        DownCounter downCounter = new DownCounter();

        Task task1 = Task.Factory.StartNew(() =>
        {
            upCounter.CountUp(20);
        });

        Task task2 = Task.Factory.StartNew(() =>
        {
            downCounter.CountDown(25);
        });

        // task1.Wait();
        // task2.Wait();
        Task.WaitAll(task1,task2);
    }
}
