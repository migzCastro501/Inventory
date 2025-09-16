using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class NumberFormatException : ApplicationException
    {
        public NumberFormatException(string message) : base(message) { }
    }

    public class StringFormatException : ApplicationException
    {
        public StringFormatException(string message) : base(message) { }
    }

    public class CurrencyFormatException : ApplicationException
    {
        public CurrencyFormatException(string message) : base(message) { }
    }

    public class ExpiredDateException : ApplicationException
    {
        public ExpiredDateException(string message) : base(message) { }
    }
}