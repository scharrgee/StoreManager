//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace storeManager.Entities
{
    public partial class CustomerPaymentHistory
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SaleID
        {
            get;
            set;
        }
    
        public virtual decimal PayAmount
        {
            get;
            set;
        }
    
        public virtual decimal Balance
        {
            get;
            set;
        }
    
        public virtual System.DateTime PaymentDate
        {
            get;
            set;
        }

        #endregion
    }
}
