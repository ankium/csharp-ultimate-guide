using System;
using System.Net;
using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BLLContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
namespace HarshaBank.Presentation;

public static class CustomersPresentation
{
    internal static void AddCustomer()
    {
        try
        {
            //create an object of Customer
            Customer customer = new Customer();

            //read all details from the user
            System.Console.WriteLine("\n******ADD CUSTOMER******");

            System.Console.WriteLine("Customer Name");
            customer.CustomerName = System.Console.ReadLine();

            System.Console.WriteLine("Customer Address");
            customer.Address = System.Console.ReadLine();

            System.Console.WriteLine("Customer City");
            customer.City = System.Console.ReadLine();

            System.Console.WriteLine("Landmark");
            customer.Landmark = System.Console.ReadLine();

            System.Console.WriteLine("Customer Country");
            customer.Country = System.Console.ReadLine();

            System.Console.WriteLine("Customer Mobile");
            customer.Mobile = System.Console.ReadLine();

            ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
            Guid newCustomerGuid = customersBusinessLogicLayer.AddCustomer(customer);

            List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newCustomerGuid);
            if (matchingCustomers.Count >= 1)
            {
                System.Console.WriteLine("Customer Code is:"+matchingCustomers[0].CustomerCode);
                System.Console.WriteLine("Customer Add successfuly.it's Customer Code:"+matchingCustomers[0].CustomerCode);
            }
            else
            {
                System.Console.WriteLine("Customer Not Added.\n");
            }
        }
        catch (System.Exception ex)
        {

            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine(ex.GetType);
        }
    }

    internal static void ViewCustomer()
    {
        try
        {
            //Create BL object
            ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
            List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
            System.Console.WriteLine("\n******ALL CUSTOMERS******");
            //read all customers
            foreach (Customer item in allCustomers)
            {
                System.Console.WriteLine("Customer Code:" + item.CustomerCode);
                System.Console.WriteLine("Customer Name:" + item.CustomerName);
                System.Console.WriteLine("Customer Address:" + item.Address);
                System.Console.WriteLine("Customer City:" + item.City);
                System.Console.WriteLine("Customer Landmark:" + item.Landmark);
                System.Console.WriteLine("Customer Country:" + item.Country);
                System.Console.WriteLine("Customer Mobile:"+item.Mobile);
            }
        }
        catch (System.Exception ex)
        {

            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine(ex.GetType);
        }
    }
}
