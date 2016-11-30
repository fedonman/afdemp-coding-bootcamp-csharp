# Week 07

Our aim is to develop a website similar to skroutz.gr (or scrooge.co.uk) limited to *technology* products.

Development of the website should start from an empty MVC project and will be separated into phases of advancing difficulty and complexity.

## Skroutz - Phase A
In Phase A, we only have **products**, **categories** and **stores**. Categories can have hierarchy, a product has only one category, and a store can sell many products and a product can be sold in many stores with different price.  
1. Create the model.  
2. Populate the database with seed data (c/p from original website if you like).  
3. Implement a Data Access Layer (DAL) exposing methods for common database actions.  
3. Create controllers and views for viewing/inserting/editing/deleting the model.  

Categories:
* Computers  
  * Hardware
  * Monitors
* Entertainment
  * Televisions & Accessories
  * Projectors & Accessories
* Gaming
  * Consoles
  * Virtual Reality

## Skroutz - Phase B
Every product has attributes. Products of the same category have the same attribute definitions, but different attribute values.
1. Extend the model.  
2. Populate the database (not all attributes are needed, but at least those that scrooge.co.uk uses for filtering).  
3. Update the controllers and views.  

## Skroutz - Phase C
After inserting enough entries to the model, continue with the design of the main website. It should be similar to original website:
1. Home page with full-screen section for search, boxes of categories.  
2. Each category has its own page with boxes of subcategories.  
3. Categories with no children lead to list of products. (No filters for now)  
4. Page of product displaying details, list of stores etc.  
