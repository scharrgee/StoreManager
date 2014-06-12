using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using storeManager.Entities.Interfaces;

namespace storeManager.Entities
{
    public partial class Tax : ITax
    {
        public int ID
        {
            get { return this.TaxID; }
        }

        public string DisplayName
        {
            get { return this.TaxName; }
        }

        public decimal Rate
        {
            get { return this.TaxRate; }
        }
    }
}
