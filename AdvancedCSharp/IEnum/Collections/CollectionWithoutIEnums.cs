using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnum
{

	/// <summary>
	/// Collection of Elements
	/// </summary>
	class CollectionWithoutIEnums
	{
		private readonly Element[] elements;

		private int _length;

		public CollectionWithoutIEnums (int length)
		{
			elements = new Element[length];
			_length = length;
		}


		public Element this[int index]
		{
			get { return elements[index]; }
			set { elements[index] = value; }
		}

		public int Length => _length;

		public void Print ()
		{
			foreach (Element element in elements)
			{
				Console.WriteLine ($"[ElementA: {element.ElementA}; ElementB: {element.ElementB}]");
			}
		}

		public void PrintMoveNext ()
		{
			CollectionWithoutIEnums enumerator = GetEnumerator ();

			while (enumerator.MoveNext ())
			{
				Element current = enumerator.Current as Element;
				Console.WriteLine ($"[ElementA: {current.ElementA}; ElementB: {current.ElementB}]");
			}
		}

		public void Add (Element value, int position)
		{
			if (position < _length)
			{
				elements[position] = value;
				return;
			}

			throw new ArgumentOutOfRangeException ();
		}


		private int position = -1;
		object Current => elements[position];

		bool MoveNext ()
		{
			if (position < elements.Length - 1)
			{
				position++;
				return true;
			}

			Reset ();
			return false;
		}

		void Reset ()
		{
			position = -1;
		}

		CollectionWithoutIEnums GetEnumerator ()
		{
			return this;
		}
	}
}
