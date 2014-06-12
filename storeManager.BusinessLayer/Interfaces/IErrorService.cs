using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IErrorService : IServiceBase<ErrorLog, int>
    {
        void LogError(Exception ex, string message, string formName, string controlName);
    }
}
