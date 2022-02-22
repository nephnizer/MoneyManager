using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MoneyManager.Database.Tables;

namespace MoneyManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Histórico : ContentPage
    {
        public Histórico()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listAddMoney();
        }

        private void btnRemove_Clicked(object sender, EventArgs e)
        {
            List<MoneyHistory> listMoney = new List<MoneyHistory>();
            listMoney.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                var moneyHistory = conn.Query<MoneyHistory>("SELECT * FROM MoneyHistory ORDER BY DateTime DESC");
                foreach (var item in moneyHistory)
                {
                    if (item.Money.ToString().Contains("-"))
                    {
                        string sYear = item.DateTime.ToString().Substring(0, 4);
                        char sMonth = item.DateTime.ToString()[4];
                        char sMonth2 = item.DateTime.ToString()[5];
                        string sDay = item.DateTime.ToString().Substring(6, 2);
                        string sDateTime = sDay + "/" + sMonth + sMonth2 + "/" + sYear;
                        item.DateTime = sDateTime;
                        listMoney.Add(item);
                    }
                }
                HistoricView.ItemsSource = listMoney;
            }
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            listAddMoney();
        }

        private void listAddMoney()
        {
            List<MoneyHistory> listMoney = new List<MoneyHistory>();
            listMoney.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                var moneyHistory = conn.Query<MoneyHistory>("SELECT * FROM MoneyHistory ORDER BY DateTime DESC");
                foreach (var item in moneyHistory)
                {
                    if (!item.Money.ToString().Contains("-"))
                    {
                        string sYear = item.DateTime.ToString().Substring(0, 4);
                        char sMonth = item.DateTime.ToString()[4];
                        char sMonth2 = item.DateTime.ToString()[5];
                        string sDay = item.DateTime.ToString().Substring(6, 2);
                        string sDateTime = sDay + "/" + sMonth + sMonth2 + "/" + sYear;
                        item.DateTime = sDateTime;
                        listMoney.Add(item);
                    }
                }
                HistoricView.ItemsSource = listMoney;
            }
        }
    }
}