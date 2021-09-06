using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        private void addButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                if (valueText.Text != "")
                {
                    int getDate = datePicker.Date.Year * 10000 + datePicker.Date.Month * 100 + datePicker.Date.Day;
                    MoneyAdded moneyAdded = new MoneyAdded
                    {
                        AddedMoney = double.Parse(valueText.Text, CultureInfo.InvariantCulture),
                        DateTime = getDate,
                        Note = textNota.Text
                    };
                    conn.Insert(moneyAdded);
                    Navigation.PushAsync(new MainPage());
                }  
            }
        }

        private void spendButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
               if (valueText.Text != "")
               {
                    int getDate = datePicker.Date.Year * 10000 + datePicker.Date.Month * 100 + datePicker.Date.Day;
                    MoneySpent moneySpent = new MoneySpent()
                   {
                       SpentMoney = double.Parse(valueText.Text, CultureInfo.InvariantCulture),
                       DateTime = getDate,
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
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "2";
        }

        private void btn3_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "3";
        }

        private void btnC_Clicked(object sender, EventArgs e)
        {
            valueText.Text = "";
        }

        private void btn4_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "4";
        }

        private void btn5_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "5";
        }

        private void btn6_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "6";
        }

        private void btnCE_Clicked(object sender, EventArgs e)
        {
            if (valueText.Text.Length != 0) valueText.Text = valueText.Text.Remove(valueText.Text.Length - 1);
        }

        private void btn7_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "7";
        }

        private void btn8_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "8";
        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            valueText.Text += "9";
        }

        private void btnDot_Clicked(object sender, EventArgs e)
        {
            valueText.Text += ".";
        }
    }
}