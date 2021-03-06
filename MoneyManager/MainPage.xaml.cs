using SQLite;
using System;
using System.Linq;
using Xamarin.Forms;
using static MoneyManager.Database.Tables;

[assembly: ExportFont("OpenSans-Regular.ttf", Alias = "OpenSans-Regular")]
namespace MoneyManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            whenAppears();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMoney());
        }

        private void btnRemove_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMoney(true));
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            whenAppears();
        }

        private void whenAppears()
        {
            //The minimum date of the end date picker will always be the day selected on the start date picker
            endDatePicker.MinimumDate = startDatePicker.Date;
            double sumDoubleAdd = 0.00;
            double sumDoubleSpend = 0.00;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                //conn.DropTable<MoneyAdded>();
                //conn.DropTable<MoneySpent>();
                conn.CreateTable<MoneyAdded>();
                conn.CreateTable<MoneySpent>();
                int getDateStart = startDatePicker.Date.Year * 10000 + startDatePicker.Date.Month * 100 + startDatePicker.Date.Day;
                int getDateEnd = endDatePicker.Date.Year * 10000 + endDatePicker.Date.Month * 100 + endDatePicker.Date.Day;
                dateSaldoText.Text = DateTime.Now.ToString("dd/MM/yyyy");
                dateGastosText.Text = DateTime.Now.ToString("dd/MM/yyyy");
                var addMoneyVar = conn.Query<MoneyAdded>("SELECT * FROM MoneyAdded WHERE DateTime BETWEEN " + getDateStart + " AND " + getDateEnd);
                var spendMoneyVar = conn.Query<MoneySpent>("SELECT * FROM MoneySpent WHERE DateTime BETWEEN " + getDateStart + " AND " + getDateEnd);
                if (addMoneyVar.Count != 0)
                {
                    foreach (MoneyAdded moneyAdded in addMoneyVar)
                    {
                        sumDoubleAdd += moneyAdded.AddedMoney;
                    }
                    string replaceSum = sumDoubleAdd.ToString().Replace(".", ",");
                    saldoText.Text = replaceSum + "€";
                } 
                else { saldoText.Text = "0,00€"; }
                if (spendMoneyVar.Count != 0)
                {
                    foreach (MoneySpent moneySpent in spendMoneyVar)
                    {
                        sumDoubleSpend += moneySpent.SpentMoney;
                    }
                    string replaceSum = sumDoubleSpend.ToString().Replace(".", ",");
                    gastosText.Text = replaceSum + "€";
                }
                else { gastosText.Text = "0,00€"; }
            }
        }

        private void startDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            whenAppears();
        }

        private void endDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            whenAppears();
        }
    }
}
