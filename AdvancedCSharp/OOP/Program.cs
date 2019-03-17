using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
	class Program
	{
		static void Main (string[] args)
		{
			PersonInitTest ();
		}

		private static void PersonInitTest ()
		{
			var person = new Person ();
			person.ID = 5;
			person.PhoneNumber = 1423123;
			person.FirstName = "John";
			person.LastName = "Brown";
			Console.WriteLine (string.Format ("Name: {0} {1}; ID = {2}; PhoneNumber: {3}", person.FirstName, person.LastName, person.ID, person.PhoneNumber));

			var person2 = new Person () { ID = 5, PhoneNumber = 1231421, FirstName = "John", LastName = "Brown" };
			Console.WriteLine (string.Format ("Name: {0} {1}; ID = {2}; PhoneNumber: {3}", person2.FirstName, person2.LastName, person2.ID, person2.PhoneNumber));

			Console.WriteLine (person.FullName);
		}
	}

	class Person
	{
		public int ID { get; set; }
		public int PhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName => $"{FirstName} {LastName}";
	}
}
