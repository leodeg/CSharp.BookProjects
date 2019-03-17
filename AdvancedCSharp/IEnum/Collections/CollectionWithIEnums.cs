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
	class CollectionWithIEnums : IEnumerable, IEnumerator
	{
		/// <summary>
		/// Collection of the elements
		/// </summary>
		private readonly Element[] elements;

		/// <summary>
		/// Length of the collection
		/// </summary>
		private int _length;

		public CollectionWithIEnums (int length)
		{
			elements = new Element[length];
			_length = length;
		}

		/// <summary>
		/// Collections indexers
		/// </summary>
		public Element this[int index]
		{
			get { return elements[index]; }
			set { elements[index] = value; }
		}

		/// <summary>
		/// Return length of the collection
		/// </summary>
		public int Length => _length;

		/// <summary>
		/// Print the collection elements to Console by using foreach loop
		/// </summary>
		public void Print ()
		{
			foreach (Element element in elements)
			{
				Console.WriteLine ($"[ElementA: {element.ElementA}; ElementB: {element.ElementB}]");
			}
		}

		/// <summary>
		/// Print collection elements to Console by using IEnumerator.MoveNext() and while loop
		/// </summary>
		public void PrintMoveNext ()
		{
			IEnumerator enumerator = ( (IEnumerable)this ).GetEnumerator ();

			while (enumerator.MoveNext ())
			{
				Element current = enumerator.Current as Element;
				Console.WriteLine ($"[ElementA: {current.ElementA}; ElementB: {current.ElementB}]");
			}
		}

		/// <summary>
		/// Add a new Element at the position
		/// </summary>
		public void Add (Element value, int position)
		{
			if (position < _length)
			{
				elements[position] = value;
				return;
			}

			throw new ArgumentOutOfRangeException ();
		}

		#region IEnumerable implementation

		/// <summary>
		/// The current position marker
		/// </summary>
		private int position = -1;

		/// <summary>
		/// Return current position
		/// </summary>
		object IEnumerator.Current => elements[position];

		/// <summary>
		/// Move to a next value in the array/collections
		/// </summary>
		bool IEnumerator.MoveNext ()
		{
			if (position < elements.Length - 1)
			{
				position++;
				return true;
			}

			( (IEnumerator)this ).Reset (); // When we went to end of the collections need to reset the marker position
			return false;
		}

		/// <summary>
		/// Reset position to the beginning 
		/// </summary>
		void IEnumerator.Reset ()
		{
			position = -1;
		}

		/// <summary>
		/// Return enumerator of the collection
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return this;
		}

		#endregion
	}
}
