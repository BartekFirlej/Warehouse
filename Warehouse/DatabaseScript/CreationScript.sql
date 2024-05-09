CREATE DATABASE WarehouseDB;
GO

CREATE TABLE Country (
    CountryID INT PRIMARY KEY IDENTITY(1,1),
    CountryName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Voivodeship (
    VoivodeshipID INT PRIMARY KEY IDENTITY(1,1),
    VoivodeshipName NVARCHAR(100) NOT NULL,
    CountryID INT,
    CONSTRAINT FK_Voivodeship_Country FOREIGN KEY (CountryID) REFERENCES Country(CountryID)
);
GO

CREATE TABLE City (
    CityID INT PRIMARY KEY IDENTITY(1,1),
    CityName NVARCHAR(100) NOT NULL,
    VoivodeshipID INT,
    PostalCode NVARCHAR(20),
    CONSTRAINT FK_City_Voivodeship FOREIGN KEY (VoivodeshipId) REFERENCES Voivodeship(VoivodeshipID)
);
GO

CREATE TABLE Address (
    AddressID INT PRIMARY KEY IDENTITY(1,1),
    Number INT,
    CityID INT,
    CONSTRAINT FK_Address_City FOREIGN KEY (CityID) REFERENCES City(CityID)
);
GO

CREATE TABLE ProductTypes (
    ProductTypeID INT PRIMARY KEY IDENTITY(1,1),
    ProductTypeName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    ProductTypeID INT,
    Price DECIMAL(10, 2),
    CONSTRAINT FK_Product_ProductType FOREIGN KEY (ProductTypeID) REFERENCES ProductTypes(ProductTypeID)
);
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    CustomerLastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    AddressID INT,
    CONSTRAINT FK_Customers_Address FOREIGN KEY (AddressID) REFERENCES Address(AddressID)
);
GO

CREATE TABLE OrderMethod (
    OrderMethodID INT PRIMARY KEY IDENTITY(1,1),
    MethodName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    OrderMethodID INT,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    CONSTRAINT FK_Orders_OrderMethod FOREIGN KEY (OrderMethodID) REFERENCES OrderMethod(OrderMethodID)
);
GO

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

CREATE TABLE ReturnReason (
    ReturnReasonID INT PRIMARY KEY IDENTITY(1,1),
    ReasonDescription NVARCHAR(200) NOT NULL
);
GO

CREATE TABLE OrderReturn (
    ReturnID INT PRIMARY KEY IDENTITY(1,1),
    OrderDetailID INT,
    ReturnDate DATETIME,
    Quantity INT,
    ReturnReasonID INT,
    CONSTRAINT FK_Returns_OrderDetails FOREIGN KEY (OrderDetailID) REFERENCES OrderDetails(OrderDetailID),
    CONSTRAINT FK_Returns_ReturnReason FOREIGN KEY (ReturnReasonID) REFERENCES ReturnReason(ReturnReasonID)
);
GO
