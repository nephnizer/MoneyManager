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
    public partial class ShopList : ContentPage
    {
        public ShopList()
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                List<ShoppingList> getList = conn.Query<ShoppingList>("SELECT ListName FROM ShoppingList");
                ListView.ItemsSource = getList;
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ItemTappedList(e.Item as ShoppingList));
        }
    }
}