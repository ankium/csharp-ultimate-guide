using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
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
        //调用自定义集合类实现的接口方法
        Console.WriteLine(customersList.Count);
        customersList.Add(customer1);
        customersList.Add(customer2);
        foreach (Customer cust in customersList)
        {
            Console.WriteLine(cust.CustomerID+","+cust.CustomerName+","+cust.CustomerEmail+","+cust.TypeOfCustomer);
        }
        customersList.Remove(customer2);
        Console.WriteLine("customersList Contains B107:" + customersList.Contains(customer2));
        Customer customer3 = new Customer() { CustomerID = "A108", CustomerName = "bili", CustomerEmail = "bili@msn.cn", TypeOfCustomer = TypeOfCustomer.RegularCustomer };
        customersList.Insert(3, customer3);
        Console.WriteLine(customersList.IndexOf(customer3)+","+customer3.CustomerID+","+customer3.CustomerName+","+customer3.CustomerEmail+","+customer3.TypeOfCustomer);
        customersList.RemoveAt(2);
        Customer customer4 = new Customer()
        {
            CustomerID = "A108",
            CustomerName = "bili",
            CustomerEmail = "bili@msn.cn",
            TypeOfCustomer = TypeOfCustomer.RegularCustomer
        };
        Console.WriteLine("customersList Contains B108:" + customersList.Contains(customer4));
    }
}

public enum TypeOfCustomer
{
    RegularCustomer,
    VIPCustomer
}

public class Customer:IEquatable<Customer>
{
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public TypeOfCustomer TypeOfCustomer { get; set; }

    //实现IEquatable<T>接口的Equals方法
    public bool Equals(Customer? other)
    {
        return this.CustomerID == other?.CustomerID && this.CustomerName == other?.CustomerName && this.CustomerEmail == other?.CustomerEmail && this.TypeOfCustomer == other?.TypeOfCustomer;
    }
}

//自定义集合类对象
public class CustomersList : IList<Customer>
{
    //集合内部硬编码类对象
    private List<Customer> customers = new List<Customer>()
    {
        new Customer(){CustomerID = "A101", CustomerName = "jone",CustomerEmail = "jones@msn.cn",TypeOfCustomer = TypeOfCustomer.VIPCustomer},
        new Customer(){CustomerID = "A102",CustomerName = "mane",CustomerEmail = "mane@msn.cn",TypeOfCustomer = TypeOfCustomer.RegularCustomer},
        new Customer(){CustomerID = "A103",CustomerName = "jeny",CustomerEmail = "jeny@msn.cn",TypeOfCustomer = TypeOfCustomer.VIPCustomer}
    };

    //实现ICollection<T>接口属性
    public int Count => customers.Count;

    //实现ICollection<T>接口属性
    public bool IsReadOnly => false;

    //实现IList<T>接口的索引
    public Customer this[int index] { get => customers[index]; set => customers[index]=value; }

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

    //实现ICollection<T>接口的Add方法来进行自定义的类型验证
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

    //实现ICollection<T>接口的Clear方法
    public void Clear()
    {
        customers.Clear();
    }
    //实现ICollection<T> 接口的Contains方法
    public bool Contains(Customer item)
    {
        return customers.Contains(item);
    }
    //实现ICollection<T>接口的CopyTo方法
    public void CopyTo(Customer[] array, int arrayIndex)
    {
        customers.CopyTo(array, arrayIndex);
    }
    //实现ICollection<T> 接口的Remove方法
    public bool Remove(Customer item)
    {
        return customers.Remove(item);
    }
    //实现IList<T>接口的IndexOf方法
    public int IndexOf(Customer item)
    {
        return customers.IndexOf(item);
    }
    //实现IList<T>接口的Insert方法
    public void Insert(int index, Customer item)
    {
        if (!(index<0))
        {
            customers.Insert(index, item);
        }
        else
        {
            Console.WriteLine("Invalid Index");
        }
        
    }
    //实现IList<T>接口的RemoveAt方法
    public void RemoveAt(int index)
    {
        if (!(index<0))
        {
            customers.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid Index");
        }
        
    }
}