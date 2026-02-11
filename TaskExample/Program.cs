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
        for (int j = count; j >=1; j--)
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
        UpCounter upCounter = new UpCounter();
        DownCounter downCounter = new DownCounter();

        Task task1 = Task.Run(() =>
        {
           upCounter.CountUp(20); 
        });

        Task task2 = Task.Run(() =>
        {
            downCounter.CountDown(25);
        });
    }
}
