using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	/// Big Thank you to Jeff Smith.
	/// /// </summary>
	public sealed partial class Currency_Converter : Page
	{
		public Currency_Converter()
		{
			this.InitializeComponent();
		}

		private void buttonExit_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void buttonCalculate_Click(object sender, RoutedEventArgs e)
		{
			double amount = double.Parse(textboxAmount.Text);

			string fromCurrency = comboboxFrom.SelectedItem.ToString();
			string toCurrency = comboboxTo.SelectedItem.ToString();

			Console.WriteLine("amountString = " + amount.ToString());
			Console.WriteLine("fromCurrency = " + fromCurrency);
			Console.WriteLine("toCurrency = " + toCurrency);

			setInputDisplay(fromCurrency, amount);

			string currencySign = getCurrencySign(toCurrency);
			double conversionRate = getConversionRate(fromCurrency, toCurrency);
			double result = calcResult(amount, conversionRate);
			setOutputDisplay(currencySign, result);

		}

		private void setInputDisplay(string fromCurrency, double amount)
		{
			textblockDisplayInput.Text = amount.ToString() + " " + fromCurrency + "s = ";
		}

		private string getCurrencySign(string toCurrency)
		{
			string currencySign = "";
			switch (toCurrency)
			{
				case "US Dollar":
					currencySign = "$";
					break;
				case "Euro":
					currencySign = "€";
					break;
				case "British Pound":
					currencySign = "£";
					break;
				case "Indian Rupee":
					currencySign = "₹";
					break;
			}
			return currencySign;
		}

		private double getConversionRate(string fromCurrency, string toCurrency)
		{
			// Exit early if same currency from and to
			if (fromCurrency == toCurrency)
			{
				return 1.0;
			}

			if (fromCurrency == "US Dollar")
			{
				switch (toCurrency)
				{
					case "Euro":
						return 0.85189982;
					case "British Pound":
						return 0.72872436;
					case "Indian Rupee":
						return 74.257327;
				}
			}

			if (fromCurrency == "Euro")
			{
				switch (toCurrency)
				{
					case "US Dollar":
						return 1.1739732;
					case "British Pound":
						return 0.8556672;
					case "Indian Rupee":
						return 87.00755;
				}
			}

			if (fromCurrency == "British Pound")
			{
				switch (toCurrency)
				{
					case "US Dollar":
						return 1.371907;
					case "Euro":
						return 1.1686692;
					case "Indian Rupee":
						return 101.68635;
				}
			}

			if (fromCurrency == "Indian Rupee")
			{
				switch (toCurrency)
				{
					case "US Dollar":
						return 0.011492628;
					case "Euro":
						return 0.013492774;
					case "British Pound":
						return 0.0098339397;
				}
			}

			return 0.0;
		}

		private double calcResult(double amount, double conversionRate)
		{
			return amount * conversionRate;
		}

		private void setOutputDisplay(string currencySign, double result)
		{
			textblockDisplayOutput.Text = currencySign + result.ToString();
		}
	}
}
