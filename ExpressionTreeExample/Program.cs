using System.Linq.Expressions;

namespace ExpressionTreeExample
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //表达式树
            Expression<Func<int, int>> exp1 = a => a * a;
            Func<int,int> func1 = exp1.Compile();
            int a = func1.Invoke(20);
            Console.WriteLine(a);

            //表达式树

            Expression<Func<Student, bool>> exp2 = student => student.StuAge > 12 && student.StuAge < 20;
            Func<Student, bool> func2 = exp2.Compile();
            bool b = func2.Invoke(new Student() { StuId = 28, StuName = "ankium", StuAge = 18 });
            Console.WriteLine(b);

            //switch表达式 
            int sp = int.MaxValue;
            string result = sp switch
            {
                1 => "Customer",
                2 => "Employee",
                3 => "Supplier",
                4 => "Distributor",
                _ => "No Case available"
            };
            Console.WriteLine(result);

        }

        internal class Student
        {
            private string _email;
            public int StuId { get; set; }
            public required string StuName { get; set; }
            public int StuAge { get; set; }

            //用表达式体成员创建构造函数的语法
            public Student() => _email = "sudons@msn.cn";

        }
    }
}
