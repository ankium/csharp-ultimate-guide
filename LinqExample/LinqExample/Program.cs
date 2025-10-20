using ClassLibraryExample;

namespace LinqExample;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee() { EmpId = 101, EmpName = "Henry", Job = "Designer", Salary = 7232 },
            new Employee() { EmpId = 102, EmpName = "Jack", Job = "Developer", Salary = 4500 },
            new Employee() { EmpId = 103, EmpName = "Gabriel", Job = "Analyst", Salary = 1293 },
            new Employee() { EmpId = 104, EmpName = "William", Job = "Manager", Salary = 2873 },
            new Employee() { EmpId = 105, EmpName = "Alexa", Job = "Manager", Salary = 6232 }
        };
        List<Employee> newEmployeeList = employees.OrderBy(emp => emp.EmpName).ToList();
        foreach (var emp in newEmployeeList)
        {
            Console.WriteLine(emp.EmpId+","+emp.EmpName+","+emp.Job+","+emp.Salary);
        }
    }
}