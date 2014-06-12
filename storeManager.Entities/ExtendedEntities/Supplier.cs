using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities.Interfaces;

namespace storeManager.Entities
{
    public partial class Supplier : ISupplier
    {
        public int ID
        {
            get { return this.SupplierID; }
        }

        public string DisplayName
        {
            get { return this.Name; }
        }
    }
}
