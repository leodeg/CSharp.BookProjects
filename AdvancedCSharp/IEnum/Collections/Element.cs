using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnum
{
	class Element
	{
		public int ElementA { get; set; }
		public int ElementB { get; set; }

		public Element (int elementA, int elementB)
		{
			ElementA = elementA;
			ElementB = elementB;
		}
	}
}
