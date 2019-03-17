using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Chapter1
{
	internal class Program
	{
		private static void Main (string[] args)
		{
			//ThreadsExample.StartTest ();
			TaskExample.StartTest ();
		}
	}

	internal class ThreadsExample
	{
		public static void StartTest ()
		{
			UseThread_LocalField ();
		}



		#region Thread Local Fields Methods

		private static ThreadLocal<int> _fieldLocal = new ThreadLocal<int> (() =>
		{
			return Thread.CurrentThread.ManagedThreadId;
		});

		private static void UseThread_LocalField ()
		{
			new Thread (() =>
			{
				for (int i = 0; i < _fieldLocal.Value; i++)
				{
					_field++;
					Console.WriteLine ("Thread A: {0}", _field);
				}
			}).Start ();

			new Thread (() =>
			{
				for (int i = 0; i < _fieldLocal.Value; i++)
				{
					_field++;
					Console.WriteLine ("Thread B: {0}", _field);
				}
			}).Start ();

			Console.ReadKey ();
		}

		#endregion

		#region Static Fields Method

		[ThreadStatic] private static int _field;
		private static void UseThread_StaticField ()
		{
			new Thread (() =>
			{
				for (int i = 0; i < 10; i++)
				{
					_field++;
					Console.WriteLine ("Thread A: {0}", _field);
				}
			}).Start ();

			new Thread (() =>
			{
				for (int i = 0; i < 10; i++)
				{
					_field++;
					Console.WriteLine ("Thread B: {0}", _field);
				}
			}).Start ();

			Console.ReadKey ();
		}

		#endregion

		#region Thread Methods

		private static void UseThread_Paramethrized ()
		{
			Thread thread = new Thread (new ParameterizedThreadStart (ThreadMethod));
			thread.Start (5);
			thread.Join ();
		}

		private static void UseThreadMethods_Abort ()
		{
			bool stopped = false;

			Thread thread = new Thread (new ThreadStart (() =>
			{
				while (!stopped)
				{
					Console.WriteLine ("Running...");
					Thread.Sleep (100);
				}
			}));

			// Start thread
			thread.Start ();
			Console.WriteLine ("Press any key to exit");

			// Stop thread method if some key is pressed
			Console.ReadKey ();
			Console.WriteLine ("\nKey is pressed");

			// Stop thread
			stopped = true;
			thread.Join ();
		}

		private static void UseThreadMethods_BG ()
		{
			Thread thread = new Thread (new ThreadStart (ThreadMethod));
			thread.IsBackground = true;
			thread.Start ();
		}

		private static void UseThreadMethods ()
		{
			Thread thread = new Thread (new ThreadStart (ThreadMethod));
			thread.Start ();

			for (int i = 0; i < 4; i++)
			{
				Console.WriteLine ("Main Thread {0}: do some work...", i);
				Thread.Sleep (0);
			}

			thread.Join ();
		}

		#endregion

		#region Helper Methods

		private static void ThreadMethod ()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine ("Thread process: {0}", i);
				Thread.Sleep (100);
			}
		}

		private static void ThreadMethod (object o)
		{
			for (int i = 0; i < (int)o; i++)
			{
				Console.WriteLine ("Thread process: {0}", i);
				Thread.Sleep (100);
			}
		}

		#endregion
	}

	internal class TaskExample
	{
		public static void StartTest ()
		{
			UseBlocking ();
		}

		#region Task Methods

		private static void UseTaskSimple ()
		{
			Task task = Task.Run (() =>
			{
				for (int i = 0; i < 50; i++)
				{
					Console.WriteLine ("*");
				}
			});

			task.Wait ();
		}

		private static void UseTaskOfTSimple ()
		{
			Task<int> task = Task.Run (() => 42);

			task.ContinueWith ((x) => Console.WriteLine ("Canceled"), TaskContinuationOptions.OnlyOnCanceled);

			task.ContinueWith ((x) => Console.WriteLine ("Faulted"), TaskContinuationOptions.OnlyOnFaulted);

			var completedTask = task.ContinueWith ((i) => Console.WriteLine ("Completed"), TaskContinuationOptions.OnlyOnRanToCompletion);

			completedTask.Wait ();
		}

		private static void UseTaskOfTArray ()
		{
			Task<Int32[]> parent = Task.Run (() =>
			{
				var result = new Int32[3];
				new Task (() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start ();
				new Task (() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start ();
				new Task (() => result[2] = 2, TaskCreationOptions.AttachedToParent).Start ();
				return result;
			});

			var final = parent.ContinueWith (parentTask =>
			{
				foreach (int i in parent.Result)
					Console.WriteLine (i);
			});

			final.Wait ();
		}

		#endregion

		#region Factory

		private static void UseTaskFactory ()
		{
			Task<Int32[]> parent = Task.Run (() =>
			{
				var results = new Int32[3];

				TaskFactory taskFactory = new TaskFactory (TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

				taskFactory.StartNew (() => results[0] = 0);
				taskFactory.StartNew (() => results[1] = 1);
				taskFactory.StartNew (() => results[2] = 2);

				return results;
			});

			var final = parent.ContinueWith (parentTask =>
			{
				foreach (int i in parentTask.Result)
				{
					Console.WriteLine (i);
				}
			});

			final.Wait ();
		}

		private static void UseTaskStringExample ()
		{
			Task<string[]> parent = Task.Run (() =>
			{
				var result = new string[4];

				var tf = new TaskFactory (TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

				tf.StartNew (() => result[0] = "Yop " + 0);
				tf.StartNew (() => result[1] = "Yop " + 1);
				tf.StartNew (() => result[2] = "Yop " + 2);
				tf.StartNew (() => result[3] = "Yop " + 3);

				return result;
			});

			var final = parent.ContinueWith (parnetTask =>
			{
				foreach (string s in parnetTask.Result)
				{
					Console.WriteLine (s);
				}
			});

			final.Wait
 ();
		}

		#endregion

		#region Wait

		private static void UseTaskWaitAll ()
		{
			Task[] tasks = new Task[3];

			tasks[0] = Task.Run (() =>
			{
				Thread.Sleep (1000);
				Console.WriteLine ("1");
			});

			tasks[1] = Task.Run (() =>
			{
				Thread.Sleep (1000);

				Console.WriteLine ("2");
			});

			tasks[2] = Task.Run (() =>
			{
				Thread.Sleep (1000);
				Console.WriteLine ("3");
			});

			Task.WaitAll (tasks);
		}

		private static void UseTaskWaitAny ()
		{
			Task<int>[] tasks = new Task<int>[3];

			tasks[0] = Task.Run (() => { Thread.Sleep (2000); return 1; });
			tasks[1] = Task.Run (() => { Thread.Sleep (1000); return 2; });
			tasks[2] = Task.Run (() => { Thread.Sleep (3000); return 3; });

			while (tasks.Length > 0)
			{
				// Index of a completed task
				int i = Task.WaitAny (tasks);

				// Current completed task
				Task<int> completedTask = tasks[i];

				Console.WriteLine ("Completed task: {0}", completedTask.Result);

				// Delete completed task
				var temp = tasks.ToList ();
				temp.RemoveAt (i);
				tasks = temp.ToArray ();

				Console.WriteLine ("Tasks array has: {0} task(s)", tasks.Length.ToString ());

				if (tasks.Length < 1)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("Tasks array is empty...");
					Console.ForegroundColor = ConsoleColor.White;

				}
			}
		}

		#endregion

		#region Parallel

		private static void UseParallel ()
		{
			ParallelLoopResult result = Parallel.For (0, 1000, (int i, ParallelLoopState state) =>
			{
				if (i == 500)
				{
					Console.WriteLine ("Breaking loop");
					state.Break ();
				}

				return;
			});

			Console.WriteLine ("Is Completed: {0}", result.IsCompleted);
			Console.WriteLine ("Lowest break iteration: {0}", result.LowestBreakIteration);

			// If break => completed - false, lowest break operation - 500
			// If stop => completed - false, lowest break operation - nothing 
			// Else => completed - true, lowest break operation - nothing
		}

		private static void UseAsParallel ()
		{
			var numbers = Enumerable.Range (0, 20);
			var parallelResult = numbers.AsParallel ().AsOrdered ().Where (i => i % 2 == 0).ToArray ();
			foreach (var item in parallelResult)
				Console.WriteLine (item);

		}

		private static void UseAsParallelForAll ()
		{
			var numbers = Enumerable.Range (0, 20);
			var parallelResult = numbers.AsParallel ().Where (i => i % 2 == 0);
			parallelResult.ForAll (Console.WriteLine);
		}

		private static void UseAsParallelIsEven ()
		{
			var numbers = Enumerable.Range (0, 20);

			try
			{
				var result = numbers.AsParallel ().Where (i => IsEven (i));
				result.ForAll (Console.WriteLine);
			}
			catch (AggregateException ex)
			{
				Console.WriteLine ("There was {0} exceptions", ex.InnerExceptions.Count);
			}
		}

		private static bool IsEven (int value)
		{
			if (value % 10 == 0) throw new ArgumentException (value.ToString());
			return value % 2 == 0;
		}

		#endregion

		#region Collections

		private static void UseBlocking ()
		{
			BlockingCollection<string> col = new BlockingCollection<string> ();

			Task read = Task.Run (() => {
				while (true)
				{
					// Remove an item
					Console.WriteLine (col.Take());
				}
			});

			Task write = Task.Run (() => {
				while (true)
				{
					string text = Console.ReadLine ();

					// Break if user didn't write any text
					if (string.IsNullOrWhiteSpace (text)) break;

					// Add a new item
					col.Add (text);
				}
			});

			write.Wait ();
		}

		#endregion

		#region Async

		private static void UseAsync ()
		{
			string url = "http://www.microsoft.com";
			string result = DownloadContent (url).Result;
			Console.WriteLine (result);
		}

		/// <summary>
		/// Download html content from website.
		/// </summary>
		private static async Task<string> DownloadContent (string url)
		{
			using (HttpClient client = new HttpClient ())
			{
				return await client.GetStringAsync (url);
			}
		}

		private Task SleepAsyncA (int millisecondsTimeout)
		{
			return Task.Run (() => Thread.Sleep (millisecondsTimeout));
		}

		private Task SleepAsyncB (int millisecondsTimeout)
		{
			TaskCompletionSource<bool> completionSource = null;

			TimerCallback callback = delegate { completionSource.TrySetResult (true); };
			var timer = new Timer (callback, null, -1, -1);

			completionSource = new TaskCompletionSource<bool> (timer);
			timer.Change (millisecondsTimeout, -1);
			return completionSource.Task;
		}

		#endregion

	}
}
