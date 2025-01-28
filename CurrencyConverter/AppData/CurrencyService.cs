using CurrencyConverter.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyConverter.AppData
{
    public class CurrencyService
    {
        private const string JSON_PATH = "https://www.cbr-xml-daily.ru/daily_json.js";

        private double buyAmount;
        private double sellAmount;
        private Valute buyValute;
        private Valute sellValute;
        private double sellRatio;
        private double buyRatio;

        public List<Valute> Valutes { get; private set; }
        public async Task LoadCurrencyAsync(ListView listView)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(JSON_PATH);

                Currency currency = JsonConvert.DeserializeObject<Currency>(response);

                Valutes = currency.Valute.Values.ToList();
                Valutes.Insert(0, new Valute()
                {
                    ID = "R00001",
                    NumCode = "643",
                    CharCode = "RUB",
                    Nominal = 1,
                    Name = "Российский рубль",
                    Value = 1.0,
                    Previous = 1.0
                });

                listView.ItemsSource = Valutes;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public void LoadValutes(ComboBox comboBox)
        {
            comboBox.ItemsSource = Valutes;
        }

        public string ConvertValute(double sellAmount, Valute sellValute, Valute buyValute)
        {
            this.sellAmount = sellAmount;
            this.sellValute = sellValute;
            this.buyValute = buyValute;
            buyAmount = sellAmount * buyValute.Nominal / sellValute.Nominal * sellValute.Value / buyValute.Value;

            return $"{buyAmount:F4}";
        }

        public void SetRatio(TextBlock sellTbl, TextBlock buyTbl)
        {
            sellRatio = buyAmount / sellAmount;
            buyRatio = sellAmount / buyAmount;

            sellTbl.Text = $"1 {sellValute.CharCode} = {sellRatio:F4} {buyValute.CharCode}";
            buyTbl.Text = $"1 {buyValute.CharCode} = {buyRatio:F4} {sellValute.CharCode}";
        }
    }
}
