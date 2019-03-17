using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_19
{
	class Program
	{
		static void Main (string[] args)
		{
			IEnumeratorUVAndIRTest ();
		}

		static void EnumeratorExample ()
		{
			int[] arr1 = { 10, 11, 12, 13 };

			IEnumerator ie = arr1.GetEnumerator ();

			while (ie.MoveNext ())
			{
				int item = (int)ie.Current;
				Console.WriteLine ($"Item value: { item }");
			}
		}

		static void SpectrumTest ()
		{
			Spectrum spectrum = new Spectrum ();
			foreach (string color in spectrum)
			{
				Console.WriteLine (color);
			}
		}

		static void IEnumeratorClassTest ()
		{
			IEnumeratorClass enumerator = new IEnumeratorClass ();
			foreach (string shade in enumerator)
			{
				Console.WriteLine (shade);
			}

			foreach (string shade in enumerator.BlackAndWhite ())
			{
				Console.WriteLine (shade);
			}
		}


		static void IEnumeratorUVAndIRTest ()
		{
			var enumerator = new IEnumeratorClass ();
			foreach (string item in enumerator.UvToIr ())
			{
				Console.WriteLine (item);
			}

			Console.WriteLine ();

			foreach (string item in enumerator.IrToUv ())
			{
				Console.WriteLine (item);
			}
		}
	}

	class IEnumeratorClass
	{
		private string[] colors = { "violet", "cyan", "blue", "yellow" };

		public IEnumerator<string> GetEnumerator ()
		{
			IEnumerable<string> enumerable = BlackAndWhite ();
			return enumerable.GetEnumerator();
		}

		public IEnumerable<string> BlackAndWhite ()
		{
			yield return "black";
			yield return "gray";
			yield return "white";
		}

		public IEnumerator<string> ColorsReturn ()
		{
			for (int i = 0; i < colors.Length; i++)
			{
				yield return colors[i];
			}
		}

		public IEnumerable<string> UvToIr ()
		{
			for (int i = 0; i < colors.Length; i++)
			{
				yield return colors[i];
			}
		}

		public IEnumerable<string> IrToUv ()
		{
			for (int i = colors.Length - 1; i >= 0; i--)
			{
				yield return colors[i];
			}
		}
	}

	class MyColors : IEnumerable
	{
		string[] Colors = { "Red", "Yellow", "Blue" };

		public IEnumerator GetEnumerator ()
		{
			return new ColorEnumerator (Colors);
		}
	}

	class Spectrum : IEnumerable
	{
		string[] colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };

		public IEnumerator GetEnumerator ()
		{
			return new ColorEnumerator (colors);
		}
	}

	internal class ColorEnumerator : IEnumerator
	{
		private string[] colors;
		private int position = -1;

		public ColorEnumerator (string[] colors)
		{
			this.colors = new string[colors.Length];
			for (int i = 0; i < colors.Length; i++)
			{
				this.colors[i] = colors[i];
			}
		}

		public object Current
		{
			get
			{
				if (position == -1)
				{
					throw new InvalidOperationException ();
				}

				if (position >= colors.Length)
				{
					throw new InvalidOperationException ();
				}

				return colors[position];
			}
		}

		public bool MoveNext ()
		{
			if (position < colors.Length - 1)
			{
				position++;
				return true;
			}
			return false;
		}

		public void Reset ()
		{
			position = -1;
		}
	}
}
