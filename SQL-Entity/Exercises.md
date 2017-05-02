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
5. Add the User who rents Books and the Librarian who manages the Library and authorizes the renting.  
6. Create database and tables in SQL according to the ER-Diagram created.  
7. Add demo data to the tables.  


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


## Exercise *Advances SQL queries*
1. What were our total revenues in 1997 *(Result must be 617.085,27)*
2. What is the total amount each customer has payed us so far *(Hint: QUICK-Stop has payed us 110.277,32)*
3. Find the 10 top selling products *(Hint: Top selling product is "Côte de Blaye")*
4. Create a view with total revenues per customer 
4. Which UK Customers have payed us more than 1000 dollars *(6 rows)*
5. How much has each customer payed in total and how much in 1997.
    We want one result set with the following columns:
    * CustomerID
    * CompanyName
    * Country
    * Customer's total from all orders
    * Customer's total from 1997 orders
    
    You can try this with views, subqueries or temporary tables.
    Try using **[Order Subtotals]** view that already exists in database.
    *(91 rows, Customer "Centro comercial Moctezuma" has 100,80 total revenues and zero (0) revenues in 1997 )*


## Exercise Ef6
1. Create a new console app in VS Studio  
2. Install EntityFramework nuget package
3. Create a folder called model and add 2 classes (Blog, Post) inside it from the lectures
4. Create the Dbcontext
5. Enable migrations, create your first migration and update the database
6. Check the database that is created
7. Change the model and add User class and change Posts class according to this example

```csharp
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }

    //Navigation Property
    public virtual ICollection<Post> Posts { get; set; }
}

public class Post
{
    //Primary Key
    public int Id { get; set; }
    [MaxLength(400)]
    public string Title { get; set; }
    public string Content { get; set; }
    public int? Likes { get; set; }

    public int BlogId { get; set; }
    public int UserId { get; set; }

    //Navigation Property
    [ForeignKey("BlogId")]
    public virtual Blog Blog { get; set; }
    //Navigation Property
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}
```

8. Add a migration and update the database
9. Seed the database
10. Go to Program.cs and create some methods like the lecture to check out this things
    1. Pull data from the Database
    2. Insert in the database a new object
    3. Find Data And Update It
    4. Find Data And Delete it
    5. Pull data in a simple Join (and check it in Sql Server Profiler)
    6. Do a sum and a count test
11. If your are ready try to do a model for your project database