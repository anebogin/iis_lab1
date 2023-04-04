using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace IIS_lab1
{
    class FinanceUa : CurrencyAPI
    {
        private static HtmlDocument htmlDocument;

        public override string[] GetDollar()
        {
            Task task = Task.Factory.StartNew(() => SendRequest());
            task.Wait();
            System.Threading.Thread.Sleep(1500);
            if (htmlDocument != null)
            {               
                var currenciesDocumentListHtml = htmlDocument.DocumentNode.SelectNodes("//div[@class='fua-xrates__list']/a[@class='fua-xrates__row']");
                var dollar = currenciesDocumentListHtml[0].SelectNodes(".//span[@class='fua-xrates__value']");
                var buyText = dollar[0].InnerText;
                var sellText = dollar[1].InnerText;
                var buy = buyText.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                var sell = sellText.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                return new string[] { buy[1], sell[1] };
            }
            else
            {
                return null;
            }
        }

        public override string[] GetEuro()
        {
            if (htmlDocument != null)
            {
                var currenciesDocumentListHtml = htmlDocument.DocumentNode.SelectNodes("//div[@class='fua-xrates__list']/a[@class='fua-xrates__row']");
                var eur = currenciesDocumentListHtml[1].SelectNodes(".//span[@class='fua-xrates__value']");
                var buyText = eur[0].InnerText;
                var sellText = eur[1].InnerText;
                var buy = buyText.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                var sell = sellText.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                return new string[] { buy[1], sell[1] };
            }
            else
            {
                return null;
            }
        }

        private static async void SendRequest()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.FinanceUaUrl);
                htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
