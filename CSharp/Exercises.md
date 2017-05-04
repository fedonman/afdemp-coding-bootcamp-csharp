# C\#


## Exercise Complex
Model the complex number as a class in C#. Create constructors for different input parameters. Implement common operations such as addition and subtraction as methods of the class and as overloaded operators. Finally, override ToString() method for informative output.


## Exercise Coffee
a) A cafeteria serves coffee in three variations; Small size is 100 ml, normal is 150 ml and double is 300 ml. Implement the class Coffee. Use Enumerations for the different sizes. Create a sample coffee and print its characteristic. For example, `Normal coffee is 150 ml.`
b) Create a class Order which implements a method CalculateCost which takes as input an array of coffee order items and returns the total price of the order. The price of the coffee is  based on its size. Small costs 0.50 euro, normal 1.5 and double 2.50


## Exercise Utilities
Create a static class "Utilities" and implement a method which takes two integers parameters and swaps them. Use ref. Create a second method which swaps generic types.


## Exercise University
Implement a University class containing university's info an a list of its Students. Students have name and mark. Sort the list by students' mark in ascending order. Use the interface `System.IComparer<T>`


## Exercise Zoo
Implement the following classes: Cat, Lion, Monkey. All of them are animals (Animal). Animals are characterized by age, name and gender. Some species have also species-specific properties (ie. monkey breed or WasCapturedFromWild). Each species makes a diffrent sound (use a virtual method in the Animal class).

Implement the Zoo class containing info about the zoo and a list of different animals. Create a function of Zoo that returns a formatted string of all the animals' name, age and the corresponding sound each one makes. Create a function that sorts the list by Animals' age (use IComperable on Animal).


## Exercise *Library*
You have the following relations between entities:
+ There is a Library that has a collection of Books and a list of authorized Users.
+ Each Book has an Author, title and a unique id (isbn in real life).
+ The Library is operated by a Librarian
+ The User can make request regarding Authors and Book availability only by asking the Librarian. No direct contact to the other entities should be attempted!
1. Create all the necessary classes as much independent from each other as possible (loose coupling).
2. The rest of the logic should be in class Program. In main() we want to call a static function `Program.AsksForBook(user, librarian, book)` which prints whether the user can access the book if the book exists in the library.


## Exercise *Subsequence*
Write a  method that finds the longest subsequence of equal numbers in a given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly. Implement the method
1. as a static method of a static class Utilities
2. as an extension method of the List<int>


## Exercise *Fraction*
1. Define a class Fraction, which contains information about the rational fraction (e.g. 1/4).  
2. Define the appropriate fields, properties and constructors.  
3. Override ToString() to print the Fraction (e.g. "1/4").  
4. Override operator * to multiply two Fractions.  
5. Define a static method Parse(string str) to create a Fraction from a string.
6. Define a property of type *decimal* to return the decimal value of the fraction (e.g. 0.25).  
7. Implement IComparable interface to enable sorting of Fractions.  
8. Write a function Cancel() to cancel the Fraction. (e.g. 10/15 is cancelled to 2/3).  


## Exercise *Mobile*
1. We want to model the functionality of a mobile device. In the namespace *Mobile* implement a class which holds information about a mobile device: model, manufacturer, base price, features of battery (battery type and capacity) and features of the screen (resolution and pixel density). Implement each class and the data structures associated with it in a separate file. After instantiation, the information cannot change.
3. For each class, add some static methods which return an instance of known models.
4. Add a class Usage which holds information about the usage of the mobile device. This includes current percentage of battery,  OS information and call history. Each call record saves information about the date, time of start and time of end of the call and if it was incoming or outgoing. Provide useful properties like duration of the call.
5. Add methods to add/remove calls and also remove all.
