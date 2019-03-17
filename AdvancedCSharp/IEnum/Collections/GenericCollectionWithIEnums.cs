using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnum
{
	public class GenericCollectionWithIEnums<T> : IEnumerable<T>, IEnumerator<T>
	{
		private T[] elements;
		private int _length;
		private int position = -1;

		public GenericCollectionWithIEnums (int length)
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

		#region Print

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
			IEnumerator enumerator = ( (IEnumerable)this ).GetEnumerator ();

			while (enumerator.MoveNext ())
			{
				Console.Write (enumerator.Current + " ");
			}
			Console.WriteLine ();
		}

		#endregion

		#region IEnums

		object IEnumerator.Current
		{
			get { return elements[position]; }
		}

		T IEnumerator<T>.Current
		{
			get { return elements[position]; }
		}

		void IDisposable.Dispose ()
		{
			( (IEnumerator)this ).Reset ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return this;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator ()
		{
			return this;
		}

		bool IEnumerator.MoveNext ()
		{
			if (position < _length - 1)
			{
				position++;
				return true;
			}

			( (IEnumerator)this ).Reset ();
			return false;
		}

		void IEnumerator.Reset ()
		{
			position = -1;
		}

		#endregion
	}
}
