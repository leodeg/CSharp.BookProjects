using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnum
{
	public class CollectionIColl : ICollection
	{
		readonly object syncRoot = new object ();

		readonly object[] elements = { 1, 2, 3, 4 };


		public int Count => elements.Length;

		public object SyncRoot => syncRoot;

		public bool IsSynchronized => true;


		public void CopyTo (Array array, int index)
		{
			var arr = array as object[];

			if (arr == null)
			{
				throw new ArgumentException ("Expecting array to be object[]");
			}

			for (int i = 0; i < array.Length; i++)
			{
				arr[index++] = elements[i];
			}
		}

		public IEnumerator GetEnumerator ()
		{
			return elements.GetEnumerator ();
		}
	}
}
