using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_15
{

	class Program
	{
		static void Main (string[] args)
		{
			TestVideoEncoder ();
		}

		static void TestIncrementer ()
		{
			Incrementer incrementer = new Incrementer (); // Instance of the Incrementer class
			Dozens dozensCounter = new Dozens (incrementer); // Instance of the Dozens class

			incrementer.DoCount (); // Invoke the events
			Console.WriteLine ("Number of dozens = {0}", dozensCounter.DozensCount);
		}

		static void TestIncrementerEventHandler ()
		{
			IncrementerEventHandler incrementer = new IncrementerEventHandler ();
			DozensEventHandler dozensCounter = new DozensEventHandler (incrementer);

			incrementer.DoCount ();
			Console.WriteLine ("Number of dozens = {0}", dozensCounter.DozensCount);
		}

		#region Account Test

		static void TestAccount ()
		{
			// Create instance of the class
			Account account = new Account (200);
			// Set the subscriber of the event
			account.OnAdded += ShowMessge;
			account.OnWithdrawn += ShowMessge;

			account.Withdraw (100);
			// Delete the subscriber of the event
			account.OnWithdrawn -= ShowMessge;

			account.Withdraw (50);
			account.Put (150);
		}

		static void ShowMessge (object sender, AccountEvetArgs e)
		{
			Console.WriteLine ($"Сумма транзакции: {e.Sum}");
			Console.WriteLine (e.Message);
		}

		#endregion

		#region Video Encoder Test

		static void TestVideoEncoder ()
		{
			var video = new Video () { Title = "Video 1" }; // Information about a video
			var videoEncoder = new VideoEncoder (); // publisher 

			var mailService = new MailService ();	// subscriber
			var youtubeService = new Youtube ();	// subscriber
			var vkService = new Vkontate ();        // subscriber

			// Subscriber that exactly who will be get information about any event. 
			// Also you can have many subscribers to one publisher.
			// Who will be get the messages about event

			videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
			videoEncoder.VideoEncoded += youtubeService.OnVideEncoded;
			videoEncoder.VideoEncoded += vkService.OnVideoEncoded;

			videoEncoder.Encode (video);

			// Delete the one event member
			videoEncoder.VideoEncoded -= vkService.OnVideoEncoded;

			Console.WriteLine ();
			videoEncoder.Encode (video);
		}

		#endregion
	}

	#region Handler Delegate
	delegate void Handler (); // Crate delegate for event
	class Incrementer
	{
		public event Handler CountedADozen; // Create a publish an event

		public void DoCount ()
		{
			for (int i = 0; i < 100; i += 12)
			{
				CountedADozen?.Invoke (); // Invoke the delegate
			}
		}
	}

	class Dozens
	{
		public int DozensCount { get; private set; }

		public Dozens (Incrementer incrementer)
		{
			DozensCount = 0;
			incrementer.CountedADozen += IncrementDozensCount; // Subscribe to the event
		}

		void IncrementDozensCount () // Declare the event handler
		{
			DozensCount++; // Increment the dozens counter
		}

	}
	#endregion

	#region Event Handler
	public class IncrementerEventArgs : EventArgs
	{
		public int IterationCount { get; set; }
		public int TotalIterationNumber { get; set; }
	}

	class IncrementerEventHandler
	{
		public event EventHandler<IncrementerEventArgs> CountedADozen;

		public void DoCount ()
		{
			IncrementerEventArgs args = new IncrementerEventArgs ();
			for (int i = 1; i < 100; i++)
			{
				args.TotalIterationNumber++;
				if (i % 12 == 0 && CountedADozen != null)
				{
					args.IterationCount = i;
					CountedADozen (this, args);
				}
			}
		}
	}

	class DozensEventHandler
	{
		public int DozensCount { get; private set; }

		public DozensEventHandler (IncrementerEventHandler incrementer)
		{
			DozensCount = 0;
			incrementer.CountedADozen += IncrementDozensCount;
		}

		void IncrementDozensCount (object source, IncrementerEventArgs e)
		{
			Console.WriteLine ($"Incremented at iteration: {e.IterationCount} in {source.ToString ()}");
			Console.WriteLine ($"Total iteration number: {e.TotalIterationNumber}");
			DozensCount++;
		}
	}
	#endregion

	#region Account 

	class AccountEvetArgs
	{
		public string Message { get; }
		public int Sum { get; }

		public AccountEvetArgs (string message, int sum)
		{
			Message = message;
			Sum = sum;
		}
	}

	class Account
	{
		public delegate void AccountStateHandler (object sender, AccountEvetArgs e);
		public event AccountStateHandler OnWithdrawn;
		public event AccountStateHandler OnAdded;

		private int sum;

		public Account (int sum)
		{
			this.sum = sum;
		}

		public int CurrentSum
		{
			get { return sum; }
		}

		public void Put (int sum)
		{
			this.sum += sum;
			if (OnAdded != null)
			{
				OnAdded (this, new AccountEvetArgs ($"На счет было положено {sum}", sum));
			}
		}

		public void Withdraw (int sum)
		{
			if (sum <= this.sum)
			{
				this.sum -= sum;
				if (OnWithdrawn != null)
				{
					OnWithdrawn (this, new AccountEvetArgs ($"Сумма {sum} была снята со счета", sum));
				}
			}
			else
			{
				if (OnWithdrawn != null)
				{
					OnWithdrawn (this, new AccountEvetArgs ("Не достаточно денег на счете", sum));
				}
			}
		}
	}
	#endregion

	#region Video Encoder

	class Video
	{
		public string Title { get; set; }
	}

	class VideoEventArgs : EventArgs
	{
		public Video Video { get; set; }
	}

	class VideoEncoder
	{
		// 1 - Define a delegate
		// 2 - Define an event based on that delegate
		// 3 - Raise the event

		// EventHandler
		// EventHandler<TEventArgs>

		//public delegate void VideoEncodedEventHandler (object sender, VideoEventArgs args);
		public event EventHandler<VideoEventArgs> VideoEncoded;

		public void Encode (Video video)
		{ 
			Console.WriteLine ("Encoding Video...");
			System.Threading.Thread.Sleep (2000);

			OnVideoEncoded (video);
		}

		protected virtual void OnVideoEncoded(Video video)
		{
			if (VideoEncoded != null)
			{
				VideoEncoded (this, new VideoEventArgs () { Video = video });
			}
		}
	}

	class MailService
	{
		public void OnVideoEncoded(object sender, VideoEventArgs e)
		{
			Console.WriteLine ("MailService: Sending an email..." + e.Video.Title);
		}
	}

	class Youtube
	{
		public void OnVideEncoded(object sender, VideoEventArgs e)
		{
			Console.WriteLine ("YouTube: Sending video..." + e.Video.Title);
		}
	}

	class Vkontate
	{
		public void OnVideoEncoded(object sender, VideoEventArgs e)
		{
			Console.WriteLine ("VK: loading a video..." + e.Video.Title);
		}
	}

	#endregion
}
