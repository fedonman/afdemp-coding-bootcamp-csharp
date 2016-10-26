-- 1. What were our total revenues in 1997
SELECT SUM(ROUND(OD.Quantity * OD.UnitPrice * (1 - OD.Discount), 2))
FROM Orders O
	JOIN [Order Details] OD on O.OrderID = OD.OrderID
WHERE O.OrderDate BETWEEN '1997-01-01' AND '1997-12-31';

-- 2. What is the total amount each customer has payed us so far
SELECT C.CustomerID, C.CompanyName, ISNULL(SUM(ROUND(OD.Quantity * OD.UnitPrice * (1 - OD.Discount), 2)), 0) [Total]
FROM Customers C
	LEFT JOIN Orders O ON C.CustomerID = O.CustomerID
	LEFT JOIN [Order Details] OD on O.OrderID = OD.OrderID
GROUP BY C.CustomerID, C.CompanyName
ORDER BY Total

-- 3. Find the 10 top selling products
select TOP 10 ode.ProductID, ode.ProductName, SUM(ode.ExtendedPrice) [Total]
from [Order Details Extended] as ode
group by ode.ProductID, ode.ProductName
order by Total DESC

-- 4. Create a view with total revenues per customer
if exists(select * from INFORMATION_SCHEMA.VIEWS where TABLE_NAME = [Total Revenues per Customer])
	drop view [Total Revenues per Customer]
GO
create view [Total Revenues per Customer] as
SELECT C.CustomerID, C.CustomerName, C.CompanyName, ISNULL(SUM(ROUND(OD.Quantity * OD.UnitPrice * (1 - OD.Discount), 2)), 0) [Total]
FROM Customers C
	LEFT JOIN Orders O ON C.CustomerID = O.CustomerID
	LEFT JOIN [Order Details] OD on O.OrderID = OD.OrderID
GROUP BY C.CustomerID, C.CompanyName
ORDER BY Total;
GO

-- 5. Which UK Customers have payed us more than 1000 dollars
SELECT C.CustomerID, C.CompanyName, ISNULL(SUM(ROUND(OD.Quantity * OD.UnitPrice * (1 - OD.Discount), 2)), 0) [Total]
FROM Customers C
	LEFT JOIN Orders O ON C.CustomerID = O.CustomerID
	LEFT JOIN [Order Details] OD on O.OrderID = OD.OrderID
WHERE C.Country = 'UK'
GROUP BY C.CustomerID, C.CompanyName
HAVING ISNULL(SUM(ROUND(OD.Quantity * OD.UnitPrice * (1 - OD.Discount), 2)), 0) > 1000;

-- 6. How much has each customer payed in total and how much in 1997.
-- with subqueries
SELECT SubQueryTotals.* , ISNULL(SubQueryTotals1997.[Customer Total 1997], 0) [Customer Total 1997]
FROM
(
	select c.CustomerID,
			CompanyName,
			Country,
			ISNULL(sum(os.Subtotal), 0) as [Customer Total]
	from [Order Subtotals] os
		right join Orders o on o.OrderID = os.OrderID
		right join Customers c on c.CustomerID = o.CustomerID
	group by c.CustomerID, CompanyName, Country
) SubQueryTotals
LEFT JOIN
(
	select c.CustomerID,
			CompanyName,
			Country,
			ISNULL(sum(os.Subtotal), 0) as [Customer Total 1997]
	from [Order Subtotals] os
		right join Orders o on o.OrderID = os.OrderID
		right join Customers c on c.CustomerID = o.CustomerID
	where o.OrderDate is null
		or o.OrderDate BETWEEN '1997-01-01' AND '1997-12-31'
	group by c.CustomerID, CompanyName, Country
) SubQueryTotals1997 ON SubQueryTotals.CustomerID = SubQueryTotals1997.CustomerID
ORDER BY SubQueryTotals.CompanyName;

-- OR
-- with temporary tables

select c.CustomerID,
		CompanyName,
		Country,
		ISNULL(sum(os.Subtotal), 0) as [Customer Total]
INTO #TempTableTotals
from [Order Subtotals] os
	right join Orders o on o.OrderID = os.OrderID
	right join Customers c on c.CustomerID = o.CustomerID
group by c.CustomerID, CompanyName, Country;

select c.CustomerID,
		CompanyName,
		Country,
		ISNULL(sum(os.Subtotal), 0) as [Customer Total 1997]
INTO #TempTableTotals1997
from [Order Subtotals] os
	right join Orders o on o.OrderID = os.OrderID
	right join Customers c on c.CustomerID = o.CustomerID
where o.OrderDate is null
	or o.OrderDate BETWEEN '1997-01-01' AND '1997-12-31'
group by c.CustomerID, CompanyName, Country;


SELECT T.* , ISNULL(T1997.[Customer Total 1997], 0) [Customer Total 1997]
FROM  #TempTableTotals T
	LEFT JOIN #TempTableTotals1997 T1997 ON T.CustomerID = T1997.CustomerID
ORDER BY T.CompanyName;

DROP TABLE #TempTableTotals
DROP TABLE #TempTableTotals1997
