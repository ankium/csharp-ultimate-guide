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

        stopwatch.Restart();
        WithThreads();
        stopwatch.Stop();
        long timeTakenForThreads = stopwatch.ElapsedMilliseconds;
        System.Console.WriteLine($"\nThreads - Time Taken: {timeTakenForThreads} ms");

        if (timeTakenForTasks < timeTakenForThreads)
        {
            System.Console.WriteLine("TPL is faster.");
        }
        else if (timeTakenForTasks > timeTakenForThreads)
        {
            System.Console.WriteLine("Threads is faster.");
        }
        else
        {
            System.Console.WriteLine("Both TPL and Threads is equal.");
        }
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

        task1.Wait();
        task2.Wait();
    }

    static void WithThreads()
    {
        UpCounter upCounter = new UpCounter();
        DownCounter downCounter = new DownCounter();
        CountdownEvent countdownEvent = new CountdownEvent(2);

        Thread thread1 = new Thread(() =>
        {
            upCounter.CountUp(20);
            countdownEvent.Signal();
        });

        Thread thread2 = new Thread(() =>
        {
            downCounter.CountDown(25);
            countdownEvent.Signal();
        });

        thread1.Start();
        thread2.Start();
        countdownEvent.Wait();
    }
}
