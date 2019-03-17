using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseTypes
{
	internal class Program
	{
		private static void Main (string[] args)
		{
			MoveableObject_Test ();
		}

		private static void MoveableObject_Test ()
		{
			MoveableObject moveable = new MoveableObject ();

			List<ILeft> moveablesToLeft = new List<ILeft> ();
			List<IRight> moveablesToRight = new List<IRight> ();

			moveablesToLeft.Add (moveable);
			moveablesToRight.Add (moveable);

			Console.WriteLine ("Use List:");
			moveablesToLeft[0].Move ();
			moveablesToRight[0].Move ();

			ILeft moveLeft = moveable as ILeft;
			IRight moveRight = moveable as IRight;

			Console.WriteLine ("\nUse Cast:");
			moveLeft.Move ();
			moveRight.Move ();
		}
	}

	internal interface ILeft { void Move (); }

	internal interface IRight { void Move (); }

	internal class MoveableObject : ILeft, IRight
	{
		void ILeft.Move ()
		{
			Console.WriteLine ("Move left");
		}

		void IRight.Move ()
		{
			Console.WriteLine ("Move right");
		}
	}
}
