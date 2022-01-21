SELECT*FROM Orders;
SElECT*FROM Customer;
SELECT*FROM StoreFront;
SELECT*FROM Product;
SELECT*FROM Inventory;



--DELETE FROM Product WHERE Name= '';
--DELETE FROM Inventory WHERE ProductID = '';


--Inventory list of a selected store
SELECT Inventory.ID, Inventory.Quantity, Product.Name,Product.Description, Product.Price, StoreFront_ID
FROM Inventory
INNER JOIN Product ON Inventory.ProductID = Product.ID
--WHERE StoreFront_ID='1';

--Orders of a customer
SELECT Orders.ID, Orders.OrderDate, Storefront.Name, Customer.Username, Orders.TOTAL
FROM Orders
INNER JOIN Customer ON Orders.Customer_ID = Customer.ID
INNER JOIN Storefront ON Orders.StoreFront_ID = Storefront.ID
--WHERE Customer_ID='1';


CREATE TABLE Inventory(
    ID INT PRIMARY KEY IDENTITY,
    Quantity INT,
    ProductID  INT FOREIGN KEY REFERENCES Product(ID),
    StoreFront_ID INT FOREIGN KEY REFERENCES StoreFront(ID)
);

CREATE TABLE StoreFront(
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(25) NOT NULL,
    Address NVARCHAR(40) NOT NULL,
    City NVARCHAR(30) NOT NULL,
    State NVARCHAR(10) NOT NULL,

)

CREATE TABLE Customer(
    ID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(30) NOT NULL,
    Password NVARCHAR(20) NOT NULL,
    Email NVARCHAR(30) NOT NULL
);

CREATE TABLE Orders(
    ID INT PRIMARY KEY IDENTITY,
    OrderDate NVARCHAR(15) NOT NULL,
    StoreFront_ID INT FOREIGN KEY REFERENCES StoreFront(ID),
    Customer_ID INT FOREIGN KEY REFERENCES Customer(ID),
    TOTAL DECIMAL(5,2) NOT NULL
);

CREATE TABLE Staff(
    ID INT PRIMARY KEY IDENTITY,
    NAME NVARCHAR(25) NOT NULL,
    Password NVARCHAR(20) NOT NULL,
    Tittle NVARCHAR(10) NOT NULL,
);

--DROP TABLE Orders
--INSERT INTO Staff () VALUES ('');
