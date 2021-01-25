using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitcoinCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void getRatesBtn_Click(object sender, EventArgs e)
        {
            if(currencyMenu.SelectedItem.ToString() == "EUR")
            {
                resultLabel.Visible = true;
                result.Visible = true;

                BitcoinRates resultRates = GetRates();
                int userCoins = Int32.Parse(amountOfBTC.Text);
                float currentrate = resultRates.bpi.EUR.rate_float;
                float btcResult = userCoins * currentrate;
                result.Text = $"{btcResult} {resultRates.bpi.EUR.code}";
            }else if(currencyMenu.SelectedItem.ToString() == "USD")
            {
                resultLabel.Visible = true;
                result.Visible = true;

                BitcoinRates resultRates = GetRates();
                int userCoins = Int32.Parse(amountOfBTC.Text);
                float currentrate = resultRates.bpi.USD.rate_float;
                float btcResult = userCoins * currentrate;
                result.Text = $"{btcResult} {resultRates.bpi.USD.code}";
            }else if(currencyMenu.SelectedItem.ToString() == "GBP")
            {
                resultLabel.Visible = true;
                result.Visible = true;

                BitcoinRates resultrates = GetRates();
                int usercoins = Int32.Parse(amountOfBTC.Text);
                float currentrate = resultrates.bpi.GBP.rate_float;
                float btcResult = usercoins * currentrate;
                result.Text = $"{btcResult} {resultrates.bpi.GBP.code}";
            }
        }

        public static BitcoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            BitcoinRates bitcoin;

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitcoinRates>(response);
            }

            return bitcoin;
        }
    }
}
