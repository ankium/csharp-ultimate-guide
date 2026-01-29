using System.Collections;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace WaitPulseExample;

static class Shared
{
    public static object LockObject = new object(); // Lock object for synchronization
    public static Queue<int> Buffer = new Queue<int>();// Shared buffer between producer and consumer
    public const int BufferCapacity = 5; // Maximum number of items in the buffer

    public static void Print()
    {
        System.Console.Write("Buffer contents: ");
        foreach (int item in Buffer)
        {
            System.Console.Write($"{item}, ");
        }
        System.Console.WriteLine();
    }
}

class Producer
{
    public void Produce()
    {
        System.Console.WriteLine($"{Thread.CurrentThread.Name} started.");

        System.Console.WriteLine($"{Thread.CurrentThread.Name} finished.");
    }
}

class Consumer
{
    public void Consume()
    {
        System.Console.WriteLine($"{Thread.CurrentThread.Name} started.");

        System.Console.WriteLine($"{Thread.CurrentThread.Name} finished.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread started.");

        //Create Producer and Consumer instances
        Producer producer = new Producer();
        Consumer consumer = new Consumer();

        //Create Threads
        System.Threading.Thread producerThread = new System.Threading.Thread(producer.Produce) { Name = "ProducerThread" };
        System.Threading.Thread consumerThread = new System.Threading.Thread(consumer.Consume) { Name = "ConsumerThread" };

        //Start Threads
        producerThread.Start();
        consumerThread.Start();

        //Wait for Threads to finish
        producerThread.Join();
        consumerThread.Join();

        Console.WriteLine($"Main Thread ended.");
    }
}
