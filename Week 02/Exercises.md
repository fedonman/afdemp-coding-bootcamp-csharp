
# C\# - Week 2


## Exercise *Library*
You have the following relations between entities:
+ There is a Library that has a collection of Books
+ Each Book has an Author
+ The Library is operated by a Librarian
+ The user can make request regarding authors and book availability only by asking the Librarian. No direct contact to the other entities should be attempted!
+ For all of the following classes create the getter and setter methods for interacting with their fields


## Exercise *Subsequence*
Write a  method that finds the longest subsequence of equal numbers in a given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly. Implement the method
1. as a static method of a static class Utilities
2. as an extension method of the List<int>


## Exercise *Fraction*
Define a class Fraction, which contains information about the rational fraction (e.g. 1/4). 
1. Define the appropriate fields, properties and constructors.
2. Override ToString() to print the Fraction (e.g. "1/4").
3. Define a static method Parse(string str) to create a Fraction from a string.
4. Define a property of type *decimal* to return the decimal value of the fraction (e.g. 0.25).
5. Implement IComparable interface to enable sorting of Fractions.
5. Write a function Cancel() to cancel the Fraction. (e.g. 10/15 is cancelled to 2/3).


## Exercise *Mobile*
1. We want to model the functionality of a mobile device. In the namespace *Mobile* implement a class which holds information about a mobile device: model, manufacturer, base price, features of battery (battery type and capacity) and features of the screen (resolution and pixel density). Implement each class and the data structures associated with it in a separate file. After instantiation, the information cannot change.
3. For each class, add some static methods which return an instance of known models.
4. Add a class Usage which holds information about the usage of the mobile device. This includes current percentage of battery,  OS information and call history. Each call record saves information about the date, time of start and time of end of the call and if it was incoming or outgoing. Provide useful properties like duration of the call.
5. Add methods to add/remove calls and also remove all.
