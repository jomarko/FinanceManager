using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceManager
{
    public class Category : IComparable
    {
        public int Id
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Category)
            {
                return ((Category)obj).Name.Equals(Name);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Id;
        }

        public int CompareTo(object o)
        {
            return ((Category)o).Name.CompareTo(Name);
        }
    }
}
