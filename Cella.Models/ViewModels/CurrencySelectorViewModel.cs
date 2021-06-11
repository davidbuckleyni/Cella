using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models.ViewModels
{
    public class CurrencySelectorViewModel
    {
        public CurrencySelectorViewModel()
        {
            AvailableCurrencies = new List<Currency>();
        }

        public IList<Currency> AvailableCurrencies { get; set; }

        public int CurrentCurrencyId { get; set; }
    }
}
