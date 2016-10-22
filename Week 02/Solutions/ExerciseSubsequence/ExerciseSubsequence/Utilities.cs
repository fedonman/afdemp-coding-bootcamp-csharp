using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseSubsequence
{
	static class Utilities
	{
		//Maximum Subsequence of Generic type as extention method
		public static List<int> Subsequence(List<int> list)
		{
			int startIndex = 0;
			int count = 1;
			int maxCount = 0;
			int maxStartIndex = 0;
			for (int i = 1; i < list.Count; i++) {
				if (list[i - 1] == list[i]) {
					count++;
					if (i == list.Count - 1 && count > maxCount) {
						maxStartIndex = startIndex;
						maxCount = count;
					}
				}
				else {
					if (count > maxCount) {
						maxCount = count;
						maxStartIndex = startIndex;
					}
					startIndex = i;
					count = 1;
				}
			}
			return list.GetRange(maxStartIndex, maxCount);
		}

		//Maximum Subsequence of Generic type as extention method
		public static List<T> Subsequence<T>(this List<T> list)
		{
			int startIndex = 0;
			int count = 0;
			int maxCount = 0;
			int maxStartIndex = 0;
			for (int i = 1; i < list.Count; i++) {
				if (list[i - 1].Equals(list[i])) {
					count++;
					if (i == list.Count - 1 && count > maxCount) {
						maxStartIndex = startIndex;
						maxCount = count;
					}
				}
				else {
					if (count > maxCount) {
						maxCount = count;
						maxStartIndex = startIndex;
					}
					startIndex = i;
					count = 1;
				}
			}
			return list.GetRange(maxStartIndex, maxCount);
		}

		//Maximum Subsequence using LINQ
		public static List<int> SubLINQ(List<int> list)
		{
			return list.Select((n, i) => new { Value = n, Index = i })
				.OrderBy(s => s.Value)
				.Select((o, i) => new { Value = o.Value, Diff = i - o.Index })
				.GroupBy(s => new { s.Value, s.Diff })
				.OrderByDescending(g => g.Count())
				.First()
				.Select(f => f.Value).ToList<int>();
		}
	}
}
