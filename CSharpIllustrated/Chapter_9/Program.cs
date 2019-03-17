using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_9
{
	class Program
	{
		static void Main (string[] args)
		{
			TestIncrementOperator ();
		}

		#region Test

		public static void TestLimitValue ()
		{
			LimitInt limit = (LimitInt)500;
			int value = limit;
			Console.WriteLine ($"limited value: {limit.Value}, int value = {value}");
			Console.WriteLine ($"limited value: {limit.Value}, int value = {value}");
		}

		public static void TestIncrementOperator()
		{
			StructType structType = new StructType (10);

			DisplayDarkYellow ("Pre-increment StructType");
			DisplayResult ("before:", structType);
			DisplayResult ("after:", ++structType);
			DisplayResult ("after:", structType);

			DisplayDarkYellow ("Post-increment StructType");
			DisplayResult ("before:", structType);
			DisplayResult ("after:", structType++);
			DisplayResult ("after:", structType);

			Console.WriteLine ();
			ClassType classType = new ClassType (15);

			DisplayDarkYellow ("Pre-increment ClassType");
			DisplayResult ("before:", classType);
			DisplayResult ("after:", ++classType);
			DisplayResult ("after:", classType);

			DisplayDarkYellow ("Post-increment ClassType");
			DisplayResult ("before:", classType);
			DisplayResult ("after:", classType++);
			DisplayResult ("after:", classType);
		}

		#endregion
		#region Helper

		public static void DisplayDarkYellow(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine (text);
			Console.ForegroundColor = ConsoleColor.DarkGreen;
		}

		public static void DisplayResult(string message, StructType structType)
		{
			Console.WriteLine ($"{message} {structType.X}");
		}

		public static void DisplayResult (string message, ClassType classType)
		{
			Console.WriteLine ($"{message} {classType.X}");
		}

		#endregion
	}

	class LimitInt
	{
		const int MaxValue = 100;
		const int MinValue = 0;

		#region Conversion Operators

		public static implicit operator int (LimitInt limit)
		{
			return limit.Value;
		}

		public static explicit operator LimitInt (int value)
		{
			LimitInt limit = new LimitInt ();
			limit.Value = value;
			return limit;
		}

		#endregion
		#region Operators Overloading

		public static LimitInt operator - (LimitInt x)
		{
			if (x == null)
			{
				throw new ArgumentNullException (nameof (x));
			}

			LimitInt limit = new LimitInt ();
			limit.Value = 0;
			return limit;
		}

		public static LimitInt operator - (LimitInt x, LimitInt y)
		{
			LimitInt limit = new LimitInt ();
			limit.Value = x.Value - y.Value;
			return limit;
		}

		public static LimitInt operator + (LimitInt x, LimitInt y)
		{
			LimitInt limit = new LimitInt ();
			limit.Value = x.Value + y.Value;
			return limit;
		}

		public static LimitInt operator + (LimitInt x, int y)
		{
			LimitInt limit = new LimitInt ();
			limit.Value = x.Value +  y;
			return limit;
		}

		#endregion
		#region Properties

		private int m_value;

		public int Value
		{
			get { return m_value; }
			set
			{
				if (value < MinValue)
				{
					m_value = MinValue;
				}
				else
				{
					m_value = value > MaxValue ? MaxValue : value;
				}
			}
		}

		#endregion
	}

	public struct StructType
	{
		public int X;

		public StructType (int x)
		{
			X = x;
		}

		public static StructType operator ++ (StructType value)
		{
			value.X++;
			return value;
		}
	}

	public class ClassType
	{
		public int X;

		public ClassType (int x)
		{
			X = x;
		}

		public static ClassType operator ++ (ClassType value)
		{
			value.X++;
			return value;
		}
	}
}
