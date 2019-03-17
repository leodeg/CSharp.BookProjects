using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7
{
	class Program
	{
		static void Main (string[] args)
		{
			IndexerCollection<string> collection = new IndexerCollection<string> (100);
			Console.WriteLine (collection.Length);
		}
	}

	class IndexerCollection<T>
	{
		// <-- Indexers declaration -->
		// "AccessType" "ReturnType" this ["ReturnType" index] { get and set accessors }

		// Declare an array to store the data elements.
		private T[] arr;

		public IndexerCollection (int collectionSize)
		{
			arr = new T[collectionSize];
		}

		// Define the indexer to allow client code to use [] notation.
		public T this [int i]
		{
			get { return arr[i]; }
			set { arr[i] = value; }
		}

		/// <summary>
		/// The collection length
		/// </summary>
		public int Length
		{
			get { return arr.Length; }
		}
	}

	class Employee
	{
		private string FirstName;
		private string LastName;

		public string this [int index]
		{
			set
			{
				switch (index)
				{
					case 0: LastName = value; break;
					case 1: FirstName = value; break;
					default: throw new ArgumentOutOfRangeException ("index");
				}
			}
			get
			{
				switch (index)
				{
					case 0: return FirstName;
					case 1: return LastName;
					default: throw new ArgumentOutOfRangeException ("index");
				}
			}
		}
	}

}
