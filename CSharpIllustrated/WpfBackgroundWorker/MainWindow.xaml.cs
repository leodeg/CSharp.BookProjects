using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfBackgroundWorker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		BackgroundWorker backgroundWorker = new BackgroundWorker ();

		public MainWindow ()
		{
			InitializeComponent ();

			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.WorkerSupportsCancellation = true;

			backgroundWorker.DoWork += DoWork_Handler;
			backgroundWorker.ProgressChanged += ProgressChanged_Handler;
			backgroundWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
		}

		private void btnProcess_Click (object sender, RoutedEventArgs e)
		{
			if (!backgroundWorker.IsBusy)
			{
				backgroundWorker.RunWorkerAsync ();
			}
		}

		private void ProgressChanged_Handler (object sender, ProgressChangedEventArgs args)
		{
			progressBar.Value = args.ProgressPercentage;
		}

		private void DoWork_Handler (object sender, DoWorkEventArgs args)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			for (int i = 0; i <= 10; i++)
			{
				if (worker.CancellationPending)
				{
					args.Cancel = true;
					break;
				}
				else
				{
					worker.ReportProgress (i * 10);
					Thread.Sleep (500);
				}
			}
		}

		private void RunWorkerCompleted_Handler (object sender, RunWorkerCompletedEventArgs args)
		{
			progressBar.Value = 0;

			if (args.Cancelled)
			{
				MessageBox.Show ("Process was cancelled.", "Process Cancelled");
			}
			else
			{
				MessageBox.Show ("Process completed normally.", "Process Completed");
			}
		}

		private void btnCancel_Click (object sender, RoutedEventArgs e)
		{
			backgroundWorker.CancelAsync ();
		}
	}
}
