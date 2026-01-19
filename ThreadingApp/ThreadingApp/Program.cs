using System.Reflection.PortableExecutable;

namespace ThreadingApp;

class NumbersCounter
{
    public void CountUp()
    {
        // i = 1 to 100
        for (int i = 1; i <= 100; i++)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($"i={i}, ");
        }
    }

    public void CountDown()
    {
        // j = 100 to 1
        for (int j = 100; j >= 1; j--)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write($"j={j}, ");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Get main thread
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main-Thread"; 
        System.Console.WriteLine(mainThread.Name); // Main thread

        // Create a NumbersCounter instance
        NumbersCounter counter = new NumbersCounter();

        // Create first thread
        ThreadStart threadStart1 = new ThreadStart(counter.CountUp);
        Thread thread1 = new Thread(threadStart1);
        thread1.Name = "CountUp-Thread";
        System.Console.WriteLine(thread1.Name+" is "+thread1.ThreadState.ToString()); //Unstarted
        // Invoke CountUp
        thread1.Start();
        System.Console.WriteLine(thread1.Name+" is "+thread1.ThreadState.ToString()); //Running

        // Create second thread
        ThreadStart threadStart2 = new ThreadStart(counter.CountDown);
        Thread thread2 = new Thread(threadStart2);
        thread2.Name = "CountDown-Thread";
        System.Console.WriteLine(thread2.Name+" is "+thread2.ThreadState.ToString());//Unstarted
        //invoke CountDown
        thread2.Start();
        System.Console.WriteLine(thread2.Name+" is "+thread2.ThreadState.ToString());//Running

        
        System.Console.WriteLine(mainThread.Name+" has finished execution."); 
        //System.Console.ReadKey();
    }
}
