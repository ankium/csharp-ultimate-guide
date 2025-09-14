namespace HarshaBank.Presentation;

class Program
{
    //Application execution starts here
    static void Main(string[] args)
    {
        //display title
        System.Console.WriteLine("********************Harsha Bank*********************");
        System.Console.WriteLine("::Login Page::");

        //declare variables to store username and password
        string userName = null, password = null;

        //read userName from keyboard
        System.Console.Write("Username:");
        userName = System.Console.ReadLine();

        if (userName != null && userName != "")
        {
            //read password from keyboard only if username is entered
            System.Console.Write("Password:");
            password = System.Console.ReadLine();
        }

        //check username and password
        if (userName == "system" && password == "manager")
        {
            //declare variable to store menu choice
            int mainMenuChoice = -1;
            do
            {
                //show main menu
                System.Console.WriteLine("\n:::Main menu:::");
                System.Console.WriteLine("1. Customers");
                System.Console.WriteLine("2. Accounts");
                System.Console.WriteLine("3. Funds Transfer");
                System.Console.WriteLine("4. Funds Transfer Statement");
                System.Console.WriteLine("5. Account Statement");
                System.Console.WriteLine("0. Exit");
            
                //accept menu choice from keyboard
                System.Console.Write("Choose an option: ");
                mainMenuChoice = int.Parse(System.Console.ReadLine());
            
                //switch-case to check menu choice
                switch (mainMenuChoice)
                {
                    case 1:CustomersMenu();
                        break;
                    case 2:
                        AccountsMenu();
                        break;
                    case 3://TO DO:Display customers menu
                        break;
                    case 4://TO DO:Display customers menu
                        break;
                    case 5://TO DO:Display customers menu
                        break;
                }
            } while (mainMenuChoice != 0);
        }
        else
        {
            System.Console.WriteLine("Invalid username or password");
        }

        //about to exit
        System.Console.WriteLine("Thank you!Visit again.");
        System.Console.ReadKey();
    }

    static void CustomersMenu()
    {
        //variable to strore customers menu choice 
        int customerMenuChoice = -1;
        
        //do-while loop starts
        do
        {
            //print customers menu
            System.Console.WriteLine("\n:::Customers Menu:::");
            System.Console.WriteLine("1. Add Customer");
            System.Console.WriteLine("2. Delete Customer");
            System.Console.WriteLine("3. Update Customer");
            System.Console.WriteLine("4. View Customers");
            System.Console.WriteLine("0. Back to Main menu");
            
            //accept customers menu choice
            System.Console.Write("Choose an option: ");
            customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());
        } while (customerMenuChoice != 0);
    }
    
    static void AccountsMenu()
    {
        //variable to strore accounts menu choice 
        int accountMenuChoice = -1;
        
        //do-while loop starts
        do
        {
            //print account menu
            System.Console.WriteLine("\n:::Accounts Menu:::");
            System.Console.WriteLine("1. Add Account");
            System.Console.WriteLine("2. Delete Account");
            System.Console.WriteLine("3. Update Account");
            System.Console.WriteLine("4. View Accounts");
            System.Console.WriteLine("0. Back to Main menu");
            
            //accept account menu choice
            System.Console.Write("Choose an option: ");
            accountMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());
        } while (accountMenuChoice != 0);
    }
}