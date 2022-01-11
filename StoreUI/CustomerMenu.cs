namespace UI;
using Models;
using StoreDL;
public class CustomerMenu
{
    public void customerMenu(Customer incomingCustomer)
    {
        Console.WriteLine($"{incomingCustomer.Id}");
        DBREPO dbRepoStores = new DBREPO();
        // List<Order> SelectedStoreOrder = new List<Order>();
        List<Inventory> StoreInventory = new List<Inventory>();
        List<Order> newOrderList = new List<Order>();
        List<LineItem> cart = new List<LineItem>();
        bool exit = false;
        Console.WriteLine("Successfull Login");
        while(!exit)
        {
        Console.WriteLine("what would you like to do?");
        Console.WriteLine("[1] See all stores");
        Console.WriteLine("[2] Add Items to Cart");
        Console.WriteLine("[3] See Cart");
        Console.WriteLine("[4] See order History");
        Console.WriteLine("[5] Logout ");
        string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                // DBREPO dbRepoStores = new DBREPO();
                List<Storefront> allstores = dbRepoStores.AllStores();
                foreach(Storefront store in allstores)
                {
                    Console.WriteLine($"{store.Name}\n{store.Address}\n{store.City}\n{store.State}");
                    Console.WriteLine("************************************");
                }
                break;

                case "2":
                    //select a store to display inventory
                    
                    // DBREPO dbRepoStores = new DBREPO();
                    
                    // Product productAddToCart = new Product();
                    bool stopAdding = false;
                    List<Storefront> selectStores = dbRepoStores.AllStores();
                    Console.WriteLine("Select a Store:");
                    for(int i = 0;i < selectStores.Count;i++)
                    {
                        Console.WriteLine($"[{i}] {selectStores[i].Name}\n{selectStores[i].Address}\n{selectStores[i].City}\n{selectStores[i].State}");
                    }
                    int selection = Int32.Parse(Console.ReadLine());

                    Console.WriteLine($"You Selected:\n{selectStores[selection].Name}\n******************");

                    while(!stopAdding)
                    {
                        LineItem addToCart = new LineItem();
                        Product productToAdd = new Product();
                        Console.WriteLine("Select an item to add to cart: ");

                        StoreInventory = dbRepoStores.StoreInventory(selectStores[selection]);
                        for (int i=0; i<StoreInventory.Count;i++ )
                        {
                            Console.WriteLine($"[{i}] Name: {StoreInventory[i].Item.ProductName}\nDescription: {StoreInventory[i].Item.Description}");
                            Console.WriteLine($"Price: {StoreInventory[i].Item.Price}");
                            Console.WriteLine("**************");
                        }
                        int selectedProduct = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"you selected: {StoreInventory[selectedProduct].Item.ProductName}");
                        Console.WriteLine("How many would you like to add:");
                        int quantity = Int32.Parse(Console.ReadLine());
                        //set values to product
                        productToAdd.ProductName = StoreInventory[selectedProduct].Item.ProductName;
                        productToAdd.Description = StoreInventory[selectedProduct].Item.Description;
                        productToAdd.Price = StoreInventory[selectedProduct].Item.Price;
                        productToAdd.ID = StoreInventory[selectedProduct].Item.ID;
                        //set values to lineitem
                        addToCart.Item = productToAdd;
                        addToCart.Quantity = quantity;
                        //add to cart list
                        cart.Add(addToCart);

                        Console.WriteLine("would you like to add another? [y/n]");
                        string addAnother = Console.ReadLine();
                        if(addAnother == "n")
                        {
                            stopAdding = true;
                        }

                    }
                    
                    
                    
                    
                    // Order newOrder = new Order();
                    // List<LineItem> addedToCart = new List<LineItem>();
                    // bool goToTotal = false;
                    // while(!goToTotal)
                    // {
                    //     LineItem cart = new LineItem();
                    //     for ( int item =0; item < selectedStorefront.Inventories.Count; item++ )
                    //         {
                    //         Console.WriteLine($"Item:[{item}] {selectedStorefront.Inventories[item].Item.ProductName} Description: {selectedStorefront.Inventories[item].Item.Description}");
                    //         Console.WriteLine($"Price: {selectedStorefront.Inventories[item].Item.Price} Quantity: {selectedStorefront.Inventories[item].Quantity}");
                    //         }
                    //         Console.WriteLine("******************************");
                        
                    //     Console.WriteLine("Select an Item to add");
                    //     int ItemSelected = Int32.Parse(Console.ReadLine());

                    //     Product ProductToAdd = new Product();
                    //     ProductToAdd.ProductName = selectedStorefront.Inventories[ItemSelected].Item.ProductName;
                    //     ProductToAdd.Price = selectedStorefront.Inventories[ItemSelected].Item.Price;
                    //     cart.Item = ProductToAdd;

                    //     Console.WriteLine($"item selected:{cart.Item.ProductName} price: {cart.Item.Price}");
                    //     Console.WriteLine("How many would you like to add:");
                    //     int QuantityToAdd = Int32.Parse(Console.ReadLine());
                    //     cart.Quantity = QuantityToAdd;
                    //     Console.WriteLine("you added: " +cart.Quantity);
                    //     addedToCart.Add(cart);
                    //     Console.WriteLine("would you like to add another Item? \n[y/n]");
                    //     string? addAnother = Console.ReadLine();
                    //     if (addAnother == "n")
                    //     {
                    //         goToTotal = true;
                    //     }
                    // }
                    // newOrder.LineItems = addedToCart;
                    // newOrder.CalculateTotal();
                    // Console.WriteLine($"Total: {newOrder.Total}");
                    
                    // newOrder.OrderDate = DateOnly.FromDateTime(DateTime.Now);
                
                    // newOrder.Customer = incomingCustomer.UserName;
                    // newOrderList.Add(newOrder);
                    // incomingCustomer.Orders = newOrderList;
                    // selectedStorefront.Orders = newOrderList;

                break;

                case "3":
                    foreach(LineItem item in cart)
                    {
                        Console.WriteLine($"Name: {item.Item.ProductName} {item.Quantity}");
                    }
                break;

                case "4":
                Console.WriteLine("Order History");
                foreach(Order OrderHistory in incomingCustomer.Orders)
                {
                    Console.WriteLine($"Customer: {OrderHistory.Customer}\nDate of purchase: {OrderHistory.OrderDate}\nPurchase Total: {OrderHistory.Total}");
                }
                break;

                case "5":
                    exit = true;
                break;

                default:
                    Console.WriteLine("Invalid input");
                break;
                
            }
        }


        
    }
}