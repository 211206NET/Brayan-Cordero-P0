namespace UI;
using Models;
using StoreDL;

public class ManageInventory
{
    public void manageInventory(List<Inventory> IncomingInventory)
    {
        // if(IncomingInventory != null) {
        //     Inventories = IncomingInventory;
        // }
        
        
        bool goback = false;
        while(!goback)
        {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1] Add Product");
        Console.WriteLine("[2] Remove Product");
        Console.WriteLine("[3] see All Products");
        Console.WriteLine("[4] Go Back");
        string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Product newProduct = new Product();
                    Inventory newItem = new Inventory();
                    Console.WriteLine("Enter Product Name:");
                    string? productName = Console.ReadLine();
                    newProduct.ProductName = productName;
                    Console.WriteLine("Enter Product Description");
                    string? productDescription = Console.ReadLine();
                    newProduct.Description = productDescription;
                    Console.WriteLine("Enter Product Price");
                    decimal productPrice = Decimal.Parse(Console.ReadLine());
                    newProduct.Price= productPrice;
                    Console.WriteLine("Enter Quantity");
                    int productQuantity = Int32.Parse(Console.ReadLine());
                    newItem.Quantity = productQuantity;
                    newItem.Item = newProduct;
                    IncomingInventory.Add(newItem);
                    
                    
                    
                    
                break;
                case "2":
                Console.WriteLine("nothing yet");
                break;
                case "3":
                foreach (Inventory inventory in  IncomingInventory)
                {
                    Console.WriteLine($"Item: {inventory.Item.ProductName} Description: {inventory.Item.Description}");
                    Console.WriteLine($"Price: {inventory.Item.Price} Quantity: {inventory.Quantity}");
                }
                break;
                case "4":
                goback = true;
                break;
                default:
                Console.WriteLine("Invalid Input");
                break;
            }
        }
    }
}
