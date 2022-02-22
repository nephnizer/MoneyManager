using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Database
{
    public class Tables
    {

        public class MoneyHistory
        {
            public double Money { get; set; }
            public string DateTime { get; set; }
            public string Note { get; set; }
        }

        public class ShoppingList
        {
            public string ListName { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public bool ProductChecked { get; set; }
            public bool ListDone { get; set; }
        }
    }
}
