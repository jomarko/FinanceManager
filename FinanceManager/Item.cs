using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceManager
{
    public class Item
    {
        public int Id
        {
            get;
            set;
        }

        public TypeEnum Type
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Decimal Value
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;
        }

        public String Description
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Category + " " + Value + " " + Date;
        }
    }
}
