using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionBasic
{
	static class TextTool
	{
		public static void PrintText (string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine (text);
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void Print (ref ArrayList list)
		{
			if (list.Count <= 0)
			{
				TextTool.PrintText ("List is empty", ConsoleColor.Red);
				return;
			}

			int count = 0;
			foreach (var item in list)
			{
				Console.Write ("Element {0}: ", count);
				Console.WriteLine (item.ToString ());
				count++;
			}
		}

		public static void Print (ref Queue queue)
		{
			if (queue.Count <= 0)
			{
				TextTool.PrintText ("Queue is empty", ConsoleColor.Red);
				return;
			}

			int count = 0;
			foreach (var item in queue)
			{
				Console.Write ("Element {0}: ", count);
				Console.WriteLine (item.ToString ());
				count++;
			}
		}

		public static void Print (ref Stack stack)
		{
			if (stack.Count <= 0)
			{
				TextTool.PrintText ("Queue is empty", ConsoleColor.Red);
				return;
			}

			int count = 0;
			foreach (var item in stack)
			{
				Console.Write ("Element {0}: ", count);
				Console.WriteLine (item.ToString ());
				count++;
			}
		}

		public static void Print<T> (ref List<T> list)
		{
			if (list.Count <= 0)
			{
				TextTool.PrintText ("Queue is empty", ConsoleColor.Red);
				return;
			}

			int count = 0;
			foreach (var item in list)
			{
				Console.Write ("Element {0}: ", count);
				Console.WriteLine (item.ToString ());
				count++;
			}
		}

		public static void Print<T> (ref LinkedList<T> list)
		{
			if (list.Count <= 0)
			{
				TextTool.PrintText ("LinkedList is empty", ConsoleColor.Red);
				return;
			}

			int count = 0;
			foreach (var item in list)
			{
				Console.Write ("Element {0}: ", count);
				Console.WriteLine (item.ToString ());
				count++;
			}
		}

		public static void Print<T> (ref HashSet<T> set)
		{
			if (set.Count <= 0)
			{
				TextTool.PrintText ("LinkedList is empty", ConsoleColor.Red);
				return;
			}

			int count = 0;
			foreach (var item in set)
			{
				Console.Write ("Element {0}: ", count);
				Console.WriteLine (item.ToString ());
				count++;
			}
		}

		public static void Print<TKey, TValue> (ref Dictionary<TKey, TValue> dictionary)
		{
			if (dictionary.Count <= 0)
			{
				TextTool.PrintText ("Dictionary is empty", ConsoleColor.Red);
				return;
			}

			int count = 0;
			foreach (var item in dictionary)
			{
				Console.Write ("Element {0}: ", count);
				Console.WriteLine ("[Key: {0}; Value: {1}]", item.Key, item.Value);
				count++;
			}
		}

		private static int _id = -1;
		public static int SetId ()
		{
			_id++;
			return _id;
		}
	}
}
