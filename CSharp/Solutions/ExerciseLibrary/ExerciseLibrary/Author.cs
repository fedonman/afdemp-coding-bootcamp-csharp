using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
	class Author
	{
		public string Name { get; private set; }

		public Author(string name)
		{
			this.Name = name;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
