/*1. Get all columns from the tables Customers, Orders and Suppliers */
select * from customers;
select * from orders;
select * from suppliers;

/* 2. Get all Customers alphabetically, by Country and name */
select * from customers order by Country, ContactName;

/* 3. Get all Orders by date */
select * from orders order by OrderDate;

/* 4. Get the count of all Orders made during 1997 */
select count(*) from orders where OrderDate between '1997-01-01' and '1997-12-31 23:59:59'

/* 5. Get the names of all the contact persons where the person is a manager, alphabetically */
select contactname from Customers where ContactTitle like '%Manager%' order by ContactName;

/* 6. Get all orders placed on the 19th of May, 1997  */
select * from orders where OrderDate = '1997-05-19';