using System;

namespace Сhapter_17
{
	delegate void GenericDelegate<T> (T value);
	delegate TR Sum<T1, T2, TR> (T1 value1, T2 value2);

	// <- Ковариация ->
	// Можем использовать наследуемый тип для возвращения базового
	// Используется только для возвращения значения
	delegate T Factory<out T> ();

	// <- Контравариация ->
	// Можем использовать базовый тип, чтобы после передавать в параметре наследуемые типы
	// Используется только для передачи в параметр
	delegate void Action<in T> (T param);
	delegate TResult Func<in T, out TResult> ();

	class Program
	{
		static void Main (string[] args)
		{
			ReturnZooTest ();
		}

		static void PersonTest ()
		{
			Person bill = new Person ("bill", 25);

			int age = bill;
			Console.WriteLine ($"Person info: {bill.name}, {age}");

			Person anon = 49;
			Console.WriteLine ($"Person info: {anon.name}, {anon.age}");
		}

		static void StackTest ()
		{
			Stack<int> intStack = new Stack<int> ();
			Stack<string> stringStack = new Stack<string> ();

			intStack.Push (3);
			intStack.Push (5);
			intStack.Push (7);
			intStack.Push (9);
			intStack.Push (1);
			intStack.Push (2);
			intStack.Push (3);
			intStack.Push (4);
			intStack.Push (5);
			intStack.Push (6);
			intStack.Print ();

			stringStack.Push ("This is fun");
			stringStack.Push ("Hi there!");
			stringStack.Print ();
		}

		static void GenericDelegateTest ()
		{
			// Create instance of the delegate
			GenericDelegate<string> genericDelegate = SimpleDelegateExample.PrintString;

			// first invoke
			Console.WriteLine ("\tFirst");
			genericDelegate ("First");

			// Add a new method
			Console.WriteLine ("\tSecond");

			genericDelegate += SimpleDelegateExample.PrintUpperString;
			genericDelegate ("Second");

			// Subtract an one method
			Console.WriteLine ("\tThird");

			genericDelegate -= SimpleDelegateExample.PrintString;
			genericDelegate ("Third");

			// Subtract the last method from the delegate
			// We have the error because the delegate have no value
			Console.WriteLine ("\tFourth");
			Console.WriteLine ("ERROR!");
			genericDelegate -= SimpleDelegateExample.PrintUpperString;
			//genericDelegate ("Hi there"); // ERROR!

			// Add a new method
			Console.WriteLine ("\tFifth");

			genericDelegate += SimpleDelegateExample.PrintString;
			genericDelegate ("Fifth");

			// Add a little bit more methods
			Console.WriteLine ("\tSixth");

			genericDelegate += SimpleDelegateExample.PrintUpperString;
			genericDelegate += SimpleDelegateExample.PrintString;
			genericDelegate += SimpleDelegateExample.PrintUpperString;
			genericDelegate += SimpleDelegateExample.PrintString;
			genericDelegate += SimpleDelegateExample.PrintUpperString;
			genericDelegate += SimpleDelegateExample.PrintString;
			genericDelegate ("Yeah. Sixth");

			// Remove all methods from the delegate
			Console.WriteLine ("\tSeventh");

			genericDelegate = null;
			if (genericDelegate == null)
			{
				Console.WriteLine ("Generic Delegate equal to null!");
			}
			else
			{
				Console.WriteLine ("Generic Delegate have some value!!!");
			}

			Console.WriteLine ();

		}

		static void GenericMultipleTest ()
		{
			Sum<int, int, string> sum = MathSum.SumOfTwoValue;

			string totalSum = sum (20, 10);
			Console.WriteLine (totalSum);
		}

		static void GenericInterfaceTest ()
		{
			GenericInterfaceHelper helper = new GenericInterfaceHelper ();
			Console.WriteLine ($"{helper.ReturnIt (5)}");
			Console.WriteLine ($"{helper.ReturnIt ("Hello a new string.")}");
		}

		#region Covariance

		static void CovarianceTest()
		{
			Animal a1 = new Animal ();
			Animal a2 = new Dog ();

			Console.WriteLine ($"Number of dog legs: {a2.legs}");
		}

		static Dog MakeDog()
		{
			return new Dog ();
		}

		static void FactoryDogTest()
		{
			Factory<Dog> dogMaker = MakeDog;
			Factory<Animal> animalMaker = dogMaker;
			Factory<Animal> animalMaker_2 = MakeDog;

			var dog = dogMaker ();
			var animal = animalMaker ();
			var animal_2 = animalMaker_2 ();

			Console.WriteLine ($"{dog.legs} {dog.GetType ().Name}");
			Console.WriteLine ($"{animal.legs} {animal.GetType ().Name}");
			Console.WriteLine ($"{animal_2.legs} {animal_2.GetType ().Name}");
		}

		// Ковариация
		static Cat ZooCat ()
		{
			return new Cat ();
		}

		static void ReturnZooTest()
		{
			Animal animal = ZooCat ();
			Cat cat = ZooCat ();

			Console.WriteLine ($"{animal.legs} {animal.GetType().Name}");
			Console.WriteLine ($"{cat.legs} {cat.GetType().Name}");
		}

		#endregion
	}

	class MathSum
	{
		public static string SumOfTwoValue (int value1, int value2)
		{
			int total = value1 + value2;
			return total.ToString ();
		}
	}

	class SimpleDelegateExample
	{
		public static void PrintString (string s)
		{
			Console.WriteLine (s);
		}

		public static void PrintUpperString (string s)
		{
			Console.WriteLine ($"{s.ToUpper ()}");
		}
	}

	class Person
	{
		public string name;
		public int age;

		public Person (string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		// Convert a Person object to an int
		public static implicit operator int (Person p)
		{
			return p.age;
		}

		// Convert an int to a Person object
		public static implicit operator Person (int i)
		{
			return new Person ("Nemo", i);
		}
	}

	class Stack<T>
	{
		T[] StackArray;
		int StackPointer = 0;
		const int MaxStack = 10;

		public Stack ()
		{
			StackArray = new T[MaxStack];
		}

		bool IsStackFull { get { return StackPointer >= MaxStack; } }
		bool IsStackEmpty { get { return StackPointer <= 0; } }

		public void Push (T x)
		{
			if (!IsStackFull)
			{
				StackArray[StackPointer++] = x;
			}
		}

		public T Pop ()
		{
			return IsStackEmpty ? StackArray[--StackPointer] : StackArray[0];
		}

		public void Print ()
		{
			for (int i = StackPointer - 1; i >= 0; i--)
			{
				Console.WriteLine ($"Value: {StackArray[i]}");
			}
		}
	}

	public interface IGenericInterface<T>
	{
		T ReturnIt (T value);
	}

	public class GenericInterfaceHelper : IGenericInterface<int>, IGenericInterface<string>
	{
		public int ReturnIt (int value)
		{
			return value;
		}

		public string ReturnIt (string value)
		{
			return value;
		}
	}

	#region Covariance

	class Animal
	{
		public int legs = 4;
	}

	class Dog : Animal { }
	class Cat : Animal { }

	#endregion
}
