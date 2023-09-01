using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Trip_Calculator : Page
	{
		public Trip_Calculator()
		{
			this.InitializeComponent();
		}

		private void buttonTodayDate_Click(object sender, RoutedEventArgs e)
		{
			DateTime today = DateTime.Today;
			dateDateHire.Date = today;

		}

		private void buttonCalculate_Click(object sender, RoutedEventArgs e)
		{
			string daysString = textBoxNumberDaysHired.Text;
			int days = int.Parse(daysString);

			string priceString = textBoxPricePerDay.Text;
			double price = double.Parse(priceString);

			double amount = days * price;
			textBoxAmount.Text = amount.ToString();
		}

		private void buttonExit_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}