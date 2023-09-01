using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class Mortgage_Calculator : Page
	{
		public Mortgage_Calculator()
		{
			this.InitializeComponent();
		}

		double borrow;
		double years;
		double months;
		double yearInt;
		double monthInt;
		double monthRepay;

		private async void calc_Click(object sender, RoutedEventArgs e)
		{
			int years, months;
			double principle, yearRate, monthRate;
			try
			{
				principle = double.Parse(borrowInput.Text);
			}
			catch (Exception ex)
			{
				MessageDialog dialogMessage = new MessageDialog("Error please enter a principle loan amount" + ex.Message);
				await dialogMessage.ShowAsync();
				borrowInput.Focus(FocusState.Programmatic);
				borrowInput.SelectAll();
				return;
			}
			try
			{
				years = int.Parse(yearsInput.Text);
			}
			catch (Exception ex)
			{
				MessageDialog dialogMessage = new MessageDialog("Error please enter the years" + ex.Message);
				await dialogMessage.ShowAsync();
				yearsInput.Focus(FocusState.Programmatic);
				yearsInput.SelectAll();
				return;
			}
			try
			{
				months = int.Parse(monthsInput.Text);
			}
			catch (Exception ex)
			{
				MessageDialog dialogMessage = new MessageDialog("Error please enter the months" + ex.Message);
				await dialogMessage.ShowAsync();
				monthsInput.Focus(FocusState.Programmatic);
				monthsInput.SelectAll();
				return;
			}
			try
			{
				yearRate = double.Parse(yearInterestInput.Text);
			}
			catch (Exception ex)
			{
				MessageDialog dialogMessage = new MessageDialog("Error please enter the yearly interest rate" + ex.Message);
				await dialogMessage.ShowAsync();
				yearInterestInput.Focus(FocusState.Programmatic);
				yearInterestInput.SelectAll();
				return;
			}

			principle = double.Parse(borrowInput.Text);
			yearRate = double.Parse(yearInterestInput.Text);
			monthRate = yearRate / 12 / 100;
			double mRepayment = calcMonthlyPayment(principle, years, monthRate);
			monthInterest.Text = monthRate.ToString("N4") + "%";
			monthlyRepay.Text = mRepayment.ToString("C");

		}

		private double calcMonthlyPayment(double principle, int years, double monthRate)
		{
			int months = years * 12;
			double monthRepay = principle * (monthRate * Math.Pow(1 + monthRate, months)) / (Math.Pow(1 + monthRate, months) - 1);
			return monthRepay;
		}


		private void exit_Click(object sender, RoutedEventArgs e)
		{
			exit_Click(null, null);
		}
	}
}