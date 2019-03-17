using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionBasic
{
	class Program
	{
		static void Main (string[] args)
		{
			CollectionsFind ();

			Console.WriteLine ();
		}

		static void ArrayListTest ()
		{
			// Create ArrayList
			ArrayList list = new ArrayList ();

			// Add
			TextTool.PrintText ("Add", ConsoleColor.Yellow);
			list.Add (12);
			list.Add ("String");
			list.Add (12.0f);
			TextTool.Print (ref list);

			// Add Range
			TextTool.PrintText ("\nAddRange", ConsoleColor.Yellow);
			var aditional = new ArrayList { 1, 2, 3, "Hello", "World" };
			list.AddRange (aditional);
			TextTool.Print (ref list);

			// Insert
			TextTool.PrintText ("\nInsert", ConsoleColor.Yellow);
			list.Insert (4, 10);
			list.Insert (6, 5);
			TextTool.Print (ref list);

			// Remove
			TextTool.PrintText ("\nRemove", ConsoleColor.Yellow);
			list.Remove ("Hello");
			TextTool.Print (ref list);

			// RemoveRange
			TextTool.PrintText ("\nRemoveRange", ConsoleColor.Yellow);
			list.RemoveRange (2, 5);
			TextTool.Print (ref list);

			// Indexer
			TextTool.PrintText ("\nUse Indexer", ConsoleColor.Yellow);
			list[0] = "Element 0";
			list[3] = "Element 3";
			TextTool.Print (ref list);

			// Clear
			TextTool.PrintText ("\nClear", ConsoleColor.Yellow);
			list.Clear ();
			TextTool.Print (ref list);
		}

		static void QueueTest ()
		{
			// Create
			var queue = new Queue ();

			// Enqueue
			TextTool.PrintText ("Enqueue", ConsoleColor.Yellow);
			queue.Enqueue ("Hello");
			queue.Enqueue ("World");
			TextTool.Print (ref queue);

			// Dequeue
			TextTool.PrintText ("Dequeue", ConsoleColor.Yellow);
			queue.Dequeue ();
			TextTool.Print (ref queue);

			// Clear
			TextTool.PrintText ("Clear", ConsoleColor.Yellow);
			queue.Clear ();
			TextTool.Print (ref queue);
		}

		static void StackTest ()
		{
			// Create
			var stack = new Stack ();

			// Push
			TextTool.PrintText ("Push", ConsoleColor.Yellow);
			stack.Push (1);
			stack.Push (2);
			stack.Push (3);
			TextTool.Print (ref stack);

			// Pop
			TextTool.PrintText ("Pop", ConsoleColor.Yellow);
			stack.Pop ();
			stack.Pop ();
			TextTool.Print (ref stack);

			// Peek
			TextTool.PrintText ("Peek", ConsoleColor.Yellow);
			stack.Peek ();
			TextTool.Print (ref stack);
		}

		static void ListTest ()
		{
			// Create
			var list = new List<string> ();
			var range = new List<string> { "Range1", "Range2", "Range3" };

			// Add by using for each
			foreach (var element in new string[] { "Hello", "John", "I'm", "Here" })
			{
				list.Add (element);
			}

			// Add
			TextTool.PrintText ("Add", ConsoleColor.Yellow);
			list.Add ("First");
			list.Add ("Second");
			list.Add ("Third");
			list.Add ("Fourth");
			list.Add ("Fifth");
			TextTool.Print (ref list);

			// Insert
			TextTool.PrintText ("Insert", ConsoleColor.Yellow);
			list.Insert (3, "Third");
			TextTool.Print (ref list);

			// Range
			TextTool.PrintText ("Range", ConsoleColor.Yellow);
			list.InsertRange (3, range);
			TextTool.Print (ref list);

			// Remove
			TextTool.PrintText ("Remove", ConsoleColor.Yellow);
			list.Remove ("Range1");
			list.Remove ("Range2");
			list.Remove ("First");
			TextTool.Print (ref list);

			// Indexer
			TextTool.PrintText ("Indexer", ConsoleColor.Yellow);
			list[0] = "New";
			TextTool.Print (ref list);
		}

		static void LinkedListTest ()
		{
			// Create LinkedList
			var list = new LinkedList<string> ();

			// Add first
			TextTool.PrintText ("Add first", ConsoleColor.Yellow);
			list.AddFirst ("First");
			list.AddFirst ("Second");
			list.AddFirst ("Third");
			list.AddFirst ("Fourth");
			list.AddFirst ("Fifth");
			TextTool.Print (ref list);

			list.Clear ();

			// Add last
			TextTool.PrintText ("Add last", ConsoleColor.Yellow);
			list.AddLast ("First");
			list.AddLast ("Second");
			list.AddLast ("Third");
			list.AddLast ("Fourth");
			list.AddLast ("Fifth");
			list.AddLast ("Sixth");
			list.AddLast ("Seventh");
			list.AddLast ("Eighth");
			list.AddLast ("Ninth");
			list.AddLast ("Tenth");
			TextTool.Print (ref list);

			// Remove first
			TextTool.PrintText ("Remove first", ConsoleColor.Yellow);
			list.RemoveFirst ();
			TextTool.Print (ref list);

			// Remove last
			TextTool.PrintText ("Remove last", ConsoleColor.Yellow);
			list.RemoveLast ();
			TextTool.Print (ref list);

			// Remove Sixth
			TextTool.PrintText ("Remove Sixth", ConsoleColor.Yellow);
			list.Remove ("Sixth");
			TextTool.Print (ref list);

			// Clear
			TextTool.PrintText ("Clear", ConsoleColor.Yellow);
			list.Clear ();
			TextTool.Print (ref list);
		}

		static void HashSetTest ()
		{
			var set = new HashSet<string> ();

			// Add
			TextTool.PrintText ("Add", ConsoleColor.Yellow);
			set.Add ("First");
			set.Add ("Second");
			set.Add ("Third");
			set.Add ("Fourth");
			set.Add ("Fifth");
			set.Add ("Sixth");
			set.Add ("Seventh");
			set.Add ("Eighth");
			set.Add ("Ninth");
			set.Add ("Tenth");
			TextTool.Print (ref set);

			// Remove First, Tenth
			TextTool.PrintText ("Remove First, Tenth", ConsoleColor.Yellow);
			if (set.Remove ("First"))
			{
				TextTool.PrintText ("First was deleted", ConsoleColor.Red);
			}

			set.Remove ("Tenth");
			TextTool.Print (ref set);

			// Remove Eleventh
			TextTool.PrintText ("Remove Eleventh", ConsoleColor.Yellow);
			if (!set.Remove ("Eleventh"))
			{
				TextTool.PrintText ("Element Eleventh is not found", ConsoleColor.Red);
			}
			else
			{
				TextTool.Print (ref set);
			}
		}

		static void DictionaryTest ()
		{
			var dictionary = new Dictionary<int, string> ();

			// Add
			TextTool.PrintText ("Add", ConsoleColor.Yellow);
			dictionary.Add (TextTool.SetId (), "Lorens");
			dictionary.Add (TextTool.SetId (), "Winkston");
			dictionary.Add (TextTool.SetId (), "Joshua");
			dictionary.Add (TextTool.SetId (), "Brown");
			TextTool.Print (ref dictionary);
		}

		static void CollectionsFind ()
		{
			var list = new List<string> ();
			for (int i = 0; i < 5; i++)
			{
				list.Add ("Element " + i.ToString ());
			}

			var query = list.Find (x => x.Contains ("1"));
			Console.WriteLine (query);
		}
	}
}
