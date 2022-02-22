using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MoneyManager.Database.Tables;

namespace MoneyManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMoney : ContentPage
    {
        public AddMoney()
        {
            InitializeComponent();
            spendButton.IsVisible = false;
        }

        public AddMoney(bool x)
        {
            InitializeComponent();
            addButton.IsVisible = false;
        }

        //When the Add Button is clicked
        private void addButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                if (valueText.Text != "")
                {
                    int getDate = datePicker.Date.Year * 10000 + datePicker.Date.Month * 100 + datePicker.Date.Day;
                    MoneyHistory moneyAdded = new MoneyHistory
                    {
                        Money = double.Parse(valueText.Text, CultureInfo.InvariantCulture),
                        DateTime = getDate.ToString(),
                        Note = textNota.Text
                    };
                    conn.Insert(moneyAdded);
                    Navigation.PushAsync(new MainPage());
                }
            }
        }

        //When the Spend Button is clicked
        private void spendButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                if (valueText.Text != "")
                {
                    int getDate = datePicker.Date.Year * 10000 + datePicker.Date.Month * 100 + datePicker.Date.Day;
                    MoneyHistory moneySpent = new MoneyHistory()
                    {
                        Money = -double.Parse(valueText.Text, CultureInfo.InvariantCulture),
                        DateTime = getDate.ToString(),
                        Note = textNota.Text
                    };
                    conn.Insert(moneySpent);
                    Navigation.PushAsync(new MainPage());
                }
            }
        }
        private void btn1_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "1";
            Check2Decimals();
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "2";
            Check2Decimals();
        }

        private void btn3_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "3";
            Check2Decimals();
        }

        private void btnC_Clicked(object sender, EventArgs e)
        {
            valueText.Text = null;
        }

        private void btn4_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "4";
            Check2Decimals();
        }

        private void btn5_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "5";
            Check2Decimals();
        }

        private void btn6_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "6";
            Check2Decimals();
        }

        private void btnCE_Clicked(object sender, EventArgs e)
        {
            if (valueText.Text.Length != 0) valueText.Text = valueText.Text.Remove(valueText.Text.Length - 1);
        }

        private void btn7_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "7";
            Check2Decimals();
        }

        private void btn8_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "8";
            Check2Decimals();
        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "9";
            Check2Decimals();
        }

        private void btnDot_Clicked(object sender, EventArgs e)
        {
            valueText.Text += ".";
            Check2Decimals();
        }

        private void btn0_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "0";
            Check2Decimals();
        }

        private void Check2Decimals()
        {
            if (valueText.Text.Contains("."))
            {
                string[] sDecimalCheck = valueText.Text.Split(new char[] { '.' });
                if (sDecimalCheck[1].Length > 2)
                {
                    valueText.Text = valueText.Text.Remove(valueText.Text.Length - 1);
                }
            }
        }
    }
}