
namespace UI;
using StoreDL;

public class ManagerMenu
{

    public void managerMenu()
    {
    
    store manageStores = new store();
    bool exit = false;

    while(!exit)
    {
        Console.WriteLine("Hello Brayan");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1] Manage Store info");
        Console.WriteLine("[2] nothing");
        Console.WriteLine("[3] Manage Customers ");
        Console.WriteLine("[4] Exit");
        string? input = Console.ReadLine();

        switch(input)
        {
            case "1":
            manageStores.manageStores(AllStores.allStores);

            break;

            case "2":
            
            break;

            case "3":
            Console.WriteLine("customers");
            break;

            case "4":
            exit = true;
            break;

            default:
            Console.WriteLine("invalid input");
            break;


        }



    }





        


    }
}