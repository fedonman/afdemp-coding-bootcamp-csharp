BEGIN TRANSACTION

-- 1. Insert yourself into the Employees table
INSERT INTO Employees
(LastName, FirstName, Title, TitleOfCourtesy, 
	BirthDate, HireDate, City, Region, 
	PostalCode, Country, HomePhone, ReportsTo)
VALUES('Vasileiadis','Vyron','Trainer','Mr.',
	'1989-02-21','2016-10-01','Athens', NULL,
	'11146','Greece','315-555-5555','1');

-- Declare variable myEmployeeID with value the ID of the inserted entry
DECLARE @myEmployeeID int = SCOPE_IDENTITY();
 
-- 2. Insert an order for yourself in the Orders table
INSERT INTO Orders
(CustomerID, EmployeeID, OrderDate, RequiredDate)
VALUES('COMMI',@myEmployeeID,'2016-10-25','2016-10-30');

-- Declare variable myOrderID with value the ID of the inserted entry
DECLARE @myOrderID int = SCOPE_IDENTITY();
-- Declare variable myProductID with value the ID of a random Product
DECLARE @myProductID int = 3;

-- 3. Insert order details in the Order_Details table
INSERT INTO [Order Details]
(OrderID, ProductID, UnitPrice, Quantity, Discount)
VALUES(@myOrderID, @myProductID, 10, 100, 0.1);

COMMIT

-- Print Results
select EmployeeID, LastName, FirstName from Employees;
select * from Orders where OrderID = @myOrderID;
select * from [Order Details] where OrderId = @myOrderID;

BEGIN TRANSACTION

update Employees 
	set HomePhone = '210 21xxxxx' 
	where EmployeeID = @myEmployeeID;

update [Order Details] 
	set Quantity = 2 * Quantity 
	where OrderID = @myOrderID and ProductID = @myProductID;

update [Order Details]
	set Quantity = 2 * Quantity
	from [Order Details]
	join Orders on Orders.OrderID = [Order Details].OrderID
	where Orders.EmployeeID = @myEmployeeID;

COMMIT

select * from [Order Details] where OrderId = @myOrderID and ProductID = @myProductID;  

BEGIN TRANSACTION

delete from [Order Details] where OrderID = @myOrderID;
delete from Orders where EmployeeID = @myEmployeeID;
delete from Employees where EmployeeID = @myEmployeeID;

COMMIT

select EmployeeID, FirstName, LastName from Employees;
select * from [Order Details] where OrderId = @myOrderID;

/*
select * from Orders where EmployeeID = 15;
delete from [Order Details] where OrderID = 11082;
delete from Orders where EmployeeID = 14;
delete from Employees where EmployeeID = 14;
*/