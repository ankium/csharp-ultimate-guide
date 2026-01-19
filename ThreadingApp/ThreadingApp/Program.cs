namespace ThreadingApp;

class Program
{
    static void Main(string[] args)
    {
        Thread mainThread = Thread.CurrentThread;
        // Some properties of Thread class
        mainThread.Name = "Main-Thread"; 
        System.Console.WriteLine(mainThread.Name);
        System.Console.WriteLine(mainThread.Priority);
        System.Console.WriteLine(mainThread.IsAlive);
        System.Console.WriteLine(mainThread.IsBackground);
        System.Console.WriteLine(mainThread.ThreadState);
        System.Console.ReadKey();
    }
}
