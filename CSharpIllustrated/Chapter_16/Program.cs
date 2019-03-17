using System;

namespace Chapter_16
{
	class Program
	{
		static void Main (string[] args)
		{
			IComparableTest ();
		}

		static void IComparableTest()
		{
			// Create arrays
			var arrayOfIntegers = new[] { 20, 24, 25, 72, 1, -1};
			ComparableTest[] comparables = new ComparableTest[arrayOfIntegers.Length];

			// Set the value from the first array to the second
			for (int i = 0; i < arrayOfIntegers.Length; i++)
			{
				comparables[i] = new ComparableTest();
				comparables[i].value = arrayOfIntegers[i];
			}

			// Print initial ordered array
			foreach (var item in arrayOfIntegers)
			{
				Console.WriteLine (item);
			}

			// Sort the array
			Array.Sort (comparables);

			Console.WriteLine ();
			// Print the sorted array
			foreach (var item in comparables)
			{
				Console.WriteLine (item.value);
			}
		}
	}

	class ComparableTest : IComparable
	{
		public int value;

		int IComparable.CompareTo (object obj)
		{
			// Get instance and implicit the obj to the ComparableTest class
			ComparableTest comparableTest = (ComparableTest)obj;

			if (this.value < comparableTest.value) return -1; // If value is less
			if (this.value > comparableTest.value) return 1; // If value is more
			return 0; // If values is equals
		}
	}
}