namespace GenericClassLibrary;

public abstract class Student
{
    public abstract int Marks { get; set; }
}

public class GraduateStudent : Student
{
    public override int Marks { get; set; }
}

public class PostGraduateStudent : Student
{
    public override int Marks { get; set; }
}

public class Employee
{
    public int _salary;
}

public class Teacher
{
    public int _marks;
}

//generic class
public class User<T>
{
    //generic field
    public T _egistrationStatus;
}

//a class with generic method
public class Sample
{
    public void PrintData<T>(T obj)
    {
        if (obj.GetType()==typeof(Employee))
        {
            Employee emp = obj as Employee;
            System.Console.WriteLine(emp._salary);
        }
        else if (obj.GetType()==typeof(Teacher))
        {
            Teacher teach = obj as Teacher;
            System.Console.WriteLine(teach._marks);
        }
        else
        {
            System.Console.WriteLine("invalid type");
        }
    }
}
//generic class with constraints (want to accept Student only)
public class MarksPrinter<T> where T : Student
{
    public T _stu;
    public void PrintMarks()
    {
        Student temp = (Student)_stu;
        System.Console.WriteLine(temp.Marks);
    }
}
