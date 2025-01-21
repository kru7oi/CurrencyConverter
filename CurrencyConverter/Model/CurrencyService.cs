using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CurrencyConverter.Model
{
    public class CurrencyService
    {
        private const string JSON_PATH = "https://www.cbr-xml-daily.ru/daily_json.js";
        public List<Valute> Valutes { get; private set; }
        public Currency Currency { get; private set; }

        public async Task LoadCurrencyAsync(ListView listView)
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetStringAsync(JSON_PATH);

            if (!string.IsNullOrEmpty(response))
            {
                Currency = JsonConvert.DeserializeObject<Currency>(response);

                Valutes = Currency.Valute.Values.ToList();

                Valutes.Insert(0, new()
                {
                    ID = "R00001",
                    NumCode = "643",
                    CharCode = "RUB",
                    Nominal = 1,
                    Name = "Российский рубль",
                    Value = 1,
                    Previous = 1
                });

                listView.ItemsSource = Currency.Valute.Values;
            }
        }

        public void LoadValutes(ComboBox comboBox)
        {
            comboBox.ItemsSource = Valutes;
        }
    }
}
