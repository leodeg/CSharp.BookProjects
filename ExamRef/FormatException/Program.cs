using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
	internal class Program
	{
		private static void Main (string[] args)
		{
			Exception_DispatchInformation ();
		}

		private static void Exception_FormatException ()
		{
			while (true)
			{
				string str = Console.ReadLine ();

				if (String.IsNullOrWhiteSpace (str)) break;

				try
				{
					int parseNumber = int.Parse (str);
				}
				catch (System.ArgumentNullException)
				{
					Console.WriteLine ("You need to enter a value.");
				}
				catch (System.FormatException)
				{
					Console.WriteLine ("{0} is not a valid number. Please try again.", str);
				}
				finally
				{
					Console.WriteLine ("Block complete.");
				}
			}
		}

		private static void Exception_FailFast ()
		{
			string str = Console.ReadLine ();

			try
			{
				int number = int.Parse (str);
				if (number == 42) Environment.FailFast ("Special number entered");
			}
			finally
			{
				Console.WriteLine ("Program complete");
			}
		}

		private static void Exception_ExceptionInformation ()
		{
			try
			{
				string stringNumber = Console.ReadLine ();
				int number = int.Parse (stringNumber);
			}
			catch (FormatException ex)
			{
				Console.WriteLine ("Message: {0}", ex.Message);
				Console.WriteLine ("StackTrace: {0}", ex.StackTrace);
				Console.WriteLine ("HelpLink: {0}", ex.HelpLink);
				Console.WriteLine ("InnerException: {0}", ex.InnerException);
				Console.WriteLine ("TargetSite: {0}", ex.TargetSite);
				Console.WriteLine ("Source: {0}", ex.Source);
			}
			finally
			{
				Console.WriteLine ("Program complete...");
			}
		}

		private static void Exception_DispatchInformation ()
		{
			System.Runtime.ExceptionServices.ExceptionDispatchInfo possibleExc = null;

			try
			{
				string str = Console.ReadLine ();
				int.Parse (str);
			}
			catch (FormatException ex)
			{
				possibleExc = System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture (ex);

			}

			if (possibleExc != null)
			{
				possibleExc.Throw ();
			}
		}
	}

	[Serializable]
	internal class OrderProcessingException : Exception, ISerializable
	{
		public int OrderID { get; set; }

		public OrderProcessingException (int orderID)
		{
			OrderID = orderID;
			HelpLink = "http://www.mydomain.com/infoaboutexception%E2%80%9D";
		}

		public OrderProcessingException (int orderID, string message) : base (message)
		{
			OrderID = orderID;
			HelpLink = "http://www.mydomain.com/infoaboutexception%E2%80%9D";
		}

		public OrderProcessingException (int orderID, string message, Exception innerException) : base (message, innerException)
		{
			OrderID = orderID;
			HelpLink = "http://www.mydomain.com/infoaboutexception%E2%80%9D";
		}

		public OrderProcessingException (SerializationInfo info, StreamingContext context)
		{
			OrderID = (int)info.GetValue ("OrderID", typeof (int));
		}

		public override void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			info.AddValue ("OrderID", OrderID, typeof (int));
		}
	}



	internal class Card { }

	internal class Deck
	{
		private int m_MaximumNumberOfCards;

		public Deck (int maximumNumberOfCards)
		{
			m_MaximumNumberOfCards = maximumNumberOfCards;
			Cards = new List<Card> ();
		}

		public ICollection<Card> Cards { get; private set; }

		public Card this[int index]
		{
			get { return Cards.ElementAt (index); }
		}
	}

	internal struct Nullable<T> where T : struct
	{
		private bool m_HasValue;
		private T m_Value;

		public Nullable (T value)
		{
			m_HasValue = true;
			m_Value = value;
		}

		public bool HasValue { get { return m_HasValue; } }

		public T Value
		{
			get
			{
				if (!m_HasValue) throw new ArgumentException ();
				return m_Value;
			}
		}

		public T GetValueOrDefault ()
		{
			return m_Value;
		}
	}



	internal class Product
	{
		public decimal Price { get; set; }
	}

	internal static class Extensions
	{
		public static decimal Discount (this Product product)
		{
			return product.Price * 0.9M;
		}
	}

	internal class Calculator
	{
		public decimal CalculateDiscount (Product product)
		{
			return product.Discount ();
		}
	}
}
