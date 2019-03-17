using System;

namespace DelegateInPractice
{
	class Program
	{
		static void Main (string[] args)
		{
			Departament_WhenCalled_TestingEvents ();
		}

		static void PageLoad_WhenCalled_ShowMessages ()
		{
			PracticeDelegate practice = new PracticeDelegate ();
			practice.PageLoad (practice, EventArgs.Empty);
		}

		static void MakeCalculation_WhenCalled_ShowMessageWithResult ()
		{
			string operation;
			double x, y;

			Console.Write ("Enter an operation: ");
			operation = Console.ReadLine ();

			PracticeDelegate.OperationValidation (ref operation);

			Console.Write ("Enter a first value: ");
			x = double.Parse (Console.ReadLine ());

			Console.Write ("Enter a second value: ");
			y = double.Parse (Console.ReadLine ());

			try
			{
				PracticeDelegate practice = new PracticeDelegate ();
				practice.MakeCalculation (operation, x, y);
			}
			catch (System.InvalidOperationException ex)
			{
				Console.WriteLine (ex.Message);
			}
		}

		static void Departament_WhenCalled_TestingEvents ()
		{
			Departament.HR hr = new Departament.HR ();
			Departament.EmployeeCare employeeCare = new Departament.EmployeeCare (hr);

			hr.RegisterEmployee ("John", Departament.Gender.Male, 20);
			hr.RegisterEmployee ("Peter", Departament.Gender.Male, 25);
			hr.RegisterEmployee ("Luise", Departament.Gender.Female, 19);
		}
	}
}
