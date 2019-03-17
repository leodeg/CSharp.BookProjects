using System;

namespace DelegateInPractice
{
	static class Departament
	{
		public enum Gender { Male, Female, None };

		public class NewEmployeeEventArgs : EventArgs
		{
			public string Name { get; }
			public Gender Sex { get; }
			public int Age { get; }

			public NewEmployeeEventArgs (string name, Gender gender, int age)
			{
				Name = name;
				Sex = gender;
				Age = age;
			}
		}

		public class HR
		{
			public event EventHandler NewEmployee;

			protected virtual void OnNewEmployee (EventArgs e)
			{
				NewEmployee?.Invoke (this, e);
			}

			public void RegisterEmployee (string name, Gender gender, int age)
			{
				NewEmployeeEventArgs e = new NewEmployeeEventArgs (name, gender, age);
				OnNewEmployee (e);
			}
		}

		public class EmployeeCare
		{
			public EmployeeCare (HR hr)
			{
				hr.NewEmployee += CallEmployee;
			}

			private void CallEmployee (object sender, EventArgs e)
			{
				NewEmployeeEventArgs args = e as NewEmployeeEventArgs;
				Console.WriteLine ("Sender of event: {0}", sender.ToString());
				Console.WriteLine ("Customer Info: [Name: {0}; Gender: {1}; Age: {2}]", args.Name, args.Sex, args.Age);
			}
		}
	}
}
