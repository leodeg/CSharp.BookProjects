using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_6
{
	class Program
	{
		static void Main (string[] args)
		{
			Count (10);
		}

		// Out Parameter example

		static void OutParametersExample ()
		{
			OutParametersValueExample outClass = new OutParametersValueExample ();
			int iValue;

			OutParameter (out outClass, out iValue);

			Console.WriteLine ("OutClass value is: {0}", outClass.Value);
			Console.WriteLine ("iValue is: {0}", iValue);
		}

		static void OutParameter(out OutParametersValueExample outClass, out int iValue)
		{
			outClass = new OutParametersValueExample ();
			outClass.Value = 50;
			iValue = 15;
		}

		// Ref Parameter example

		static void RefParametersExample ()
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine ("Reference value as a parameter");
			Console.ForegroundColor = ConsoleColor.DarkGreen;

			NewValue newValue = new NewValue ();
			Console.WriteLine ($"Before method call: { newValue.Value }");
			RefAsParameter (newValue);
			Console.WriteLine ($"After method call: { newValue.Value }");

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine ("Reference value as a reference parameter");
			Console.ForegroundColor = ConsoleColor.DarkGreen;

			NewValue newValue2 = new NewValue ();
			Console.WriteLine ($"Before method call: { newValue2.Value }");
			RefAsRefParameter (ref newValue2);
			Console.WriteLine ($"After method call: { newValue2.Value }");
		}

		static void RefAsParameter (NewValue newValue)
		{
			newValue.Value = 50;
			Console.WriteLine ($"After member assignment: { newValue.Value }");
			newValue = new NewValue ();
			Console.WriteLine ($"After new object creation: { newValue.Value }");
		}

		static void RefAsRefParameter(ref NewValue newValue)
		{
			newValue.Value = 50;
			Console.WriteLine ($"After member assignment: { newValue.Value }");
			newValue = new NewValue ();
			Console.WriteLine ($"After new object creation: { newValue.Value }");
		}

		// Stack Call example

		static void StartStackCall ()
		{
			Console.WriteLine ("Enter StartStackCall");
			MethodA (15, 30);
			Console.WriteLine ("Exit StartStackCall");

		}

		static void MethodA(int p1, int p2)
		{
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine ("Enter MethodA: {0} {1}", p1, p2);
			MethodB (p1*2, p2*3);
			Console.WriteLine ("Exit MethodA!!!");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
		}

		static void MethodB (int p1, int p2)
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Enter MethodB: {0} {1}", p1, p2);
			//MethodA (p1 * 3, p2 * 4);
			Console.WriteLine ("Exit MethodB!!!");
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
		}

		// Recursion example

		static int FindFactorial(int number)
		{
			if (number <= 1)
				return number;
			else
				return number * FindFactorial (number - 1);
		}

		static void Count(int value)
		{
			if (value == 0) return;
			Count (value - 1);
			Console.WriteLine ($"{value}");
		}
	}

	class NewValue
	{
		public int Value = 10;
	}

	class OutParametersValueExample
	{
		public int Value = 15;
	}


	
}
