-- 1. Create a report for all the orders of 1996 and their Customers (152 rows)
SELECT * 
FROM Customers c 
	JOIN Orders o on c.CustomerID = o.CustomerID
where o.OrderDate BETWEEN '1996-01-01' AND '1996-12-31';


-- 2. Create a report that shows the number of	employees and customers from each city that has employees in it (5 rows)
SELECT 
	COUNT(DISTINCT e.EmployeeID) AS numEmployees,
	COUNT(DISTINCT c.CustomerID) AS numCompanies,
	e.City AS employeeCity, 
	c.City AS customerCity
FROM Employees e LEFT JOIN Customers c ON
	(e.City = c.City)
GROUP BY e.City, c.City
ORDER BY numEmployees DESC;

--3. Create a report that shows the number of employees and customers from each city that has customers in it.
SELECT 
	COUNT(DISTINCT e.EmployeeID) AS numEmployees,
	COUNT(DISTINCT c.CustomerID) AS numCompanies,
	e.City AS employeeCity, 
	c.City AS customerCity
FROM Employees e RIGHT JOIN Customers c ON
	(e.City = c.City)
GROUP BY e.City, c.City
ORDER BY numEmployees DESC;


-- 4. Create a report that shows the number of employees and customers from each city.
SELECT 
	COUNT(DISTINCT e.EmployeeID) AS numEmployees,
	COUNT(DISTINCT c.CustomerID) AS numCompanies,
	e.City AS employeeCity, 
	c.City AS customerCity
FROM Employees e FULL JOIN Customers c ON
	(e.City = c.City)
GROUP BY e.City, c.City
ORDER BY numEmployees DESC;

-- Helper SELECT to understand what each JOIN returns
SELECT 
	e.EmployeeID AS employees,
	c.CustomerID AS companies,
	e.City AS employeeCity, 
	c.City AS customerCity
FROM Employees e INNER JOIN Customers c ON
	(e.City = c.City)
GROUP BY e.EmployeeID, c.CustomerID, e.City, c.City;