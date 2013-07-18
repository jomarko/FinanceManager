using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceManager
{
    public class ItemFilter
    {
        public TypeEnum Type
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;
        }

        public Decimal MinValue
        {
            get;
            set;
        }

        public Decimal MaxValue
        {
            get;
            set;
        }

        public DateTime TimeFrom
        {
            get;
            set;
        }

        public DateTime TimeTo
        {
            get;
            set;
        }

        public String Description
        {
            get;
            set;
        }
    }
}
