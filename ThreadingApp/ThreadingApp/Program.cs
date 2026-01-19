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
        // Invoke CountUp
        counter.CountUp();

        //invoke CountDown
        counter.CountDown();

        System.Console.WriteLine(mainThread.Name+" has finished execution."); 
        //System.Console.ReadKey();
    }
}
