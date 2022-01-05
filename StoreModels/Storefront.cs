namespace Models;


public class Storefront
{
    public string? Address { get; set; }
    public string? State {get; set; }
    public string? City {get; set; }
    public string? Name { get; set; }
    public List<Inventory> Inventories { get; set; }
    public List<Order> Orders { get; set; }

    public Storefront(){
        this.Inventories = new List<Inventory>();
        this.Orders = new List<Order>();
    }





}