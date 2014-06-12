using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities.Interfaces;

namespace storeManager.Entities
{
   public partial class Category : ICategory
    {
        public int ID
        {
            get { return this.CategoryID; }
        }

        public string DisplayName
        {
            get { return this.Name; }
        }
    }
}
