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
    public partial class ErrorLog
    {
        #region Primitive Properties
    
        public virtual int ErrorLogID
        {
            get;
            set;
        }
    
        public virtual string CustomMessage
        {
            get;
            set;
        }
    
        public virtual string ExceptionStackTrace
        {
            get;
            set;
        }
    
        public virtual string ExceptionMessage
        {
            get;
            set;
        }
    
        public virtual string InnerExeptionMessage
        {
            get;
            set;
        }
    
        public virtual string InnerExceptionStackTrace
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> ExceptionDate
        {
            get;
            set;
        }
    
        public virtual string ControlName
        {
            get;
            set;
        }
    
        public virtual string FormName
        {
            get;
            set;
        }

        #endregion
    }
}
