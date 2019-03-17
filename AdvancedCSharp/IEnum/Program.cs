using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnum
{
	class Program
	{
		static void Main (string[] args)
		{
			ChooseTest ();
		}

		static void ChooseTest ()
		{
			Console.WriteLine ("1. UserCollectionWithIEnums");
			Console.WriteLine ("2. UserCollectionWithoutIEnums");
			Console.WriteLine ("3. UserGenericCollectionWithIEnums");
			Console.WriteLine ("4. UserGenericCollectionWithoutIEnums");
			Console.WriteLine ("5. CollectionICollection_Test");
			Console.Write ("Choose test: ");

			switch (int.Parse (Console.ReadLine ()))
			{
				case 1:
					CollectionWithIEnums_Test ();
					break;

				case 2:
					CollectionWithoutIEnums_Test ();
					break;

				case 3:
					GenericCollectionWithIEnums_Test ();
					break;

				case 4:
					GenericCollectionWithoutIEnums_Test ();
					break;

				case 5:
					CollectionICollection_Test ();
					break;

				default:
					throw new InvalidOperationException ();
			}
		}

		static void CollectionWithIEnums_Test ()
		{
			var collection = new CollectionWithIEnums (10);

			for (int i = 0; i < collection.Length; i++)
			{
				collection[i] = new Element (i, i + 1);
			}

			collection.Print ();
			Console.WriteLine ();

			collection.Add (new Element (101, 201), 8);
			collection.PrintMoveNext ();
		}

		static void CollectionWithoutIEnums_Test ()
		{
			var collection = new CollectionWithoutIEnums (10);

			for (int i = 0; i < collection.Length; i++)
			{
				collection[i] = new Element (i, i + 1);
			}

			collection.Print ();
			Console.WriteLine ();

			collection.Add (new Element (101, 201), 8);
			collection.PrintMoveNext ();
		}

		static void GenericCollectionWithIEnums_Test ()
		{
			var collection = new GenericCollectionWithIEnums<int> (10);

			for (int i = 0; i < collection.Length; i++)
			{
				collection[i] = i;
			}

			collection.Print ();
			collection[8] = 100;
			collection.PrintMoveNext ();
		}

		static void GenericCollectionWithoutIEnums_Test ()
		{
			var collection = new GenericCollectionWithoutIEnums<int> (10);

			for (int i = 0; i < collection.Length; i++)
			{
				collection[i] = i;
			}

			collection.Print ();
			collection[8] = 100;
			collection.PrintMoveNext ();
		}

		static void CollectionICollection_Test ()
		{
			var collection = new CollectionIColl ();

			Console.WriteLine ("Collection:");
			foreach (var element in collection)
			{
				Console.WriteLine (element);
			}

			Console.WriteLine ();

			var arr = new object[collection.Count];

			collection.CopyTo (arr, 0);

			Console.WriteLine ("CopyTo:");
			foreach (int element in arr)
			{
				Console.WriteLine (element);
			}
		}
	}
}
