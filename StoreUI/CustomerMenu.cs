namespace UI;
using Models;
using StoreDL;
public class CustomerMenu
{
    public void customerMenu(Customer incomingCustomer)
    {
        // List<Order> SelectedStoreOrder = new List<Order>();
        List<Inventory> StoreInventory = new List<Inventory>();
        List<Order> newOrderList = new List<Order>();
        bool exit = false;
        Console.WriteLine("Successfull Login");
        while(!exit)
        {
        Console.WriteLine("what would you like to do?");
        Console.WriteLine("[1] See all stores");
        Console.WriteLine("[2] Place an order ");
        Console.WriteLine("[3] See order History");
        Console.WriteLine("[4] Logout ");
        string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    foreach(Storefront store in AllStores.allStores)
                    {
                        Console.WriteLine($"{store.Name}\n{store.Address}\n{store.City}\n{store.State}");
                        StoreInventory = store.Inventories;
                    foreach( Inventory inventory in StoreInventory )
                        {
                        Console.WriteLine($"Item: {inventory.Item.ProductName} Description: {inventory.Item.Description}");
                        Console.WriteLine($"Price: {inventory.Item.Price} Quantity: {inventory.Quantity}");
                        }
                        Console.WriteLine("******************************");
                    }
                break;

                case "2":
                    //select a store to display inventory
                    
                    Console.WriteLine("Select a store:");
                    for(int i = 0;i < AllStores.allStores.Count;i++)
                    {
                    Console.WriteLine($"[{i}] {AllStores.allStores[i].Name}\n{AllStores.allStores[i].Address}\n{AllStores.allStores[i].City}\n{AllStores.allStores[i].State}");
                    }
                    int StoreSelected = Int32.Parse(Console.ReadLine());
                    Storefront selectedStorefront = AllStores.allStores[StoreSelected];
                    Console.WriteLine($"You Selected:\n{selectedStorefront.Name}");
                    // LineItem cart = new LineItem();
                    Order newOrder = new Order();
                    List<LineItem> addedToCart = new List<LineItem>();
                    bool goToTotal = false;
                    while(!goToTotal)
                    {
                        LineItem cart = new LineItem();
                        for ( int item =0; item < selectedStorefront.Inventories.Count; item++ )
                            {
                            Console.WriteLine($"Item:[{item}] {selectedStorefront.Inventories[item].Item.ProductName} Description: {selectedStorefront.Inventories[item].Item.Description}");
                            Console.WriteLine($"Price: {selectedStorefront.Inventories[item].Item.Price} Quantity: {selectedStorefront.Inventories[item].Quantity}");
                            }
                            Console.WriteLine("******************************");
                        //add items to cart
                        Console.WriteLine("Select an Item to add");
                        int ItemSelected = Int32.Parse(Console.ReadLine());

                        Product ProductToAdd = new Product();
                        ProductToAdd.ProductName = selectedStorefront.Inventories[ItemSelected].Item.ProductName;
                        ProductToAdd.Price = selectedStorefront.Inventories[ItemSelected].Item.Price;
                        cart.Item = ProductToAdd;

                        Console.WriteLine($"item selected:{cart.Item.ProductName} price: {cart.Item.Price}");
                        Console.WriteLine("How many would you like to add:");
                        int QuantityToAdd = Int32.Parse(Console.ReadLine());
                        cart.Quantity = QuantityToAdd;
                        Console.WriteLine("you added: " +cart.Quantity);
                        addedToCart.Add(cart);
                        Console.WriteLine("would you like to add another Item? \n[y/n]");
                        string? addAnother = Console.ReadLine();
                        if (addAnother == "n")
                        {
                            goToTotal = true;
                        }
                    }
                    newOrder.LineItems = addedToCart;
                    newOrder.CalculateTotal();
                    Console.WriteLine($"Total: {newOrder.Total}");
                    //add date to orderdate
                    newOrder.OrderDate = DateOnly.FromDateTime(DateTime.Now);
                    // Console.WriteLine(newOrder.OrderDate);
                    //add new order to customer order list and storefront order list
                    // List<Order> newOrderList = new List<Order>();
                    newOrder.Customer = incomingCustomer.UserName;
                    newOrderList.Add(newOrder);
                    incomingCustomer.Orders = newOrderList;
                    selectedStorefront.Orders = newOrderList;

                    // keep asking if they would like to add another item if not checkout
                    // calculate total and add order to a list 

                break;

                case "3":
                Console.WriteLine("Order History");
                foreach(Order OrderHistory in incomingCustomer.Orders)
                {
                    Console.WriteLine($"Customer: {OrderHistory.Customer}\nDate of purchase: {OrderHistory.OrderDate}\nPurchase Total: {OrderHistory.Total}");
                }
                break;

                case "4":
                    exit = true;
                break;

                default:
                    Console.WriteLine("Invalid input");
                break;
                
            }
        }


        
    }
}