using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities.Interfaces;

namespace storeManager.Entities
{
    public partial class Customer : ICustomer
    {
        public int ID
        {
            get { return this.CustomerID; }
        }

        public string DisplayName
        {
            get { return this.CustomerName; }
        }
    }
}
