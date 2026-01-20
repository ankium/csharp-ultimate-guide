using System.Reflection.PortableExecutable;

namespace ThreadingApp;

class MaxCount
{
    public int Count { get; set; }
}

class NumbersUpCounter
{
    public int Count { get; set; }
    public void CountUp()
    {
        try
        {
            System.Console.WriteLine("CountUp started.");
            Thread.Sleep(1000); // Sleep for 1 second before starting
            // i = 1 to count

            for (int i = 1; i <= Count; i++)
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write($"i={i}, ");
                Thread.Sleep(100); // Sleep for 1 second
            }
        
            Thread.Sleep(1000); // Sleep for 1 second after finishing
            System.Console.WriteLine("CountUp finished.");
        }
        catch (ThreadInterruptedException ex)
        {
            System.Console.WriteLine("CountUp was interrupted: " + ex.Message);
        }
    }
}

class NumbersDownCounter
{
    public void CountDown(object? count)
    {
        System.Console.WriteLine("CountDown started.");
        Thread.Sleep(1000); // Sleep for 1 second before starting
        // j = count to 1
        MaxCount? maxCountObj = (MaxCount?)count;
        if (maxCountObj == null)
        {
            throw new ArgumentException("Count must be of type MaxCount.");
        }
        for (int j = maxCountObj.Count; j >= 1; j--)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write($"j={j}, ");
            Thread.Sleep(100); // Sleep for 1 second
        }
        Thread.Sleep(1000); // Sleep for 1 second after finishing
        System.Console.WriteLine("CountDown finished.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Get main thread
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main-Thread"; 
        System.Console.WriteLine(mainThread.Name+" Started."); // Main thread

        // Create a NumbersUpCounter instance
        NumbersUpCounter upCounter = new NumbersUpCounter(){ Count = 50 };//自定义线程对象并设置Count属性

        // Create first thread
        ThreadStart threadStart1 = new ThreadStart(upCounter.CountUp);//将CountUp方法转换为ThreadStart委托
        Thread thread1 = new Thread(threadStart1);
        thread1.Name = "CountUp-Thread";
        thread1.Priority = ThreadPriority.Highest;
        // Invoke CountUp
        thread1.Start();
        System.Console.WriteLine($"{thread1.Name}({thread1.ManagedThreadId}) is {thread1.ThreadState.ToString()}"); //Running

        // Create a NumbersDownCounter instance
        NumbersDownCounter downCounter = new NumbersDownCounter();
        // Create second thread
        ParameterizedThreadStart threadStart2 = new ParameterizedThreadStart(downCounter.CountDown);//将CountDown方法转换为ParameterizedThreadStart委托
        Thread thread2 = new Thread(threadStart2)
        {
            Name = "CountDown-Thread",
            Priority = ThreadPriority.BelowNormal
        };
        //invoke CountDown
        MaxCount maxCount = new MaxCount { Count = 100 };
        thread2.Start(maxCount);
        System.Console.WriteLine($"{thread2.Name}({thread2.ManagedThreadId}) is {thread2.ThreadState.ToString()}");//Running

        // Wait for both threads to finish
        thread1.Join();
        thread2.Join();
        
        //thread interruption example

        /*
        Thread.Sleep(3000); // Let the threads run for 3 seconds
        if (thread1.IsAlive)
        {
            System.Console.WriteLine($"Interrupting {thread1.Name}...");
            thread1.Interrupt();
        }
        */

        System.Console.WriteLine(mainThread.Name+" has finished execution."); 
        //System.Console.ReadKey();
    }
}
