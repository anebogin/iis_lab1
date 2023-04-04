using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIS_lab1
{
    public partial class ExchangeForm : Form
    {
        static string dollarPurchaseMinfinComUa, dollarSaleMinfinComUa,
        euroPurchaseMinfinComUa, euroSaleMinfinComUa;
        static string dollarPurchaseKursComUa, dollarSaleKursComUa, euroPurchaseKursComUa,
        euroSaleKursComUa;

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMinfinComUaData();
            LoadKursComUaData();
            LoadFinanceUaData();
            dataCurrencyTable.DataSource = SetData();
        }

        static string dollarPurchaseFinanceUa, dollarSaleFinanceUa, euroPurchaseFinanceUa,
        euroSaleFinanceUa, rublePurchaseFinanceUa, rubleSaleFinanceUa;

        public ExchangeForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static DataTable SetData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(Properties.Resources.ResourceColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.CurrencyColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.PurchaseColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.SaleColumnTitle, typeof(string));
            dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Dollar,
            dollarPurchaseMinfinComUa, dollarSaleMinfinComUa);
            dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Euro,
            euroPurchaseMinfinComUa, euroSaleMinfinComUa);
            dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Dollar,
            dollarPurchaseKursComUa, dollarSaleKursComUa);
            dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Euro,
            euroPurchaseKursComUa, euroSaleKursComUa);
            dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Dollar,
            dollarPurchaseFinanceUa, dollarSaleFinanceUa);
            dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Euro,
            euroPurchaseFinanceUa, euroSaleFinanceUa);
            return dataTable;
        }
        public static void LoadMinfinComUaData()
        {
            try
            {
                MinfinComUa minfinComUa = new MinfinComUa();
                var dollarMinfinComUa = minfinComUa.GetDollar();
                if (dollarMinfinComUa != null)
                {
                    dollarPurchaseMinfinComUa = dollarMinfinComUa[0];
                    dollarSaleMinfinComUa = dollarMinfinComUa[1];
                }
                var euroMinfinComUa = minfinComUa.GetEuro();
                if (euroMinfinComUa != null)
                {
                    euroPurchaseMinfinComUa = euroMinfinComUa[0];
                    euroSaleMinfinComUa = euroMinfinComUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void LoadKursComUaData()
        {
            try
            {
                KursComUa kursComUa = new KursComUa();
                var dollarKursKomUa = kursComUa.GetDollar();
                if (dollarKursKomUa != null)
                {
                    dollarPurchaseKursComUa = dollarKursKomUa[0];
                    dollarSaleKursComUa = dollarKursKomUa[1];
                }
                var euroKursKomUa = kursComUa.GetEuro();
                if (euroKursKomUa != null)
                {
                    euroPurchaseKursComUa = euroKursKomUa[0];
                    euroSaleKursComUa = euroKursKomUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void LoadFinanceUaData()
        {
            try
            {
                FinanceUa financeUa = new FinanceUa();
                var dollarFinanceUa = financeUa.GetDollar();
                if (dollarFinanceUa != null)
                {
                    dollarPurchaseFinanceUa = dollarFinanceUa[0];
                    dollarSaleFinanceUa = dollarFinanceUa[1];
                }
                var euroFinanceUa = financeUa.GetEuro();
                if (euroFinanceUa != null)
                {
                    euroPurchaseFinanceUa = euroFinanceUa[0];
                    euroSaleFinanceUa = euroFinanceUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
