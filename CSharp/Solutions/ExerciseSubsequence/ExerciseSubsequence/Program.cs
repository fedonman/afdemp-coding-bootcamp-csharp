using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseSubsequence
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> list = new List<int>() { 5, 10, 10, 4, 4, 4, 2, 3, 6, 6, 6, 6 };

			List<int> sequence = Utilities.Subsequence(list);
			sequence.ForEach(x => Console.Write(x + " "));

			List<int> sequence1 = list.Subsequence();
			sequence1.ForEach(x => Console.Write(x + " "));

			List<int> sequence2 = Utilities.SubLINQ(list);
			sequence2.ForEach(x => Console.Write(x + " "));

			Console.WriteLine();
			Console.ReadKey();
		}

	}
}
