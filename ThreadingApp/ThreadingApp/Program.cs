using System.Reflection.PortableExecutable;

namespace ThreadingApp;

class NumbersCounter
{
    public void CountUp()
    {
        System.Console.WriteLine("CountUp started.");
        Thread.Sleep(1000); // Sleep for 1 second before starting
        // i = 1 to 100
        for (int i = 1; i <= 100; i++)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($"i={i}, ");
            Thread.Sleep(100); // Sleep for 1 second
        }
        Thread.Sleep(1000); // Sleep for 1 second after finishing
        System.Console.WriteLine("CountUp finished.");
    }

    public void CountDown()
    {
        System.Console.WriteLine("CountDown started.");
        Thread.Sleep(1000); // Sleep for 1 second before starting
        // j = 100 to 1
        for (int j = 100; j >= 1; j--)
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

        // Create a NumbersCounter instance
        NumbersCounter counter = new NumbersCounter();

        // Create first thread
        ThreadStart threadStart1 = new ThreadStart(counter.CountUp);
        Thread thread1 = new Thread(threadStart1);
        thread1.Name = "CountUp-Thread";
        thread1.Priority = ThreadPriority.Highest;
        // Invoke CountUp
        thread1.Start();
        System.Console.WriteLine($"{thread1.Name}({thread1.ManagedThreadId}) is {thread1.ThreadState.ToString()}"); //Running

        // Create second thread
        ThreadStart threadStart2 = new ThreadStart(counter.CountDown);
        Thread thread2 = new Thread(threadStart2)
        {
            Name = "CountDown-Thread",
            Priority = ThreadPriority.BelowNormal
        };
        //invoke CountDown
        thread2.Start();
        System.Console.WriteLine($"{thread2.Name}({thread2.ManagedThreadId}) is {thread2.ThreadState.ToString()}");//Running

        // Wait for both threads to finish
        thread1.Join();
        thread2.Join();
        
        System.Console.WriteLine(mainThread.Name+" has finished execution."); 
        //System.Console.ReadKey();
    }
}
