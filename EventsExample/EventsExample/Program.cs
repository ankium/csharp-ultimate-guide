using ClassLibraryExample;
using System.Runtime.CompilerServices;

namespace EventsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.DoWork();
        }

        private void DoWork()
        {
            Publisher publisher = new Publisher();
            //订阅事件
            publisher.CustomEvent += (sender, e) =>
            {
                int c = e.num1 + e.num2;
                Console.WriteLine(c);
            };
            //调用事件
            publisher.RaiseEvent(this, 20, 15);
            Console.ReadKey();
        }
    }
}
