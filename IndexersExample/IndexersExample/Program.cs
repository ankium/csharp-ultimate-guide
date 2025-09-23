using IndexerLibrary;

namespace IndexersExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create an object of Car Class
            Car car = new Car();

            //call get accessor of indexer
            System.Console.WriteLine(car[0]);//Output:BMW
            System.Console.WriteLine(car["first"]);//Output:BMW

            //call set accessor of indexer
            car[0] = "Nissan";
            System.Console.WriteLine(car[0]);

            System.Console.ReadKey();
        }
    }
}
