using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20
{
	class Program
	{
		static void Main (string[] args)
		{
			Linq_CountOddNumber ();
		}

		static void CreateAnonymousType ()
		{
			var student = new { Name = "Mary", Age = 18 };

			Console.WriteLine ("Name: {0}", student.Name);
			Console.WriteLine ("Age: {0}", student.Age);

			Console.WriteLine (student.GetType ().Name);
			Console.WriteLine (student.GetType ().Assembly);
			Console.WriteLine (student.GetType ().BaseType);
		}

		static void Linq_IntegersQuery ()
		{
			int[] numbers = { 2, 5, 18, 29, 42, 64 };

			var numsQuery = from number in numbers
							where number > 20
							select number;

			var numsQueryMethod = numbers.Where (number => number < 20);
			int countNumbers = ( from n in numbers
								 where n > 20
								 select n ).Count ();

			foreach (var number in numsQuery)
			{
				Console.Write (number + ", ");
			}

			Console.WriteLine ();
			foreach (var number in numsQueryMethod)
			{
				Console.Write (number + ", ");
			}

			Console.WriteLine ();
			Console.WriteLine ("Numbers that is more then 20: {0}", countNumbers);
		}

		static void Linq_JoinQuery ()
		{
			Student[] students =
			{
				new Student {ID = 1, Name = "Carson"},
				new Student {ID = 2, Name = "Klassen"},
				new Student {ID = 3, Name = "Fleming"},
				new Student {ID = 4, Name = "Brown"}
			};

			CourseStudent[] courseStudents =
			{
				new CourseStudent {ID = 1, Name = "Philosophy"},
				new CourseStudent {ID = 1, Name = "History"},
				new CourseStudent {ID = 1, Name = "Physics"},

				new CourseStudent {ID = 2, Name = "Philosophy"},

				new CourseStudent {ID = 3, Name = "History"},
				new CourseStudent {ID = 3, Name = "Mathematics"},

				new CourseStudent {ID = 4, Name = "History"},
			};

			var query_History_ReturnStudentName = from s in students
												  join c in courseStudents on s.ID equals c.ID
												  where c.Name == "History"
												  select s.Name;

			foreach (var courseName in query_History_ReturnStudentName)
			{
				Console.WriteLine ("Student taking History: {0}", courseName);
			}
		}

		static void Linq_FromClause ()
		{
			var firstArray = new[] { 3, 4, 5, 6, 7 };
			var secondArray = new[] { 6, 7, 8, 9, 10 };

			var someIntegers = from a in firstArray
							   from b in secondArray
							   where a > 4 && b <= 8
							   select new { a, b, sum = a + b };

			foreach (var integer in someIntegers)
			{
				Console.WriteLine (integer);
			}
		}

		static void Linq_FromClauseWithLet ()
		{
			var firstArray = new[] { 3, 4, 5, 6, 7 };
			var secondArray = new[] { 6, 7, 8, 9, 10 };

			var someIntegers = from a in firstArray
							   from b in secondArray
							   let sum = a + b
							   where sum == 12
							   select new { a, b, sum };

			foreach (var integer in someIntegers)
			{
				Console.WriteLine (integer);
			}
		}

		static void Linq_OrderBy ()
		{
			var students = new[]
			{
				new { FirstName = "Mary", LastName = "Jones", Age = 19 },
				new { FirstName = "Bob", LastName = "Smith", Age = 20 },
				new { FirstName = "Carol", LastName = "Brown", Age = 21 },
				new { FirstName = "Jon", LastName = "Black", Age = 18 }
			};

			var query = from student in students
						orderby student.Age
						select student;

			foreach (var student in query)
			{
				Console.WriteLine ($"{student.LastName} {student.FirstName}, {student.Age}");
			}
		}

		static void Linq_GroupClause ()
		{
			var students = new[]
			{
				new { FirstName = "Mary", LastName = "Jones", Age = 19 },
				new { FirstName = "Bob", LastName = "Smith", Age = 19 },
				new { FirstName = "Carol", LastName = "Brown", Age = 19 },
				new { FirstName = "Jon", LastName = "Black", Age = 18 }
			};

			var query = from student in students
						group student by student.Age;

			foreach (var groups in query)
			{
				Console.WriteLine ($"{ groups.Key }");

				foreach (var student in groups)
				{
					Console.WriteLine ($"\t{ student.FirstName } {student.LastName} {student.Age}");
				}
			}
		}

		static void Linq_IntoQuery ()
		{
			var groupOne = new[] { 1, 7, 5, 4 };
			var groupTwo = new[] { 4, 5, 6, 7 };

			var someIntegers = from a in groupOne
							   join b in groupTwo on a equals b
							   into groupOneAndTwo
							   from c in groupOneAndTwo
							   select c;

			foreach (var v in someIntegers)
			{
				Console.WriteLine (v);
			}
		}

		static void Linq_Method ()
		{
			int[] numbers = { 1, 4, 6 };

			int totalSum = numbers.Sum ();
			int count = numbers.Count ();

			Console.WriteLine ($"total sum: {totalSum}, count: {count}");
		}

		static void Linq_Method2 ()
		{
			int[] intArr = { 3, 4, 5, 6, 7, 9 };

			var count1 = Enumerable.Count (intArr);
			var firstNum1 = Enumerable.First (intArr);

			var count2 = intArr.Count ();
			var firstNum2 = intArr.First ();

			Console.WriteLine ($"Count: {count1}, FirstNumber: {firstNum1}");
			Console.WriteLine ($"Count: {count2}, FirstNumber: {firstNum2}");
		}

		static void Linq_HowManyNumberThatLessThenSeven()
		{
			int[] intArr = { 3, 4, 5, 6, 7, 9 };

			int howMany = ( from n in intArr
							where n < 7
							select n ).Count ();

			Console.WriteLine (howMany);
		}

		static void Linq_CountOddNumber ()
		{
			int[] arr = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
			int oddNumbers = arr.Count (n => n % 2 == 1);
			Console.WriteLine (oddNumbers);
		}

		
	}

	class Student : Info { }

	class CourseStudent : Info { }

	class Info
	{
		public int ID;
		public string Name;
	}
}
