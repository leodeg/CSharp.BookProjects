using System;

namespace DelegateInPractice
{
	class CalculationProgram
	{
		public static double Calculate (Func<double, double, double> func, double x, double y)
		{
			return func (x, y);
		}
	}

	class PracticeDelegate
	{
		// 1. Declare a delegate type
		public delegate void MessageDelegate (string text);

		public void PageLoad (object sender, EventArgs e)
		{
			TextTool.PrintText ("Page is Loaded", ConsoleColor.Green);

			// 2. Create an instance of the delegate
			MessageDelegate messageDelegate;

			// 3. Assign an instance
			messageDelegate = PrintMessage;

			// 4. Add subscribers to the delegate
			messageDelegate += PrintWarning;
			messageDelegate += PrintError;

			// 5. Invoke the delegate
			messageDelegate?.Invoke ("Message");
		}

		#region Calculator

		public void MakeCalculation (char operation, double x, double y)
		{
			double result;
			switch (operation)
			{
				case '+':
					result = CalculationProgram.Calculate ((a, b) => a + b, x, y);
					Console.WriteLine ($"{x} {operation} {y} = {result}");
					break;

				case '-':
					result = CalculationProgram.Calculate ((a, b) => a - b, x, y);
					Console.WriteLine ($"{x} {operation} {y} = {result}");
					break;

				case '*':
					result = CalculationProgram.Calculate ((a, b) => a * b, x, y);
					Console.WriteLine ($"{x} {operation} {y} = {result}");
					break;

				case '/':
					result = CalculationProgram.Calculate ((a, b) => a / b, x, y);
					Console.WriteLine ($"{x} {operation} {y} = {result}");
					break;

				default:
					throw new InvalidOperationException ($"MakeCalculation::Operation {operation} is not exist!");
					break;
			}
		}

		public static void OperationValidation (ref string operation)
		{
			string[] valid = { "+", "-", "/", "*", "mod" };

			for (int i = 0; i < valid.Length; i++)
			{
				if (operation == valid[i])
				{
					return;
				}
			}

			throw new InvalidOperationException ($"Operation {operation} is not exist!");
		}

		public void MakeCalculation (string operation, double x, double y)
		{
			if (operation == "mod")
			{
				double result = CalculationProgram.Calculate ((a, b) => a + b, x, y);
				Console.WriteLine ($"{x} {operation} {y} = {result}");
				return;
			}

			MakeCalculation (operation[0], x, y);
		}

		#endregion

		#region Print Messages

		public void PrintMessage (string text)
		{
			TextTool.PrintText ("Message: ", ConsoleColor.Cyan);
			Console.WriteLine (text);
		}

		public void PrintWarning (string warning)
		{
			TextTool.PrintText ("Warning: ", ConsoleColor.Yellow);
			Console.WriteLine (warning);
		}

		public void PrintError (string error)
		{
			TextTool.PrintText ("Error: ", ConsoleColor.Red);
			Console.WriteLine (error);
		}

		#endregion

	}
}
