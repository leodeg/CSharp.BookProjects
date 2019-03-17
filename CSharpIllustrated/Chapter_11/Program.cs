using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11
{
	class Program
	{
		static void Main (string[] args)
		{
			TestFlags ();
		}

		static void TestNewStruct()
		{
			NewStruct simple;
			simple.X = 10;
			simple.Y = 20;
			Console.WriteLine ("{0} {1}", simple.X, simple.Y);
		}

		static void TestFlags ()
		{
			FlagClass flagClass = new FlagClass ();
			CardDeckSettins ops = CardDeckSettins.SingleDeck 
				| CardDeckSettins.FancyNumbers 
				| CardDeckSettins.Animation;

			flagClass.SetOptions (ops);
			flagClass.PrintOptions ();
		}
	}

	struct NewStruct
	{
		public int X, Y;
	}

	[Flags]
	enum CardDeckSettins : uint
	{
		SingleDeck = 0x01,
		LargePictures = 0x02,
		FancyNumbers = 0x04,
		Animation = 0x08
	}

	class FlagClass
	{
		bool UseSingleDeck = false,
			UseBigPics = false,
			UseFanceNumbers = false,
			UseAnimation = false,
			UseAnimationAndFancyNumbers = false;

		public void SetOptions (CardDeckSettins ops)
		{
			UseSingleDeck = ops.HasFlag (CardDeckSettins.SingleDeck);
			UseBigPics = ops.HasFlag (CardDeckSettins.LargePictures);
			UseFanceNumbers = ops.HasFlag (CardDeckSettins.FancyNumbers);
			UseAnimation = ops.HasFlag (CardDeckSettins.Animation);

			CardDeckSettins testFlags = CardDeckSettins.Animation | CardDeckSettins.FancyNumbers;

			UseAnimationAndFancyNumbers = ops.HasFlag (testFlags);
		}

		public void PrintOptions ()
		{
			Console.WriteLine ("Option settings:");
			Console.WriteLine ($"Use Single Deck - {UseSingleDeck}");
			Console.WriteLine ($"Use Large Pictures - {UseBigPics}");
			Console.WriteLine ($"Use Fancy Numbers - {UseFanceNumbers}");
			Console.WriteLine ($"Use Animation - {UseAnimation}");
			Console.WriteLine ("Show Animation and Fancy Numbers - {0}", UseAnimationAndFancyNumbers);
		}
	}
}
