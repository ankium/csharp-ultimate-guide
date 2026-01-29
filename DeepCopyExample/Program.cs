using System.Globalization;
using System.Security.Principal;

namespace DeepCopyExample;

class Program
{
    static void Main(string[] args)
    {
        //源数组
        Employee[] sourceEmployees = new Employee[3]
        {
            new Employee() { EmpId = 101, EmpAge = 20, EmpName = "小明" },
            new Employee() { EmpId = 102, EmpAge = 21, EmpName = "小王" },
            new Employee() { EmpId = 103, EmpAge = 22, EmpName = "小李" }
        };
        Console.WriteLine("-----------初次打印源数组元素-----------");
        Console.WriteLine("Source Array:");
        foreach (Employee employee in sourceEmployees)
        {
            Console.WriteLine(employee.EmpId+","+employee.EmpAge+","+employee.EmpName);
        }
        
        //Shallow Copy:CopyTo至目标数组
        Employee[] destinationEmployees1 = new Employee[5];
        sourceEmployees.CopyTo(destinationEmployees1, 2);
        Console.WriteLine("-----------初次打印CopyTo后的目标数组元素-----------");
        Console.WriteLine("Copy To Array:");
        foreach (Employee employee in destinationEmployees1)
        {
            if (employee != null)
            {
                Console.WriteLine(employee.EmpId+","+employee.EmpAge+","+employee.EmpName);
            }
        }
       
        //Shallow Copy:Clone至目标数组
        Employee[] destinationEmployees2 = (Employee[])sourceEmployees.Clone();
        Console.WriteLine("-----------初次打印Clone后的目标数组元素-----------");
        Console.WriteLine("Clone Array:");
        foreach (Employee employee in destinationEmployees2)
        {
            Console.WriteLine(employee.EmpId+","+employee.EmpAge+","+employee.EmpName);
        }
        
        //改变源数组中指定元素的值
        Console.WriteLine("-----------改变源数组中指定元素的值后再打印数组元素-----------");
        sourceEmployees[0].EmpName = "狗胜";
        Console.WriteLine("Source Array:");
        for (int i = 0; i<sourceEmployees.Length; i++)
        {
            Console.WriteLine(sourceEmployees[i].EmpId+","+sourceEmployees[i].EmpAge+","+sourceEmployees[i].EmpName);
        }

        Console.WriteLine("Copy To Array:");
        for (int i = 0; i < destinationEmployees1.Length; i++)
        {
            if (destinationEmployees1[i] != null)
            {
                Console.WriteLine(destinationEmployees1[i].EmpId+","+destinationEmployees1[i].EmpAge+","+destinationEmployees1[i].EmpName);
            }
        }

        Console.WriteLine("Clone Array:");
        for (int i = 0; i < destinationEmployees2.Length; i++)
        {
            if (destinationEmployees2[i] != null)
            {
                Console.WriteLine(destinationEmployees2[i].EmpId+","+destinationEmployees2[i].EmpAge+","+destinationEmployees2[i].EmpName);
            }
        }
        
        //改变CopyTo目标数组中指定元素的值
        Console.WriteLine("-----------改变CopyTo目标数组中指定元素的值后再打印数组元素-----------");
        destinationEmployees1[3].EmpName = "东贝";
        Console.WriteLine("Source Array:");
        for (int i = 0; i<sourceEmployees.Length; i++)
        {
            Console.WriteLine(sourceEmployees[i].EmpId+","+sourceEmployees[i].EmpAge+","+sourceEmployees[i].EmpName);
        }
        Console.WriteLine("Copy To Array:");
        for (int i = 0; i < destinationEmployees1.Length; i++)
        {
            if (destinationEmployees1[i] != null)
            {
                Console.WriteLine(destinationEmployees1[i].EmpId+","+destinationEmployees1[i].EmpAge+","+destinationEmployees1[i].EmpName);
            }
        }
        Console.WriteLine("Clone Array:");
        for (int i = 0; i < destinationEmployees2.Length; i++)
        {
            if (destinationEmployees2[i] != null)
            {
                Console.WriteLine(destinationEmployees2[i].EmpId+","+destinationEmployees2[i].EmpAge+","+destinationEmployees2[i].EmpName);
            }
        }
        //改变Clone目标数组中指定元素的值
        Console.WriteLine("-----------改变Clone目标数组中指定元素的值后再打印数组元素-----------");
        destinationEmployees2[2].EmpName = "王巴";
        Console.WriteLine("Source Array:");
        for (int i = 0; i<sourceEmployees.Length; i++)
        {
            Console.WriteLine(sourceEmployees[i].EmpId+","+sourceEmployees[i].EmpAge+","+sourceEmployees[i].EmpName);
        }
        Console.WriteLine("Copy To Array:");
        for (int i = 0; i < destinationEmployees1.Length; i++)
        {
            if (destinationEmployees1[i] != null)
            {
                Console.WriteLine(destinationEmployees1[i].EmpId+","+destinationEmployees1[i].EmpAge+","+destinationEmployees1[i].EmpName);
            }
        }
        Console.WriteLine("Clone Array:");
        for (int i = 0; i < destinationEmployees2.Length; i++)
        {
            if (destinationEmployees2[i] != null)
            {
                Console.WriteLine(destinationEmployees2[i].EmpId+","+destinationEmployees2[i].EmpAge+","+destinationEmployees2[i].EmpName);
            }
        }
        
        //Deep Copy:Clone至目标数组
        Employee[] destinationEmployees3 = new Employee[sourceEmployees.Length];
        for (int i = 0; i < sourceEmployees.Length; i++)
        {
            if (sourceEmployees[i] != null)
            {
                //调用自定义的Deep Copy方法CopyElement
                //destinationEmployees3[i] = sourceEmployees[i].CopyElement();
                
                //调用实现接口ICloneable的Clone方法，由于Clone方法的返回值默认为Object类型，因此需要作类型转换
                
                Employee empResult = (Employee)sourceEmployees[i].Clone();
                destinationEmployees3[i] = empResult;
            }
        }

        Console.WriteLine("-----------Deep Copy后打印数组元素-----------");
        Console.WriteLine("Source Array:");
        foreach (Employee employee in sourceEmployees)
        {
            Console.WriteLine(employee.EmpId+","+employee.EmpAge+","+employee.EmpName);
        }
        Console.WriteLine("Deep Copy Array:");
        foreach (Employee employee in destinationEmployees3)
        {
            Console.WriteLine(employee.EmpId+","+employee.EmpAge+","+employee.EmpName);
        }
        
        //改变源数组中指定元素的值
        Console.WriteLine("-----------Deep Copy后改变源数组中指定元素的值后再打印数组元素-----------");
        sourceEmployees[0].EmpName = "风味";
        Console.WriteLine("Source Array:");
        for (int i = 0; i<sourceEmployees.Length; i++)
        {
            Console.WriteLine(sourceEmployees[i].EmpId+","+sourceEmployees[i].EmpAge+","+sourceEmployees[i].EmpName);
        }

        Console.WriteLine("Deep Copy Array:");
        for (int i = 0; i < destinationEmployees3.Length; i++)
        {
            if (destinationEmployees3[i] != null)
            {
                Console.WriteLine(destinationEmployees3[i].EmpId+","+destinationEmployees3[i].EmpAge+","+destinationEmployees3[i].EmpName);
            }
        }
        //改变Deep Copy目标数组中指定元素的值
        Console.WriteLine("-----------Deep Copy后改变新数组中指定元素的值后再打印数组元素-----------");
        destinationEmployees3[1].EmpName = "拉希";
        Console.WriteLine("Source Array:");
        for (int i = 0; i<sourceEmployees.Length; i++)
        {
            Console.WriteLine(sourceEmployees[i].EmpId+","+sourceEmployees[i].EmpAge+","+sourceEmployees[i].EmpName);
        }

        Console.WriteLine("Deep Copy Array:");
        for (int i = 0; i < destinationEmployees3.Length; i++)
        {
            if (destinationEmployees3[i] != null)
            {
                Console.WriteLine(destinationEmployees3[i].EmpId+","+destinationEmployees3[i].EmpAge+","+destinationEmployees3[i].EmpName);
            }
        }
    }
    
    
}

class Employee:System.ICloneable
{
    public int EmpId { get; set; }
    public int EmpAge { get; set; }
    public string EmpName { get; set; }

    //自定义方法
    public Employee CopyElement()
    {
        Employee emp = new Employee(){};
        emp.EmpId = this.EmpId;
        emp.EmpAge = this.EmpAge;
        emp.EmpName = this.EmpName;
        return emp;
    }
    //接口方法实现
    public object Clone()
    {
        Employee emp = new Employee(){EmpId = this.EmpId, EmpAge = this.EmpAge, EmpName = this.EmpName};
        return emp;
    }
}