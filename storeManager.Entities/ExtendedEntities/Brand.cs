using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities.Interfaces;

namespace storeManager.Entities
{
   public partial class Brand : IBrand
    {
        public int ID
        {
            get { return this.BrandID; }
        }

        public string DisplayName
        {
            get { return this.BrandName; }
        }
    }
}
