--1. Create a report that shows the order ids and the associated employee names for orders that shipped after the required date (37 rows)
SELECT e.FirstName, e.LastName, o.OrderID
FROM Employees e JOIN Orders o ON
	(e.EmployeeID = o.EmployeeID)
WHERE o.RequiredDate < o.ShippedDate
ORDER BY e.LastName, e.FirstName;

-- 2. Create a report that shows the total quantity of products (from the Order_Details table) ordered. Only show records for products for which the quantity ordered is fewer than 200 (5 rows)
SELECT p.ProductName, SUM(od.Quantity) AS TotalUnits
FROM [Order Details] od JOIN Products p ON
	(p.ProductID = od.ProductID)
GROUP BY p.ProductName
HAVING SUM(Quantity) < 200;

-- 3. Create a report that shows the total number of orders by Customer since December 31, 1996. The report should only return rows for which the total number of orders is greater than 15 (5 rows)
SELECT c.CompanyName, COUNT(o.OrderID) AS NumOrders
FROM Customers c JOIN Orders o ON
	(c.CustomerID = o.CustomerID)
WHERE OrderDate > '1996-12-31'
GROUP BY c.CompanyName
HAVING COUNT(o.OrderID) > 15
ORDER BY NumOrders DESC;
