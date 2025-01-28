using CurrencyConverter.AppData;
using CurrencyConverter.Model;
using System;
using System.Windows;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrencyService _currencyService;
        public MainWindow()
        {
            InitializeComponent();

            _currencyService = new CurrencyService();
        }

        private async void UpdateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            await _currencyService.LoadCurrencyAsync(CurrencyLv);
            _currencyService.LoadValutes(PurchaseCmb);
            _currencyService.LoadValutes(SellCmb);
        }

        private void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            double sellAmount = Convert.ToDouble(SellTb.Text);
            Valute buyValute = PurchaseCmb.SelectedItem as Valute;
            Valute sellValute = SellCmb.SelectedItem as Valute;

            BuyTb.Text = _currencyService.ConvertValute(sellAmount, sellValute, buyValute);

            _currencyService.SetRatio(SellTbl, BuyTbl);
        }
    }
}
