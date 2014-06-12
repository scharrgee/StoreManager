using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using storeManager.Entities.Interfaces;

namespace storeManager.Entities
{
   public partial class Employee:IEmployee
    {
        public int ID
        {
            get { return this.EmployeeID; }
        }

        public string DisplayName
        {
            get {return this.FisrtName + " " + this.OtherNames; }
        }
    }
}
