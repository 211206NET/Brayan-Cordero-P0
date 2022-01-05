namespace UI;
using Models;
using StoreDL;

public class MainMenu
{
    public void mainMenuStart()
    {

    store manageStores = new store();
    CustomerMenu customerSignIn = new CustomerMenu();
    ManagerMenu managerPortal = new ManagerMenu();

    //not permanent
    Customer Manager = new Customer();
    string managerUsername = "Manager";
    string managerPassword = "999";
    Manager.UserName = managerUsername;
    Manager.Password = managerPassword;
    AllCustomers.allCustomers.Add(Manager);
    //only to exit


    Storefront OriginalStore = new Storefront();
    string Name = "Munchies";
    OriginalStore.Name = Name;
    string Address = "626 Rancho Ave";
    OriginalStore.Address = Address;
    string City = "San Bernanrdino";
    OriginalStore.City = City;
    string State = "CA";
    OriginalStore.State = State;
    AllStores.allStores.Add(OriginalStore);

    bool exit = false;

    while (!exit)
    {
        
        Console.WriteLine("Welcome to Munchies");
        Console.WriteLine("[1] Sign In \n[2] Create New Account \n[3] exit \n[4] Admin");
        string? UserInput = Console.ReadLine();


        switch (UserInput)
        {
            case "1": 
                
                bool successfullLogin = false;
                while (!successfullLogin)
                {
                    Console.WriteLine("Enter Username");
                    string? Username = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string? Password = Console.ReadLine();
                    
                    foreach(Customer existing in AllCustomers.allCustomers)
                    {
                        if(Username == existing.UserName && Password == existing.Password )
                        {
                            customerSignIn.customerMenu(existing);
                            successfullLogin = true;
                        }
                    }
                    if(!successfullLogin)
                    {
                        Console.WriteLine("Invalid Username or Password");
                        Console.WriteLine("Please try again");
                    }
                
                }
                
                
            break;

            case "2":
                Customer newCustomer = new Customer();
                Console.WriteLine("Enter a Username:");
                string? username = Console.ReadLine();
                Console.WriteLine("Enter a Password");
                string? password = Console.ReadLine();
                Console.WriteLine("Enter an Email");
                string? email = Console.ReadLine();
                newCustomer.UserName = username;
                newCustomer.Password = password;
                newCustomer.Email = email;
                AllCustomers.allCustomers.Add(newCustomer);
                Console.WriteLine("your account has been created");
                // foreach(Customer account in AllCustomers.allCustomers)
                // {
                //     Console.WriteLine($"{account.UserName} {account.Password} {account.Email}");
                // }
            break;

            case "3":
                exit =true;
            break;
            
            case "4":
                bool ManagerLogIn = false;
                while (!ManagerLogIn)
                {
                    Console.WriteLine("Enter Username");
                    string? Username = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string? Password = Console.ReadLine();
                    if(Username == Manager.UserName && Password == Manager.Password )
                    {
                        ManagerLogIn = true;
                    }
                    
                    else if(!ManagerLogIn)
                    {
                        Console.WriteLine("Invalid Username or Password");
                        Console.WriteLine("Please try again");
                    }
                
                }
                managerPortal.managerMenu();
            break;
            default:
                Console.WriteLine("Invalid input, try again");
            break;
        }

        
    }



    }

}