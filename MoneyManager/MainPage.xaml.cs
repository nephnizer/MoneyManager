using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;
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
            //Task.Run(AnimateBackground);
        }

        //private async void AnimateBackground()
        //{
        //    Action<double> forward = input => bdGradient.AnchorY = input;
        //    Action<double> backward = input => bdGradient.AnchorY = input;

        //    while (true)
        //    {
        //        bdGradient.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 7000, easing: Easing.SinIn);
        //        await Task.Delay(5000);
        //        bdGradient.Animate(name: "backward", callback: backward, start: 1, end: 0, length: 7000, easing: Easing.SinIn);
        //        await Task.Delay(5000);
        //    }
        //}

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
                //conn.DropTable<ShoppingList>();
                conn.CreateTable<MoneyHistory>();
                conn.CreateTable<ShoppingList>();
                int getDateStart = startDatePicker.Date.Year * 10000 + startDatePicker.Date.Month * 100 + startDatePicker.Date.Day;
                int getDateEnd = endDatePicker.Date.Year * 10000 + endDatePicker.Date.Month * 100 + endDatePicker.Date.Day;
                dateSaldoText.Text = DateTime.Now.ToString("dd/MM/yyyy");
                dateGastosText.Text = DateTime.Now.ToString("dd/MM/yyyy");
                var moneyVar = conn.Query<MoneyHistory>("SELECT * FROM MoneyHistory WHERE DateTime BETWEEN " + getDateStart + " AND " + getDateEnd);
                if (moneyVar.Count != 0)
                {
                    foreach (MoneyHistory moneyHistory in moneyVar)
                    {
                        if (moneyHistory.Money.ToString().Contains("-"))
                        {
                            sumDoubleSpend += moneyHistory.Money;
                            string replaceSum = sumDoubleSpend.ToString().Replace(".", ",");
                            gastosText.Text = replaceSum + "€";
                        }
                        else
                        {
                            sumDoubleAdd += moneyHistory.Money;
                            string replaceSum = sumDoubleAdd.ToString().Replace(".", ",");
                            saldoText.Text = replaceSum + "€";
                        }
                    }
                }
                else
                {
                    saldoText.Text = "0,00€";
                    gastosText.Text = "0,00€";
                }
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

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Histórico());
        }
    }
}
