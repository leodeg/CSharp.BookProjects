using System;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Chapter_21
{
	class Program
	{
		static void Main (string[] args)
		{
			DownloadStringTest ();
		}

		static void DownloadStringTest()
		{
			DownloadString download = new DownloadString ();
			download.DoRun ();
		}
	}

	class DownloadString
	{
		Stopwatch stopwatch = new Stopwatch ();

		public void DoRun()
		{
			const int largeNumber = 6_000_000;
			stopwatch.Start ();

			Task<int> t1 = CountCharactersAsync (1, "http://www.microsoft.com");
			Task<int> t2 = CountCharactersAsync (2, "http://www.illustratedcsharp.com");

			CountToLargeNumber (1, largeNumber);
			CountToLargeNumber (2, largeNumber);
			CountToLargeNumber (3, largeNumber);
			CountToLargeNumber (4, largeNumber);
			CountToLargeNumber (5, largeNumber);

			Console.WriteLine ($"Chars in http://www.microsoft.com : { t1 }");
			Console.WriteLine ($"Chars in http://www.illustratedcsharp.com: { t2 }");
		}

		private async Task<int> CountCharactersAsync(int id, string uriString)
		{
			WebClient webClient = new WebClient ();
			Console.WriteLine ("Starting call {0} : {1, 4:N0} ms", id, stopwatch.Elapsed.TotalMilliseconds);

			string result = await webClient.DownloadStringTaskAsync (new Uri (uriString));

			Console.WriteLine ("Call {0} completed: {1, 4:N0} ms", id, stopwatch.Elapsed.TotalMilliseconds);
			return result.Length;
		}

		private void CountToLargeNumber(int id, int value)
		{
			for (int i = 0; i < value; i++);
			Console.WriteLine ("End counting {0} : {1, 4:N0} ms", id, stopwatch.Elapsed.TotalMilliseconds);
		}
	}
}
