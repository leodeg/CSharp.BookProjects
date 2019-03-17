using System;
using System.Collections.Generic;

namespace FlowControl
{
	class Program
	{
		static void Main (string[] args)
		{
			Foreach_OldSchool ();
		}

		private static void Foreach_OldSchool ()
		{
			var people = new List<Person>
			{
				new Person() {FirstName = "Din", LastName = "Winchester"},
				new Person() {FirstName = "Sam", LastName = "Winchester"}
			};

			List<Person>.Enumerator enumerator = people.GetEnumerator ();

			try
			{
				Person temp;
				while (enumerator.MoveNext ())
				{
					temp = enumerator.Current;
					Console.WriteLine ($"[First Name: {temp.FirstName}, Last Name: {temp.LastName}]");
				}
			}
			finally
			{
				System.IDisposable disposable = enumerator as System.IDisposable;
				if (disposable != null) disposable.Dispose ();
			}
		}
	}

	class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
