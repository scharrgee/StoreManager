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
    public partial class StockTranfer
    {
        #region Primitive Properties
    
        public virtual int StockTranferID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> FromLocationID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> FromLocationQtyBeforeTranfer
        {
            get;
            set;
        }
    
        public virtual Nullable<int> FromLocationQtyAfterTransfer
        {
            get;
            set;
        }
    
        public virtual Nullable<int> ToLocationID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> ToLocationBeforeTransfer
        {
            get;
            set;
        }
    
        public virtual Nullable<int> ToLocationAfterTranfer
        {
            get;
            set;
        }
    
        public virtual Nullable<int> ProductID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> UserID
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> TransferDate
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TransferQty
        {
            get;
            set;
        }

        #endregion
    }
}