using GenericClassLibrary;

namespace GenericExample;

class Program
{
    static void Main(string[] args)
    {
        //create object of generic class
        User<int> user1 = new User<int>();
        user1._egistrationStatus = 1234;
        System.Console.WriteLine(user1._egistrationStatus);
        User<bool> user2 = new User<bool>();
        user2._egistrationStatus = true;
        System.Console.WriteLine(user2._egistrationStatus);
        
        //create object of generic class
        Sample sample = new Sample();
        Employee employee = new Employee(){_salary = 200};
        Teacher teacher = new Teacher(){_marks = 80};
        //call the generic method
        sample.PrintData<Employee>(employee);
        sample.PrintData<Teacher>(teacher);
        
        //create object of generic class
        MarksPrinter<GraduateStudent> printer = new MarksPrinter<GraduateStudent>();
        printer._stu = new GraduateStudent() { Marks = 90 };
        printer.PrintMarks();
        
        System.Console.ReadKey();
    }
}