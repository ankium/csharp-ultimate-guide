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
        for (int i = 0; i < 10; i++)
        {
            lock (Shared.LockObject)
            {
                if (Shared.Buffer.Count == Shared.BufferCapacity)
                {
                    System.Console.WriteLine("Buffer is full, producer is waiting.");
                    System.Threading.Monitor.Wait(Shared.LockObject);

                }
                System.Console.WriteLine("Producer is producing an item.");
                Thread.Sleep(5000); // Simulate time taken to produce an item
                Shared.Buffer.Enqueue(i);
                System.Threading.Monitor.Pulse(Shared.LockObject); // Notify consumer that an item is available
                System.Console.WriteLine($"Producer produced: {i}");
                Shared.Print();
            }
        }
        System.Console.WriteLine($"{Thread.CurrentThread.Name} finished.");
    }
}

class Consumer
{
    public void Consume()
    {
        System.Console.WriteLine($"{Thread.CurrentThread.Name} started.");

        for (int i = 0; i < 10; i++)
        {
            lock (Shared.LockObject)
            {
                if (Shared.Buffer.Count == 0)
                {
                    System.Console.WriteLine("Buffer is empty, consumer is waiting.");
                    System.Threading.Monitor.Wait(Shared.LockObject);

                }
                System.Console.WriteLine("Consumer is consuming an item.");
                Thread.Sleep(2500); // Simulate time taken to consume an item
                int val = Shared.Buffer.Dequeue();
                System.Threading.Monitor.Pulse(Shared.LockObject); // Notify producer that space is available
                System.Console.WriteLine($"Consumer consumed: {val}");
            }
        }


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
