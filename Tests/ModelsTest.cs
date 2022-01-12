using Xunit;
using Models;
using System.Collections.Generic;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void CreateNewStore()
    {
        //Arrange
        //Arrange step in this case was to make sure I had added reference to namespace Models

        //Act: test what you want this to do
        // in this case I want to make sure I can create a new object StoreFront
        Storefront testStore = new Storefront();

        //Assert: assert that testStore was created and is not null
        Assert.NotNull(testStore);
    }

    [Fact]
    public void StoreShouldSetData()
    {
        //Arrange
        //create data to test it
        Storefront testStore = new Storefront();
        string name = "Test Name";
        string address ="Test Address";
        string city = "Test City";
        string state = "Test State";

        //Act: set data to testStore
        testStore.Name = name;
        testStore.Address = address;
        testStore.City = city;
        testStore.State = state;

        //Assert: I want to assert that name was set to testStore.Name and so on
        Assert.Equal(name,testStore.Name);
        Assert.Equal(address,testStore.Address);
        Assert.Equal(city,testStore.City);
        Assert.Equal(state,testStore.State);

    }


    





    
}