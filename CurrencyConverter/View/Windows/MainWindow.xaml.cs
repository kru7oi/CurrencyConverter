using CurrencyConverter.Model;
using System.Windows;
using System.Windows.Controls;

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
            double sellAmount = double.Parse(SellTb.Text);
            Valute sellValute = SellCmb.SelectedItem as Valute;
            Valute buyValute = PurchaseCmb.SelectedItem as Valute;

            PurchaseTb.Text = _currencyService.Convert(sellAmount, sellValute, buyValute);
        }
    }
}
