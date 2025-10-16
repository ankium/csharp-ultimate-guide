using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Collections;
namespace CustomCollectionsExample;

class Program
{
    static void Main(string[] args)
    {
        //集合初始化器
        CustomersList customersList = new CustomersList()
        {
            //因为自定义集合中存在Add方法，因此该处提供的每个对象将自动作为Add方法的参数被调用
            new Customer(){CustomerID = "a104",CustomerName = "babe",CustomerEmail = "babe@msn.cn",TypeOfCustomer = TypeOfCustomer.VIPCustomer},
            new Customer(){CustomerID = "A105",CustomerName = "deny",CustomerEmail = "deny@msn.cn",TypeOfCustomer = TypeOfCustomer.RegularCustomer}
        };
        Customer customer1 = new Customer()
        {
            CustomerID = "A106",
            CustomerName = "hony",
            CustomerEmail = "hony@msn.cn",
            TypeOfCustomer = TypeOfCustomer.VIPCustomer
        };
        Customer customer2 = new Customer()
        {
            CustomerID = "B107",
            CustomerName = "kady",
            CustomerEmail = "kady@msn.cn",
            TypeOfCustomer = TypeOfCustomer.VIPCustomer
        };
        customersList.Add(customer1);
        customersList.Add(customer2);
        foreach (Customer cust in customersList)
        {
            Console.WriteLine(cust.CustomerID+","+cust.CustomerName+","+cust.CustomerEmail+","+cust.TypeOfCustomer);
        }
    }
}

public enum TypeOfCustomer
{
    RegularCustomer,
    VIPCustomer
}

public class Customer
{
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public TypeOfCustomer TypeOfCustomer { get; set; }
}

//自定义集合类对象
public class CustomersList : IEnumerable<Customer>
{
    //集合内部硬编码类对象
    private List<Customer> customers = new List<Customer>()
    {
        new Customer(){CustomerID = "A101", CustomerName = "jone",CustomerEmail = "jones@msn.cn",TypeOfCustomer = TypeOfCustomer.VIPCustomer},
        new Customer(){CustomerID = "A102",CustomerName = "mane",CustomerEmail = "mane@msn.cn",TypeOfCustomer = TypeOfCustomer.RegularCustomer},
        new Customer(){CustomerID = "A103",CustomerName = "jeny",CustomerEmail = "jeny@msn.cn",TypeOfCustomer = TypeOfCustomer.VIPCustomer}
    };
    
    //普通：实现IEnumerable.GetEnumerator()方法
    IEnumerator IEnumerable.GetEnumerator()
    {
       return this.GetEnumerator();
    }
    //泛型：实现IEnumerable<T>.GetEnumerator()方法
    public IEnumerator<Customer> GetEnumerator()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            yield return customers[i];
        } 
    }

    //通过自定义Add方法来进行自定义的类型验证
    public void Add(Customer newCustomer)
    {
        if (newCustomer.CustomerID.StartsWith("A")|| newCustomer.CustomerID.StartsWith("a"))
        {
            customers.Add(newCustomer);
        }
        else
        {
            Console.WriteLine("Invalid customer ID");
        }
    }
    
}