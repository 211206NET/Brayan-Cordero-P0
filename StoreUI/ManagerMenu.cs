
namespace UI;
using StoreDL;
using Models;

public class ManagerMenu
{
    List<Inventory> StoreInventory = new List<Inventory>();
    public void managerMenu()
    {
    
    store manageStores = new store();
    bool exit = false;

    while(!exit)
    {
        Console.WriteLine("Hello Brayan");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1] Manage Store info");
        Console.WriteLine("[2] See all Stores");
        Console.WriteLine("[3] See all Customers ");
        Console.WriteLine("[4] Exit");
        string? input = Console.ReadLine();

        switch(input)
        {
            case "1":
            manageStores.manageStores(AllStores.allStores);

            break;

            case "2":
            foreach(Storefront store in AllStores.allStores)
                {
                    Console.WriteLine($"{store.Name}\n{store.Address}\n{store.City}\n{store.State}");
                    // Console.WriteLine("length of item" + StoreInventory.Count() );
                    StoreInventory = store.Inventories;
                    foreach( Inventory inventory in StoreInventory )
                    {
                        Console.WriteLine($"Item: {inventory.Item.ProductName} Description: {inventory.Item.Description}");
                        Console.WriteLine($"Price: {inventory.Item.Price} Quantity: {inventory.Quantity}");
                    }
                    Console.WriteLine("************************************");
                }
            break;

            case "3":
            foreach(Customer customers in AllCustomers.allCustomers)
            {
                Console.WriteLine($"Customer: {customers.UserName} Email: {customers.Email}");
                Console.WriteLine("***************************");
            }
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