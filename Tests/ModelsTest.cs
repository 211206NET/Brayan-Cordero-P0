using Xunit;
using Models;
using System.Collections.Generic;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void CreateNewStore()
    {
        
        Storefront testStore = new Storefront();
        
        Assert.NotNull(testStore);
    }

    [Fact]
    public void StoreShouldSetData()
    {
        
        Storefront testStore = new Storefront();
        string name = "Test Name";
        string address ="Test Address";
        string city = "Test City";
        string state = "Test State";

        
        testStore.Name = name;
        testStore.Address = address;
        testStore.City = city;
        testStore.State = state;

        
        Assert.Equal(name,testStore.Name);
        Assert.Equal(address,testStore.Address);
        Assert.Equal(city,testStore.City);
        Assert.Equal(state,testStore.State);

    }


    [Fact]
    public void OrderShouldSetData()
    {
        Order testorder = new Order();
        string OrderDate = "01/01/1990";
        string Customer ="testCustomer";
        int OrderNumber = 999;
        string StoreName ="Munchies";
        decimal Total = 12.50M;

        testorder.OrderDate = OrderDate;
        testorder.Customer = Customer;
        testorder.OrderNumber = OrderNumber;
        testorder.StoreName = StoreName;
        testorder.Total = Total;

        Assert.Equal(OrderDate, testorder.OrderDate);
        Assert.Equal(Customer, testorder.Customer);
        Assert.Equal(OrderNumber, testorder.OrderNumber);
        Assert.Equal(StoreName, testorder.StoreName);
        Assert.Equal(Total, testorder.Total);


    }

    [Fact]
    public void CustomerShouldSetData()
    {
        Customer testCustomer = new Customer();

        string UserName = "testUsername";
        string Password = "1234";
        string Email = "test@gmail.com";

        testCustomer.UserName = UserName;
        testCustomer.Password = Password;
        testCustomer.Email = Email;

        Assert.Equal(UserName, testCustomer.UserName);
        Assert.Equal(Password, testCustomer.Password);
        Assert.Equal(Email, testCustomer.Email);

    }

    [Fact]
    public void ProductShouldBeAddedToCart()
    {
        List<LineItem> testCart = new List<LineItem>();
        LineItem testlineitem = new LineItem();

    }




    
}