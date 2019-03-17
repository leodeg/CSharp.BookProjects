using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceAndValueTypes
{
	class Program
	{
		static void Main (string[] args)
		{
			ValueHolderTest ();
		}

		static void ValueHolderTest ()
		{
			ValueHolder valueHolder = new ValueHolder ();

			PrintText ("[Example 1] Initialization", ConsoleColor.Yellow);
			valueHolder.value = 10;
			Console.WriteLine ("Value is: {0}", valueHolder.value);

			PrintText ("\n[Example 2] Reference as a value type: default", ConsoleColor.Yellow);
			ChangeValue_RefAsValue (valueHolder);
			Console.WriteLine ("Value is: {0}", valueHolder.value);

			PrintText ("\n[Example 3] Reference as a reference type", ConsoleColor.Yellow);
			ChangeValue_RefAsRef (ref valueHolder);
			Console.WriteLine ("Value is: {0}", valueHolder.value);
		}

		static void ChangeValue_RefAsValue (ValueHolder valueHolder)
		{
			valueHolder.value = 20;
			PrintText ($"Change the value to: {valueHolder.value}", ConsoleColor.Cyan);

			valueHolder = new ValueHolder ();
			PrintText ("Trying create a new ValueHolder", ConsoleColor.Cyan);
		}

		static void ChangeValue_RefAsRef (ref ValueHolder valueHolder)
		{
			valueHolder.value = 30;
			PrintText ($"Change the value to: {valueHolder.value}", ConsoleColor.Cyan);

			valueHolder = new ValueHolder ();
			PrintText ("Trying create a new ValueHolder", ConsoleColor.Cyan);
		}

		static void PrintText (string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine (text);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}

	class ValueHolder
	{
		public int value;
	}
}
