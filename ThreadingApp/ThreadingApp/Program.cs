namespace ThreadingApp;

class Program
{
    static void Main(string[] args)
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main-Thread"; 
        System.Console.WriteLine(mainThread.ToString());
        System.Console.WriteLine(mainThread.Name);
        Method1();
        System.Console.ReadKey();
    }
    static void Method1()
    {
        System.Console.WriteLine("Method-1");
    }
}
