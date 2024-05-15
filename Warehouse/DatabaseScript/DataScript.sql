USE WarehouseDB;
GO

INSERT INTO Country (CountryName) VALUES 
('Poland'),
('Germany'),
('France');
GO

INSERT INTO Voivodeship (VoivodeshipName, CountryID) VALUES 
('Mazowieckie', 1),
('Wielkopolskie', 1),
('Bavaria', 2),
('Île-de-France', 3);
GO

INSERT INTO City (CityName, VoivodeshipID, PostalCode) VALUES 
('Warsaw', 1, '00-001'),
('Poznan', 2, '60-001'),
('Munich', 3, '80331'),
('Paris', 4, '75000');
GO

INSERT INTO Address (Number, CityID) VALUES 
(123, 1),
(456, 2),
(789, 3),
(101, 4);
GO

INSERT INTO ProductTypes (ProductTypeName) VALUES 
('Electronics'),
('Groceries'),
('Clothing');
GO

INSERT INTO Products (ProductName, ProductTypeID, Price) VALUES 
('Laptop', 1, 1200.00),
('Bread', 2, 1.50),
('T-Shirt', 3, 15.00);
GO

INSERT INTO Customers (CustomerName, CustomerLastName, Email, Phone, AddressID) VALUES 
('John', 'Doe', 'john.doe@example.com', '123456789', 1),
('Jane', 'Smith', 'jane.smith@example.com', '987654321', 2),
('Max', 'Mustermann', 'max.mustermann@example.com', '555666777', 3),
('Marie', 'Curie', 'marie.curie@example.com', '111222333', 4);
GO

INSERT INTO OrderMethod (MethodName) VALUES 
('Online'),
('In-Store'),
('Phone');
GO

INSERT INTO Orders (CustomerID, OrderMethodID, OrderDate, TotalAmount) VALUES 
(1, 1, GETDATE(), 1215.00),
(2, 2, GETDATE(), 1.50),
(3, 3, GETDATE(), 15.00);
GO

INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price) VALUES 
(1, 1, 1, 1200.00),
(2, 2, 1, 1.50),
(3, 3, 1, 15.00);
GO

INSERT INTO ReturnReason (ReasonDescription) VALUES 
('Damaged'),
('Not as described'),
('Changed mind');
GO

INSERT INTO OrderReturn (OrderDetailID, ReturnDate, Quantity, ReturnReasonID) VALUES 
(1, GETDATE(), 1, 1),
(2, GETDATE(), 1, 2),
(3, GETDATE(), 1, 3);
GO
