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
    public partial class ItemTappedList : ContentPage
    {
        public ItemTappedList(ShoppingList listName)
        {
            InitializeComponent();
        }

        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {

        }
    }
}