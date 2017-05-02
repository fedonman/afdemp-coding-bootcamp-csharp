using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Author> authors = new List<Author>
			{
				new Author("Tom Robbins"),
				new Author("Nikos Kazatzakis")
			};

			List<Book> books = new List<Book>()
			{
				new Book("To aroma tou oneirou", authors[0]),
				new Book("Ta 7 pepla", authors[0]),
				new Book("Kapetan Mixalis", authors[1])
			};

			Library library = new Library();

			library.AddBook(books[0], 10);
			library.AddBook(books[2], 5);

			User user1 = new User("Maria");
			User user2 = new User("Kostas");

			Librarian librarian = new Librarian("Takis", library);

			librarian.AddUser(user1);

			string reply;
			librarian.RentBook(user1, books[0], out reply);
			Console.WriteLine(reply);
			librarian.RentBook(user1, books[2], out reply);
			Console.WriteLine(reply);
			librarian.RentBook(user1, books[1], out reply);
			Console.WriteLine(reply);
			librarian.RentBook(user2, books[0], out reply);
			Console.WriteLine(reply);

			Console.WriteLine(library);

			Console.ReadKey();
		}
	}
}
