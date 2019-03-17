using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnum
{

	public class GenericCollectionWithoutIEnums<T>
	{
		private T[] elements;
		private int _length;
		private int position = -1;

		public GenericCollectionWithoutIEnums (int length)
		{
			elements = new T[length];
			_length = length;
		}

		public T this[int index]
		{
			get { return elements[index]; }
			set { elements[index] = value; }
		}

		public int Length
		{
			get { return _length; }
		}

		public void Print ()
		{
			for (int i = 0; i < _length; i++)
			{
				Console.Write (elements[i] + " ");
			}
			Console.WriteLine ();
		}

		public void PrintMoveNext ()
		{
			foreach (var element in elements)
			{
				Console.Write (element + " ");
			}
			Console.WriteLine ();
		}

		private IEnumerator GetEnumerator ()
		{
			// ------ 1 ------
			//while (true)
			//{
			//	if (position < elements.Length - 1)
			//	{
			//		position++;
			//		yield return elements[position];
			//	}
			//	else
			//	{
			//		Reset ();
			//		yield break;
			//	}
			//}

			// ------ 2 ------
			//foreach (var element in elements)
			//{
			//	yield return elements[position];
			//}

			// ------ 3 ------
			return elements.GetEnumerator ();
		}

		private void Reset ()
		{
			position = -1;
		}
	}
}
