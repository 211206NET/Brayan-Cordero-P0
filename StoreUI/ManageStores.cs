namespace UI;
using Models;
using StoreDL;

public class store
{
    
    ManageInventory ManageInventory = new ManageInventory();
    List<Inventory> StoreInventory = new List<Inventory>();
    
    public void manageStores(List<Storefront> IncomingStores)
    {
        AllStores.allStores = IncomingStores;
        bool goBack = false;

            while(!goBack)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Create new store");
                Console.WriteLine("[2] See all stores");
                Console.WriteLine("[3] Manage Inventory");
                Console.WriteLine("[4] Go back");
                string? managerInput = Console.ReadLine();

                switch(managerInput)
                {
                case "1":
                    Storefront newStore = new Storefront();
                    Console.WriteLine("Enter Store Name:");
                    string? newName = Console.ReadLine();
                    newStore.Name= newName;
                    Console.WriteLine("Enter Address:");
                    string? newAddress = Console.ReadLine();
                    newStore.Address= newAddress;
                    Console.WriteLine("Enter City:");
                    string? newCity = Console.ReadLine();
                    newStore.City = newCity;
                    Console.WriteLine("Enter State:");
                    string? newState = Console.ReadLine();
                    newStore.State = newState;
                    AllStores.allStores.Add(newStore);
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
                Console.WriteLine("Select a Store:");
                for(int i = 0;i < AllStores.allStores.Count;i++)
                {
                    Console.WriteLine($"[{i}] {AllStores.allStores[i].Name}\n{AllStores.allStores[i].Address}\n{AllStores.allStores[i].City}\n{AllStores.allStores[i].State}");
                }
                int selection = Int32.Parse(Console.ReadLine());
                Storefront selectedStorefront = AllStores.allStores[selection];
                
                ManageInventory.manageInventory(selectedStorefront.Inventories);
                break;

                case "4":
                goBack = true;
                break;

                default:
                Console.WriteLine("Invalid input");
                break;
                }
            }
        }
}
