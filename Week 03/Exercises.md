# Week 03 - SQL / ADO.NET / Entity Framework

## Exercise *Simple SQL Queries*
Use the Northwind Demo Database. Write the queries for the following:  
1. Get all columns from the tables Customers, Orders and Suppliers  
2. Get all Customers alphabetically, by Country and name  
3. Get all Orders by date  
4. Get the count of all Orders made during 1997  
5. Get the names of all the contact persons where the person is a manager, alphabetically   
6. Get all orders placed on the 19th of May, 1997  

## Exercise *Library ER-Diagram*
Remember the exercise you did with the Library.  
We will work with just the Library and the Books.  
Remember:  
+ One Library  
+ Lots of Books  
+ Books have Authors, title, and ISBN (a unique id)  
1. Define all the entities  
2. Define all the attributes of the entities  
3. Define all the relationships between the entities  
4. Go to [https://www.draw.io/](https://www.draw.io/) and draw the ER-Diagram of the above.   


## Exercise *Your project's ER-Diagram*
In this exercise you will draw the ER-Diagram of your project's database.  
At first each member of your project's team should do by themselves the following:  
1. Define all the entities  
2. Define all the attributes of the entities  
3. Define all the relationships between the entities  
4. Go to [https://www.draw.io/](https://www.draw.io/) and draw the ER-Diagram of the above.  
5. Now all the team members must sit together and compare their diagrams.  
The ultimate goal of this exercise is to conclude the  your project's ER-Diagram  


## Exercise *SQL Queries for JOINS*
Using the Northwind Database, write the queries for the following:  
1. Create a report for all the orders of 1996 and their Customers (152 rows)  
2. Create a report that shows the number of	employees and customers from each city that has employees in it (5 rows)  
3. Create a report that shows the number of employees and customers from each city that has customers in it (69 rows)  
4. Create a report that shows the number of employees and customers from each city (71 rows)  


## Exercise *SQL Queries for HAVING*
1. Create a report that shows the order ids and the associated employee names for orders that shipped after the required date (37 rows)  
2. Create a report that shows the total quantity of products (from the Order_Details table) ordered. Only show records for products for which the quantity ordered is fewer than 200 (5 rows)  
3. Create a report that shows the total number of orders by Customer since December 31, 1996. The report should only return rows for which the total number of orders is greater than 15 (5 rows)  


## Exercise *SQL Inserting Records*
(Hint: use transactions)  
1. Insert yourself into the Employees table  
    * Include the following fields: LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, City, Region, PostalCode, Country, HomePhone, ReportsTo  
2. Insert an order for yourself in the Orders table  
    * Include the following fields: CustomerID, EmployeeID, OrderDate, RequiredDate  
3. Insert order details in the Order_Details table  
    * Include the following fields: OrderID, ProductID, UnitPrice, Quantity, Discount  


## Exercise *SQL Updating Records*
(Hint: use transactions)  
1. Update the phone of yourself (from the previous entry in Employees table) (1 row)  
2. Double the quantity of the order details record you inserted before (1 row)  
3. Repeat previous update but this time update all orders associated with you (1 row)  


## Exercise *SQL Deleting Records*
(Hint: use transactions)  
1. Delete the records you inserted before. Don't delete any other records!  
