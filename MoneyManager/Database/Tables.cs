using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Database
{
    public class Tables
    {
        public class MoneyAdded
        {
            //public int Money_ID { get; set; }
            public double AddedMoney { get; set; }
            public int DateTime { get; set; }
            public string Note { get; set; }
        }

        public class MoneySpent
        {
            public double SpentMoney { get; set; }
            public int DateTime { get; set; }
            public string Note { get; set; }
        }
    }
}
