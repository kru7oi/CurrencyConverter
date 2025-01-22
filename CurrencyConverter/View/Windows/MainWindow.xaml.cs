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

        private void UpdateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            _currencyService.LoadCurrencyAsync(CurrencyLv);
        }

        private void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
