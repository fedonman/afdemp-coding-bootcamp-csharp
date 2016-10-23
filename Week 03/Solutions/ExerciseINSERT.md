```sql
BEGIN TRANSACTION
-- 1. Insert yourself into the Employees table
INSERT INTO Employees
(LastName, FirstName, Title, TitleOfCourtesy, 
	BirthDate, HireDate, City, Region, 
	PostalCode, Country, HomePhone, ReportsTo)
VALUES('Papadakis','Michalis','Trainer','Mr.',
	'1970-02-01','1997-03-04','Athens', NULL,
	'12345','Greece','315-555-5555','1');

-- 2. Insert an order for yourself in the Orders table
INSERT INTO Orders
(CustomerID, EmployeeID, OrderDate, RequiredDate)
VALUES('COMMI',10,'2016-10-22','2016-10-30');


-- 3. Insert order details in the Order_Details table
INSERT INTO [Order Details]
(OrderID, ProductID, UnitPrice, Quantity, Discount)
VALUES(11078, 3, 10, 100, 0.1);

COMMIT 
--ROLLBACK
```