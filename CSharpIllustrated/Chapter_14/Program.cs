using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14
{
	#region Declaring Delegate
	delegate void MyDel (int value);
	delegate int Del ();
	delegate void RefParameters (ref int x);
	delegate void PrintFunction ();
	#endregion

	class Program
	{
		static void Main (string[] args)
		{
			LambdaDeclaration ();
		}

		#region Basic of the Delegates

		static void BasicOfTheDelegates ()
		{
			// Create an instance of the Program class
			Program program = new Program ();

			// Create delegate variable
			MyDel del;

			// Create a random generator
			Random rand = new Random ();

			// Get a random number in diapason of 99 value
			int randomValue = rand.Next (99);

			// Create a delegate objects that contains either 
			// PrintLow or PrintHigh, and assign the object to the 'del' variable
			del = randomValue < 50
				? new MyDel (program.PrintLow)
				: new MyDel (program.PrintHigh);

			// Execute the delegate
			del (randomValue);
		}

		static void CombiningDelegate ()
		{
			// Create an instance of the Program class
			Program program = new Program ();

			// Create delegate variable
			MyDel together, del_1, del_2;

			// Assign methods to the variable
			del_1 = new MyDel (program.PrintHigh);
			del_2 = new MyDel (program.PrintLow);

			// Combining the delegates
			together = del_1 + del_2;

			together?.Invoke (56);
		}

		static void AddingAndRemovingDelegate ()
		{
			// Create an instance of the Program class
			Program program = new Program ();

			// Create delegate variable
			MyDel common = new MyDel (program.PrintLow); // Initialization;
			common += program.PrintHigh; // Adding a new method to the Invocation List;
			common -= program.PrintHigh; // Remove the method from the Invocation List;
		}

		static void ReturnValue()
		{
			ReturnValueClass returnValue = new ReturnValueClass(); // Value = 5

			Del del = returnValue.Add_2;	// Value + 2
			del += returnValue.Add_5;		// Value + 5
			del += returnValue.Add_2;		// Value + 2

			Console.WriteLine ("Value: {0}", del()); // 14 = 5+9
			Console.WriteLine ("Value: {0}", del()); // 23 = 14+9
			Console.WriteLine ("Value: {0}", del()); // 32 = 23+9
			Console.WriteLine ("Value: {0}", del()); // 41 = 32+9
		}

		static void RefParameters()
		{
			ReferenceParameters reference = new ReferenceParameters ();

			RefParameters refParameters = reference.Add_1;
			refParameters = reference.Add_3;
			refParameters = reference.Add_1;

			int x = 5;
			refParameters (ref x); // 6
			refParameters (ref x); // 7
			refParameters (ref x); // 8
			int y = 5;
			refParameters (ref y); // 6
			int z = 5;
			refParameters (ref z); // 6

			Console.WriteLine ("Value: {0}", x); // 8
			Console.WriteLine ("Value: {0}", y); // 6
			Console.WriteLine ("Value: {0}", z); // 6
		}

		// <-- Help Methods -->

		void PrintLow (int value)
		{
			Console.WriteLine ($"{value} - Low Value");
		}

		void PrintHigh (int value)
		{
			Console.WriteLine ($"{value} - High Value");
		}

		#endregion
		#region Anonymous Method

		delegate int IntDelegate (int value);
		static void DeclareAnonMethod()
		{
			IntDelegate del = delegate (int x)
			{
				return x + 20;
			};

			Console.WriteLine (del(6));
			Console.WriteLine (del(15));
		}

		delegate void LifeDel ();
		static void LifeTime()
		{
			LifeDel del;
			{
				int x = 5;
				del = delegate
				{
					Console.WriteLine ("Value of x: {0}", x);
				};
			}
			//Console.WriteLine ("Value of x is: {0}", x); // Error

			del?.Invoke ();
		}

		#endregion
		#region Lambda Expressions

		delegate int IntReturn (int value);

		static void LambdaDeclaration()
		{
			// Anonymous method
			IntReturn del = delegate (int x) { return x + 1; };

			// Lambda expressions
			IntReturn le1 = (int x) => { return x + 1; };
			IntReturn le2 = (x) => { return x + 1; };
			IntReturn le3 = x => { return x + 1; };
			IntReturn le4 = x => x + 1;

			Console.WriteLine ("Anonymous method");
			Console.WriteLine (del(1));
			Console.WriteLine ("Lambda expressions");
			Console.WriteLine (le1(1));
			Console.WriteLine (le2(1));
			Console.WriteLine (le3(1));
			Console.WriteLine (le4(1));
		}

		#endregion
		#region Put all together Delegates
		public static void Test()
		{
			// Create a test class instance
			TestDelegate t = new TestDelegate ();

			// Create a null delegate
			PrintFunction printFunction;

			// Initialize the delegate
			printFunction = t.Print_1;

			// Add more methods to the delegate
			printFunction += TestDelegate.Print_2;
			printFunction += t.Print_1;
			printFunction += TestDelegate.Print_2;

			// Check if is the delegate a null?
			if (printFunction != null)
				// Invoke the delegate
				printFunction();
			else
				// Write the warning message
				Console.WriteLine ("Delegate is empty");
		}
		#endregion
	}

	#region Delegate Helper Classes
	public class TestDelegate
	{
		public void Print_1()
		{
			Console.WriteLine ("Print_1 -- instance");
		}

		public static void Print_2 ()
		{
			Console.WriteLine ("Print_2 -- static");
		}
	}

	class ReturnValueClass
	{
		int Value = 5;
		public int Add_2() { Value += 2; return Value; }
		public int Add_5() { Value += 5; return Value; }
	}

	class ReferenceParameters
	{
		public void Add_1 (ref int x) { x += 1; }
		public void Add_3 (ref int x) { x += 3; }
	}
	#endregion
}
