using System;
using System.Collections.Generic;

namespace ASPcore2.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Journal = new HashSet<Journal>();
        }
        public Currency(Currency c)
        {
            if (c != null)
            {
                CurrencyId = c.CurrencyId;
                CurrencySimbol = c.CurrencySimbol;
                CurrencyName = c.CurrencyName;
                CurrencyValue = c.CurrencyValue;
            }
            Journal = new HashSet<Journal>();
        }

        public int CurrencyId { get; set; }
        public string CurrencySimbol { get; set; }
        public string CurrencyName { get; set; }
        public decimal CurrencyValue { get; set; }

        public ICollection<Journal> Journal { get; set; }
    }
}
