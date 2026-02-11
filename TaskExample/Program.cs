using System.Diagnostics.Metrics;

namespace TaskExample;

class UpCounter
{
    public long CountUp(int count)
    {
        long sum = 0;
        System.Console.WriteLine("\nCount-Up Start.");
        for (int i = 1; i < count; i++)
        {
            System.Console.Write($"i={i}, ");
            sum+=i;
        }
        System.Console.WriteLine("\nCount-Down Finished.");
        return sum;
    }
}
class DownCounter
{
    public SumData CountDown(int count)
    {
        long sum = 0;
        System.Console.WriteLine("\nCount-Down Start.");
        for (int j = count; j >= 1; j--)
        {
            System.Console.Write($"j={j}, ");
            sum+=j;
        }
        System.Console.WriteLine("\nCount-Down Finisied.");
        return new SumData(){Sum = sum};
    }
}

class SumData
{
    public long Sum { get; set; }
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

        Task<long> task1 = Task.Run(() =>
        {
            return upCounter.CountUp(20);
        });

        Task<SumData> task2 = Task.Factory.StartNew(() =>
        {
            return downCounter.CountDown(25);
        });

        // task1.Wait();
        // task2.Wait();
        Task.WaitAll(task1,task2);
        System.Console.WriteLine($"Result from Count-Up: {task1.Result}");
        System.Console.WriteLine($"Result from Count-Down: {task2.Result.Sum}");
    }
}
