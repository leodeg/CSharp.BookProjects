using System.Windows;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAwait
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		CancellationTokenSource cancellationTokenSource;
		CancellationToken cancellationToken;

		public MainWindow ()
		{
			InitializeComponent ();
		}

		private async void btnProcess_Click (object sender, RoutedEventArgs e)
		{
			btnProcess.IsEnabled = false;

			cancellationTokenSource = new CancellationTokenSource ();
			cancellationToken = cancellationTokenSource.Token;

			int completePercent = 0;
			for (int i = 0; i < 10; i++)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					break;
				}
				try
				{
					await Task.Delay (500, cancellationToken);
					completePercent = ( i + 1 ) * 10;
				}
				catch (TaskCanceledException ex)
				{
					completePercent = i * 10;
				}

				progressBar.Value = completePercent;
			}

			string message = cancellationToken.IsCancellationRequested
				? string.Format ($"Process was cancelled at {completePercent}%.")
				: "Process completed normally.";

			MessageBox.Show (message, "Completion Status");

			progressBar.Value = 0;
			btnProcess.IsEnabled = true;
			btnCancel.IsEnabled = true;
		}

		private void btnCancel_Click (object sender, RoutedEventArgs e)
		{
			if (!btnProcess.IsEnabled)
			{
				btnCancel.IsEnabled = false;
				cancellationTokenSource.Cancel ();
			}
		}
	}
}
