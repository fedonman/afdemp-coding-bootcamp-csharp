using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
	class Book
	{
		public static int _ID = 0;

		public string Title { get; private set; }
		public Author Author { get; private set; }
		public int ID { get; private set; }

		public Book(string title, Author author)
		{
			this.Title = title;
			this.Author = author;
			this.ID = ++_ID;
		}

		public override string ToString()
		{
			return $"{this.Title} by {this.Author}";
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Book)) {
				return false;
			}
			return Equals(obj as Book);
		}

		public bool Equals(Book other)
		{
			if (this.ID == other.ID) {
				return true;
			}
			else {
				return false;
			}
		}

		public static bool operator ==(Book book1, Book book2)
		{
			return book1.Equals(book2);
		}

		public static bool operator !=(Book book1, Book book2)
		{
			return !book1.Equals(book2);
		}

		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}
	}
}
