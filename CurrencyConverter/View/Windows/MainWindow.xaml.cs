using CurrencyConverter.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrrencyService _currencyService;
        public MainWindow()
        {
            InitializeComponent();

            _currencyService = new CurrrencyService();
        }

        private void SellCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void PurchaseCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void UpdateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            await _currencyService.LoadCurrencyAsync(CurrencyLv);
            _currencyService.LoadValutes(SellCmb);
            _currencyService.LoadValutes(PurchaseCmb);
        }

        private void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            double sellAmount = Convert.ToDouble(SellTb.Text);
            Valute sellValute = SellCmb.SelectedItem as Valute;
            Valute buyValute = PurchaseCmb.SelectedItem as Valute;

            BuyTb.Text = _currencyService.ConvertValute(sellAmount, sellValute, buyValute);
        }
    }
}
