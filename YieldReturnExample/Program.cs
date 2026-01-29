namespace YieldReturnExample;

class Program
{
    static void Main(string[] args)
    {
        Sample sample = new Sample();
        IEnumerable<int> ienumerable = sample.YieldReturnMethod();
        //通过foreach循环调用
        Console.WriteLine("----------通过foreach循环调用迭代器---------");
        foreach (int i in ienumerable)
        {
            //内部foreach循环每次调用GetEnumerator()方法，基于该IEnumerator迭代器不断调用MoveNext()方法并打印Current的值
            Console.WriteLine(i);
        }
        //通过while循环调用
        Console.WriteLine("----------通过while循环调用迭代器---------");
        IEnumerator<int> enumerator1 = ienumerable.GetEnumerator();
        while (enumerator1.MoveNext())
        {
            Console.WriteLine(enumerator1.Current);
        }
        //手动调用迭代器
        Console.WriteLine("----------手动调用迭代器---------");
        IEnumerator<int> enumerator2 = ienumerable.GetEnumerator();
        enumerator2.MoveNext();//output 10
        Console.WriteLine(enumerator2.Current);
        enumerator2.MoveNext();//output 20
        Console.WriteLine(enumerator2.Current);
    }
}

public class Sample
{
    public IEnumerable<int> YieldReturnMethod()
    {
        Console.WriteLine("Iterator method executes");
        yield return 10;
        Console.WriteLine("Iterator method executes continued");
        yield return 20;
    }
}